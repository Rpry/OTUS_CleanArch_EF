using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using CommonNamespace;
using Domain.Entities;
using MassTransit;
using Services.Contracts.Lesson;

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
        /// <param name="creatingLessonDto"> ДТО урока. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> Create(CreatingLessonDto creatingLessonDto)
        {
            var lesson = _mapper.Map<CreatingLessonDto, Lesson>(creatingLessonDto);
            lesson.CourseId = creatingLessonDto.CourseId;
            var createdLesson = await _lessonRepository.AddAsync(lesson);
            await _lessonRepository.SaveChangesAsync();

            await _busControl.Publish(new MessageDto
            {
                Content = $"Lesson {createdLesson.Id} with subject {createdLesson.Subject} is added"
            });

            return createdLesson.Id;
            
        }

        /// <summary>
        /// Изменить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingLessonDto"> ДТО урока. </param>
        public async Task Update(int id, UpdatingLessonDto updatingLessonDto)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            if (lesson == null)
            {
                throw new Exception($"Урок с id = {id} не найден");
            }

            lesson.Subject = updatingLessonDto.Subject;
            _lessonRepository.Update(lesson);
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
    }
}