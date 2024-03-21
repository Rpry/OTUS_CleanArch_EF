using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.Lesson;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с уроками.
    /// </summary>
    public interface ILessonService
    {
        /// <summary>
        /// Получить урок. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО урока. </returns>
        Task<LessonDto> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать урок.
        /// </summary>
        /// <param name="creatingLessonDto"> ДТО урока. </param>
        /// <returns> Идентификатор. </returns>
        Task<int> CreateAsync(CreatingLessonDto creatingLessonDto);

        /// <summary>
        /// Изменить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingLessonDto"> ДТО урока. </param>
        Task UpdateAsync(int id, UpdatingLessonDto updatingLessonDto);

        /// <summary>
        /// Удалить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(int id);
        
        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница уроков. </returns>
        Task<ICollection<LessonDto>> GetPagedAsync(int page, int pageSize);
    }
}