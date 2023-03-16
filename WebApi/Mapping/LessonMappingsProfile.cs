using AutoMapper;
using Services.Contracts;
using WebApi.Models;

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
            CreateMap<LessonModel, LessonDto>();
        }
    }
}
