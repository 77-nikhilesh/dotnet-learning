using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.API.Data;
using MyProject.API.Dto;
using MyProject.API.DTOs;
using MyProject.API.Models.Domain;
using MyProject.API.Repositories;

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        //private readonly MyProjectDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper mapper;
        public RegionController(MyProjectDbContext dbContext, IRegionRepository regionRepository,
            IMapper mapper)
        {
            //_dbContext = dbContext;
            _regionRepository = regionRepository;
            this.mapper=mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? SortBy, [FromQuery] bool? isAscending,
            [FromQuery] int PageNumber = 1, [FromQuery] int PageSize=20)
        {

            //Get data from database - domain models
            var regions = await _regionRepository.GetAllAsync(filterOn, filterQuery, SortBy, isAscending, PageNumber,PageSize);

          
            //Map domain models to Dtos
            var regionDtos = mapper.Map<List<RegionDto>>(regions);

            return Ok(regionDtos);
        }


        //GET single region by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActionById(Guid id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);

        }


        //Post Method to add new region
        [HttpPost]
        public async Task<IActionResult> Create(AddRegionRequestDto addRegionRequestDto)
        {

            if (ModelState.IsValid)
            {
                //convert Dto to Domain model(Entity)
                var regionDomain = mapper.Map<Region>(addRegionRequestDto);



                regionDomain = await _regionRepository.CreateAsync(regionDomain);


                //Map domain back to Dto
                var regionDto = mapper.Map<RegionDto>(regionDomain);

                return CreatedAtAction(nameof(GetActionById), new { id = regionDomain.Id }, regionDto);

            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }



        //Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            if (ModelState.IsValid) {
                //Map Dto to Domain model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);


                regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);
                if (regionDomainModel == null)
                {
                    return NotFound();
                }


                //Map domain model back to Dto
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return Ok(regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var regionDomain = await _regionRepository.DeleteAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }
    }
}


