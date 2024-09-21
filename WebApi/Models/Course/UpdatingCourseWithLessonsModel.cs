using System.Collections.Generic;
using WebApi.Models.Lesson;

namespace WebApi.Models.Course
{
    /// <summary>
    /// Модель обновления курса с изменением состава уроков.
    /// </summary>
    public class UpdatingCourseWithLessonsModel
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
        /// Уроки.
        /// </summary>
        public IEnumerable<AttachingLessonModel> Lessons { get; set; }
    }
}