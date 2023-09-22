using System.Collections.Generic;
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
        /// <returns> ДТО урока. </returns>
        Task<LessonDto> GetById(int id);

        /// <summary>
        /// Создать урок.
        /// </summary>
        /// <param name="creatingLessonDto"> ДТО урока. </param>
        /// <returns> Идентификатор. </returns>
        Task<int> Create(CreatingLessonDto creatingLessonDto);

        /// <summary>
        /// Изменить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingLessonDto"> ДТО урока. </param>
        Task Update(int id, UpdatingLessonDto updatingLessonDto);

        /// <summary>
        /// Удалить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task Delete(int id);
        
        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница уроков. </returns>
        Task<ICollection<LessonDto>> GetPaged(int page, int pageSize);
    }
}