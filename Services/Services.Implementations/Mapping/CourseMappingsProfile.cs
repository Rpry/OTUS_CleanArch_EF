using AutoMapper;
using Domain.Entities;
using Services.Contracts.Course;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности курса.
    /// </summary>
    public class CourseMappingsProfile : Profile
    {
        public CourseMappingsProfile()
        {
            CreateMap<Course, CourseDto>();
            
            CreateMap<CreatingCourseDto, Course>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Lessons, map => map.Ignore());
            
            CreateMap<UpdatingCourseDto, Course>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Lessons, map => map.Ignore());

            CreateMap<UpdatingCourseWithLessonsDto, Course>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Lessons, map => map.Ignore());
        }
    }
}
