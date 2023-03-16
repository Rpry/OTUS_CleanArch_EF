using AutoMapper;
using Domain.Entities;
using Services.Contracts;

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

            CreateMap<LessonDto, Lesson>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Course, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                .ForAllOtherMembers(m=>m.Ignore());
        }
    }
}
