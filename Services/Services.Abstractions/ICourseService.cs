using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.Course;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с курсами.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Получить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО курса. </returns>
        Task<CourseDto> GetByIdAsync(int id);

        /// <summary>
        /// Создать курс.
        /// </summary>
        /// <param name="creatingCourseDto"> ДТО создаваемого курса. </param>
        Task<int> CreateAsync(CreatingCourseDto creatingCourseDto);

        /// <summary>
        /// Обновить курс и состав уроков.
        /// Для показа unit of work.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="updatingCourseWithLessonsDto"></param>
        Task UpdatingWithLessonsAsync(int id, UpdatingCourseWithLessonsDto updatingCourseWithLessonsDto);        

        /// <summary>
        /// Изменить курс.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="updatingCourseDto"> ДТО редактируемого курса. </param>
        Task UpdateAsync(int id, UpdatingCourseDto updatingCourseDto);

        /// <summary>
        /// Удалить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(int id);
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список курсов. </returns>
        Task<ICollection<CourseDto>> GetPagedAsync(CourseFilterDto filterDto);
    }
}