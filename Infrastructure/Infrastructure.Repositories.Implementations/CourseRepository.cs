using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с курсами
    /// </summary>
    public class CourseRepository: Repository<Course, int>, ICourseRepository 
    {
        public CourseRepository(DatabaseContext context): base(context)
        {
        }

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список курсов. </returns>
        public async Task<List<Course>> GetPagedAsync(CourseFilterDto filterDto)
        {
            var query = GetAll().ToList().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                query = query.Where(c => c.Name == filterDto.Name);
            }

            if (filterDto.Price.HasValue)
            {
                query = query.Where(c => c.Price == filterDto.Price);
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return query.ToList();
        }

        /// <summary>
        /// Получить сущность по ID
        /// </summary>
        /// <param name="id">ID сущности</param>
        /// <returns>сущность</returns>
        public override Task<Course> GetAsync(int id)
        {
            var query = Context.Set<Course>().AsQueryable();
            query = query
                //.Include(c => c.Lessons)
                .Where(c => c.Id == id);

            return query.SingleOrDefaultAsync();
        }
    }
}
