using AutoMapper;
using Services.Contracts.Course;
using WebApi.Models.Course;

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
            CreateMap<CreatingCourseModel, CreatingCourseDto>();
            CreateMap<UpdatingCourseModel, UpdatingCourseDto>();
            CreateMap<CourseFilterModel, CourseFilterDto>();
        }
    }
}
