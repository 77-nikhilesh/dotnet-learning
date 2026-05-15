using AutoMapper;
using MyProject.API.Dto;
using MyProject.API.DTOs;
using MyProject.API.Models.Domain;

namespace MyProject.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //AutoMapper configuration for Region
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();


            //AutoMapper configuration for Walk
            CreateMap<Walk, WalksDto>().ReverseMap();
            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalksRequestDto, Walk>().ReverseMap();

            //AutoMapper configuration for Difficulty
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
