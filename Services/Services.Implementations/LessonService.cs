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
    /// Сервис работы с уроками.
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
        /// Получить постраничный список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница уроков. </returns>
        public async Task<ICollection<LessonDto>> GetPaged(int page, int pageSize)
        {
            ICollection<Lesson> entities = await _lessonRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Lesson>, ICollection<LessonDto>>(entities);
        }

        /// <summary>
        /// Получить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО урока. </returns>
        public async Task<LessonDto> GetById(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            return _mapper.Map<Lesson, LessonDto>(lesson);
        }

        /// <summary>
        /// Создать урок.
        /// </summary>
        /// <param name="lessonDto"> ДТО урока. </param>
        /// <returns> Идентификатор</returns>
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
        /// Изменить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="lessonDto"> ДТО урока. </param>
        public async Task Update(int id, LessonDto lessonDto)
        {
            var entity = _mapper.Map<LessonDto, Lesson>(lessonDto);
            entity.Id = id;
            _lessonRepository.Update(entity);
            await _lessonRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task Delete(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            lesson.Deleted = true; 
            await _lessonRepository.SaveChangesAsync();
        }
    }
}