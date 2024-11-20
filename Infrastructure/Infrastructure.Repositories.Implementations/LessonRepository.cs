using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с уроками.
    /// </summary>
    public class LessonRepository: Repository<Lesson, int>, ILessonRepository 
    {
        public LessonRepository(DatabaseContext context): base(context)
        {
        }

        /// <summary>
        /// Получить сущность по Id.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> Курс. </returns>
        public override async Task<Lesson> GetAsync(int id, CancellationToken cancellationToken)
        {
            //await Task.Delay(TimeSpan.FromSeconds(20));
            var query = Context.Set<Lesson>().AsQueryable();
            query = query
                .Where(l => l.Id == id && !l.Deleted);

            return await query.SingleOrDefaultAsync();
            //return await query.SingleOrDefaultAsync(cancellationToken);
        }
        
        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список уроков. </returns>
        public async Task<List<Lesson>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll().Where(l => !l.Deleted);
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
    }
}
