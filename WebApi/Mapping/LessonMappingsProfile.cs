using AutoMapper;
using Services.Contracts.Lesson;
using WebApi.Models.Lesson;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности урока.
    /// </summary>
    public class LessonMappingsProfile : Profile
    {
        public LessonMappingsProfile()
        {
            CreateMap<LessonDto, LessonModel>();
            CreateMap<CreatingLessonModel, CreatingLessonDto>();
            CreateMap<UpdatingLessonModel, UpdatingLessonDto>();
            CreateMap<AttachingLessonModel, AttachingLessonDto>();
        }
    }
}
