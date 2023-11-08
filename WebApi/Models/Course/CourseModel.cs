using System.Collections.Generic;
using WebApi.Models.Lesson;

namespace WebApi.Models.Course
{
    /// <summary>
    /// Модель курса.
    /// </summary>
    public class CourseModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }
        
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
        public List<LessonModel> Lessons { get; set; }
    }
}