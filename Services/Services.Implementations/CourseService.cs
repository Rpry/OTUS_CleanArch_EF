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
    /// Cервис работы с курсами.
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IBusControl _busControl;

        public CourseService(
            IMapper mapper,
            ICourseRepository courseRepository,
            IBusControl busControl)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _busControl = busControl;
        }

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список курсов. </returns>
        public async Task<ICollection<CourseDto>> GetPaged(CourseFilterDto filterDto)
        {
            ICollection<Course> entities = await _courseRepository.GetPagedAsync(filterDto);
            return _mapper.Map<ICollection<Course>, ICollection<CourseDto>>(entities);
        }

        /// <summary>
        /// Получить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО курса. </returns>
        public async Task<CourseDto> GetById(int id)
        {
            var course = await _courseRepository.GetAsync(id);
            return _mapper.Map<Course, CourseDto>(course);
        }

        /// <summary>
        /// Создать курс.
        /// </summary>
        /// <param name="courseDto"> ДТО курса. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> Create(CourseDto courseDto)
        {
            var entity = _mapper.Map<CourseDto, Course>(courseDto);
            var res = await _courseRepository.AddAsync(entity);
            await _courseRepository.SaveChangesAsync();
            await _busControl.Publish(new MessageDto
            {
                Content = $"Lesson {entity.Id} with name {entity.Name} is added"
            });
            return res.Id;
        }

        /// <summary>
        /// Изменить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="courseDto"> ДТО курса. </param>
        public async Task Update(int id, CourseDto courseDto)
        {
            var entity = _mapper.Map<CourseDto, Course>(courseDto);
            entity.Id = id;
            _courseRepository.Update(entity);
            await _courseRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task Delete(int id)
        {
            var course = await _courseRepository.GetAsync(id);
            course.Deleted = true; 
            await _courseRepository.SaveChangesAsync();
        }
    }
}