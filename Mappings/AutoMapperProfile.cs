using AutoMapper;
using PutApi.Models;
using PutApi.DTOs;

namespace PutApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
