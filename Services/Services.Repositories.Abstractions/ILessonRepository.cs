using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий работы с уроками.
    /// </summary>
    public interface ILessonRepository: IRepository<Lesson, int>
    {
        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список уроков. </returns>
        Task<List<Lesson>> GetPagedAsync(int page, int itemsPerPage);
    }
}
