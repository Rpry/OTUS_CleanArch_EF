using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Базовый интерфейс всех репозиториев
    /// </summary>
    public interface IRepository
    {
    }

    /// <summary>
    /// Описания общих методов для всех репозиториев
    /// </summary>
    /// <typeparam name="T">Тип Entity для репозитория</typeparam>
    /// <typeparam name="TPrimaryKey">тип первичного ключа</typeparam>
    public interface IRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey>
        where T : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">ID удалённой сущности</param>
        /// <returns>была ли сущность удалена</returns>
        bool Delete(TPrimaryKey id);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity">сущность для удаления</param>
        /// <returns>была ли сущность удалена</returns>
        bool Delete(T entity);

        /// <summary>
        /// Удалить сущности
        /// </summary>
        /// <param name="entities">Коллекция сущностей для удаления</param>
        /// <returns>была ли операция удаления успешна</returns>
        bool DeleteRange(ICollection<T> entities);

        /// <summary>
        /// Для сущности проставить состояние - что она изменена
        /// </summary>
        /// <param name="entity">сущность для изменения</param>
        void Update(T entity);

        /// <summary>
        /// Добавить в базу одну сущность
        /// </summary>
        /// <param name="entity">сущность для добавления</param>
        /// <returns>добавленная сущность</returns>
        T Add(T entity);

        /// <summary>
        /// Добавить в базу одну сущность
        /// </summary>
        /// <param name="entity">сущность для добавления</param>
        /// <returns>добавленная сущность</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Добавить в базу массив сущностей
        /// </summary>
        /// <param name="entities">массив сущностей</param>
        void AddRange(List<T> entities);

        /// <summary>
        /// Добавить в базу массив сущностей
        /// </summary>
        /// <param name="entities">массив сущностей</param>
        Task AddRangeAsync(ICollection<T> entities);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
