using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MyProject.API.DTOs;
using MyProject.API.Repositories;
using MyProject.API.Models.Domain;

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {

        private readonly IWalkRepository _walkRepository;
        private readonly IMapper mappers;

        public WalkController(IWalkRepository walkRepository, IMapper mappers)
        {
            this._walkRepository = walkRepository;
            this.mappers = mappers;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDomainModel = await _walkRepository.GetAllWalksAsync();
            var walksDto = mappers.Map<List<WalksDto>>(walksDomainModel);
            return Ok(walksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walksDomainModel = await _walkRepository.GetWalkByIdAsync(id);
            if (walksDomainModel == null)
            {
                return NotFound();
            }
            var walksDto = mappers.Map<List<WalksDto>>(walksDomainModel);
            return Ok(walksDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalks([FromBody] AddWalksRequestDto addWalksRequestDto)
        {

            if (ModelState.IsValid)
            {
                //Map dto to Domain model
                var walkDomainModel = mappers.Map<Walk>(addWalksRequestDto);

                await _walkRepository.CreateWalkAsync(walkDomainModel);

                //Map Domain model to dto
                var walkDto = mappers.Map<WalksDto>(walkDomainModel);

                return Ok(walkDto);

            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateWalks(Guid id, [FromBody] UpdateWalksRequestDto updateWalksRequestDto)
        {
            if(ModelState.IsValid){
                // Map dto to Domain model
                var walkDomainModel = mappers.Map<Walk>(updateWalksRequestDto);
                walkDomainModel = await _walkRepository.UpdateWalkAsync(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();
                }
                // Map Domain model to dto
                var walkDto = mappers.Map<WalksDto>(walkDomainModel);
                return Ok(walkDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
          
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWalks(Guid id)
        {
            var walkDomainModel = await _walkRepository.DeleteWalkAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain model to dto
            var walkDto = mappers.Map<WalksDto>(walkDomainModel);
            return Ok(walkDto);
        }

    }
}
