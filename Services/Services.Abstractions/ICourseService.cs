using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с курсами.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список курсов. </returns>
        Task<ICollection<CourseDto>> GetPaged(CourseFilterDto filterDto);

        /// <summary>
        /// Получить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО курса. </returns>
        Task<CourseDto> GetById(int id);

        /// <summary>
        /// Создать курс.
        /// </summary>
        /// <param name="courseDto"> ДТО курса. </param>
        Task<int> Create(CourseDto courseDto);

        /// <summary>
        /// Изменить курс.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="courseDto"> ДТО курса. </param>
        Task Update(int id, CourseDto courseDto);

        /// <summary>
        /// Удалить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task Delete(int id);
    }
}