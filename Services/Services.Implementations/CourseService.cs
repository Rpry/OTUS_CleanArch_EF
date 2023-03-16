using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using Domain.Entities;
using Services.Contracts;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с курсами
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CourseService(
            IMapper mapper,
            ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
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
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО курса</returns>
        public async Task<CourseDto> GetById(int id)
        {
            var course = await _courseRepository.GetAsync(id);
            return _mapper.Map<Course, CourseDto>(course);
        }

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="courseDto">ДТО курса</param>
        /// <returns>идентификатор</returns>
        public async Task<int> Create(CourseDto courseDto)
        {
            var entity = _mapper.Map<CourseDto, Course>(courseDto);
            var res = await _courseRepository.AddAsync(entity);
            await _courseRepository.SaveChangesAsync();
            return res.Id;
        }

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="courseDto">ДТО курса</param>
        public async Task Update(int id, CourseDto courseDto)
        {
            var entity = _mapper.Map<CourseDto, Course>(courseDto);
            entity.Id = id;
            _courseRepository.Update(entity);
            await _courseRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        public async Task Delete(int id)
        {
            var course = await _courseRepository.GetAsync(id);
            course.Deleted = true; 
            await _courseRepository.SaveChangesAsync();
        }
    }
}