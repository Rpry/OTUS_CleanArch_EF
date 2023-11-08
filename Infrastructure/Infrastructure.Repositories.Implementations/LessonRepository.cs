using System.Collections.Generic;
using System.Linq;
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
        /// <returns> Курс. </returns>
        public override async Task<Lesson> GetAsync(int id)
        {
            var query = Context.Set<Lesson>().AsQueryable();
            query = query
                .Where(l => l.Id == id && !l.Deleted);

            return await query.SingleOrDefaultAsync();
        }
        
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
