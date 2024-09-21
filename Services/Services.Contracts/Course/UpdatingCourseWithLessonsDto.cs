using System.Collections.Generic;
using Services.Contracts.Lesson;

namespace Services.Contracts.Course
{
    /// <summary>
    /// ДТО обновления курса с изменением состава уроков.
    /// </summary>
    public class UpdatingCourseWithLessonsDto
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Уроки
        /// </summary>
        public IEnumerable<AttachingLessonDto> Lessons { get; set; }
    }
}