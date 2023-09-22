using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contracts.Course;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий работы с уроками.
    /// </summary>
    public interface ICourseRepository: IRepository<Course, int>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список курсов. </returns>
        Task<List<Course>> GetPagedAsync(CourseFilterDto filterDto);
    }
}
