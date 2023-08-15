using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с уроками.
    /// </summary>
    public interface ILessonService
    {
        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница уроков. </returns>
        Task<ICollection<LessonDto>> GetPaged(int page, int pageSize);

        /// <summary>
        /// Получить урок. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО урока. </returns>
        Task<LessonDto> GetById(int id);

        /// <summary>
        /// Создать урок.
        /// </summary>
        /// <param name="lessonDto"> ДТО урока. </param>
        /// <returns> Идентификатор. </returns>
        Task<int> Create(LessonDto lessonDto);

        /// <summary>
        /// Изменить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="lessonDto"> ДТО урока. </param>
        Task Update(int id, LessonDto lessonDto);

        /// <summary>
        /// Удалить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task Delete(int id);
    }
}