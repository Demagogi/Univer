using AutoMapper;
using Univer.Application.Dtos;
using Univer.Domain.Entities;

namespace Univer.Application.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Lecturer, LecturerDto>().ReverseMap();
            CreateMap<CreateLecturerDto, Lecturer>();
            CreateMap<UpdateLecturerDto, Lecturer>();
        }
    }
}
