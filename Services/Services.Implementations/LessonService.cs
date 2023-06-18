using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using CommonNamespace;
using Domain.Entities;
using MassTransit;
using Services.Contracts;

namespace Services.Implementations
{
    /// <summary>
    /// Сервис работы с уроками
    /// </summary>
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly IBusControl _busControl;

        public LessonService(
            IMapper mapper,
            ILessonRepository lessonRepository,
            IBusControl busControl)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _busControl = busControl;
        }

        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns></returns>
        public async Task<ICollection<LessonDto>> GetPaged(int page, int pageSize)
        {
            ICollection<Lesson> entities = await _lessonRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Lesson>, ICollection<LessonDto>>(entities);
        }

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО урока</returns>
        public async Task<LessonDto> GetById(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            return _mapper.Map<Lesson, LessonDto>(lesson);
        }

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="lessonDto">ДТО урока</param>
        /// <returns>идентификатор</returns>
        public async Task<int> Create(LessonDto lessonDto)
        {
            var entity = _mapper.Map<LessonDto, Lesson>(lessonDto);
            entity.CourseId = lessonDto.CourseId;
            var res = await _lessonRepository.AddAsync(entity);
            await _lessonRepository.SaveChangesAsync();

            await _busControl.Publish(new MessageDto
            {
                Content = $"Lesson {entity.Id} with subject {entity.Subject} is added"
            });

            return res.Id;
            
        }

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="lessonDto">ДТО урока</param>
        public async Task Update(int id, LessonDto lessonDto)
        {
            var entity = _mapper.Map<LessonDto, Lesson>(lessonDto);
            entity.Id = id;
            _lessonRepository.Update(entity);
            await _lessonRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        public async Task Delete(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            lesson.Deleted = true; 
            await _lessonRepository.SaveChangesAsync();
        }
    }
}