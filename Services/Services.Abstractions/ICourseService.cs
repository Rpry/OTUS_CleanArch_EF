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
        Task<CourseDto> GetById(int id);

        /// <summary>
        /// Создать курс.
        /// </summary>
        /// <param name="creatingCourseDto"> ДТО создаваемого курса. </param>
        Task<int> Create(CreatingCourseDto creatingCourseDto);

        /// <summary>
        /// Изменить курс.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="updatingCourseDto"> ДТО редактируемого курса. </param>
        Task Update(int id, UpdatingCourseDto updatingCourseDto);

        /// <summary>
        /// Удалить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task Delete(int id);
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список курсов. </returns>
        Task<ICollection<CourseDto>> GetPaged(CourseFilterDto filterDto);
    }
}