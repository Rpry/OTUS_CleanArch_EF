using AutoMapper;
using Domain.Entities;
using Services.Contracts.Lesson;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности урока.
    /// </summary>
    public class LessonMappingsProfile : Profile
    {
        public LessonMappingsProfile()
        {
            CreateMap<Lesson, LessonDto>();

            CreateMap<CreatingLessonDto, Lesson>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Course, map => map.Ignore())
                .ForMember(d => d.CourseId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject));
            
            CreateMap<UpdatingLessonDto, Lesson>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Course, map => map.Ignore())
                .ForMember(d => d.CourseId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                ;
            
            CreateMap<AttachingLessonDto, Lesson>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Course, map => map.Ignore())
                .ForMember(d => d.CourseId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                ;
        }
    }
}
