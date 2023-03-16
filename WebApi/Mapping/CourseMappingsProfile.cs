using AutoMapper;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности курса.
    /// </summary>
    public class CourseMappingsProfile : Profile
    {
        public CourseMappingsProfile()
        {
            CreateMap<CourseDto, CourseModel>();
            CreateMap<CourseModel, CourseDto>();
            
            CreateMap<CourseFilterModel, CourseFilterDto>();
        }
    }
}
