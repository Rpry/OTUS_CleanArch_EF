using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using Domain.Entities;
using MassTransit;
using Services.Contracts.Course;
using Services.Contracts.Lesson;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с курсами.
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IBusControl _busControl;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(
            IMapper mapper,
            ICourseRepository courseRepository,
            ILessonRepository lessonRepository,
            IUnitOfWork unitOfWork,
            IBusControl busControl)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _lessonRepository = lessonRepository;
            _busControl = busControl;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО курса. </returns>
        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<Course, CourseDto>(course);
        }

        /// <summary>
        /// Создать курс.
        /// </summary>
        /// <param name="creatingCourseDto"> ДТО создаваемого курса. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> CreateAsync(CreatingCourseDto creatingCourseDto)
        {
            var course = _mapper.Map<CreatingCourseDto, Course>(creatingCourseDto);
            var createdCourse = await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();
            /*
            await _busControl.Publish(new MessageDto
            {
                Content = $"Course {createdCourse.Id} with name {createdCourse.Name} is added"
            });
            */
            return createdCourse.Id;
        }
        
        /// <summary>
        /// Обновить курс и состав уроков.
        /// Для показа unit of work.
        /// </summary>
        /// <param name="updatingCourseWithLessonsDto"> ДТО редактируемого курса. </param>
        /// <param name="id"> Id </param>
        public async Task UpdatingWithLessonsAsync(int id, UpdatingCourseWithLessonsDto updatingCourseWithLessonsDto)
        {
            //var course = await _unitOfWork.CourseRepository.GetAsync(id, CancellationToken.None);
            var course = await _courseRepository.GetAsync(id, CancellationToken.None);
            if (course == null)
            {
                throw new Exception($"Курс с идентфикатором {id} не найден");
            }

            course.Name = updatingCourseWithLessonsDto.Name;
            course.Price = updatingCourseWithLessonsDto.Price;
            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
            //_unitOfWork.CourseRepository.Update(course);
            var lessons = _mapper.Map<IEnumerable<AttachingLessonDto>, IEnumerable<Lesson>>(updatingCourseWithLessonsDto.Lessons);
            foreach (var lesson in lessons)
            {
                lesson.CourseId = 100; //Не существует
                await _lessonRepository.AddAsync(lesson);
                //await _unitOfWork.LessonRepository.AddAsync(lesson);
            }
            
            await _lessonRepository.SaveChangesAsync();
            //await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Изменить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingCourseDto"> ДТО редактируемого курса. </param>
        public async Task UpdateAsync(int id, UpdatingCourseDto updatingCourseDto)
        {
            var course = await _courseRepository.GetAsync(id, CancellationToken.None);
            if (course == null)
            {
                throw new Exception($"Курс с идентфикатором {id} не найден");
            }

            course.Name = updatingCourseDto.Name;
            course.Price = updatingCourseDto.Price;
            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(int id)
        {
            var course = await _courseRepository.GetAsync(id, CancellationToken.None);
            course.Deleted = true; 
            await _courseRepository.SaveChangesAsync();
        }
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список курсов. </returns>
        public async Task<ICollection<CourseDto>> GetPagedAsync(CourseFilterDto filterDto)
        {
            ICollection<Course> entities = await _courseRepository.GetPagedAsync(filterDto);
            return _mapper.Map<ICollection<Course>, ICollection<CourseDto>>(entities);
        }
    }
}