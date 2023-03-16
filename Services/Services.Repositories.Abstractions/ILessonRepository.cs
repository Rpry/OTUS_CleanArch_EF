using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий работы с уроками
    /// </summary>
    public interface ILessonRepository: IRepository<Lesson, int>
    {
        Task<List<Lesson>> GetPagedAsync(int page, int itemsPerPage);
    }
}
