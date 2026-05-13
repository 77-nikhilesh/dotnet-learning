using System.Linq;
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

        public RegionController(MyProjectDbContext dbContext, IRegionRepository regionRepository)
        {
            //_dbContext = dbContext;
            _regionRepository = regionRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Auckland Region",
            //        Code= "AKL",
            //        RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Auckland_Region_in_New_Zealand.svg/1200px-Auckland_Region_in_New_Zealand.svg.png"
            //
            //    },
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Bay of Plenty Region",
            //        Code= "BOP",
            //        RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Bay_of_Plenty_Region_in_New_Zealand.svg/1200px-Bay_of_Plenty_Region_in_New_Zealand.svg.png"
            //    }
            //};
            //return Ok(regions);

            var regions = await _regionRepository.GetAllAsync();

            var regionDtos = new List<RegionDto>();

            foreach (var region in regions)
            {
                regionDtos.Add(new RegionDto
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return Ok(regionDtos);
        }


        //GET single region by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActionById(Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);

        }


        //Post Method to add new region
        [HttpPost]
        public async Task<IActionResult> Create(AddRegionRequestDto addRegionRequestDto)
        {
            //convert Dto to Domain model(Entity)

            var region = new Region {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl

            };

            //Use Domain model to create a region

            //await _dbContext.Regions.AddAsync(region);
            //await _dbContext.SaveChangesAsync();

            region = await _regionRepository.CreateAsync(region);


            //Map domain back to Dto
            var RegionDto = new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetActionById), new { id = region.Id }, RegionDto);
        }



        //Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            var regionDomainModel= new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };
            regionDomainModel  = await _regionRepository.UpdateAsync(id,regionDomainModel);
            if(regionDomainModel == null)
                {
                    return NotFound();
                }
    
             

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            return Ok("Region deleted successfully");
        }
    }
}


