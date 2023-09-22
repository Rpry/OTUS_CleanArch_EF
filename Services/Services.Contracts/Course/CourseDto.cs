using System.Collections.Generic;
using Services.Contracts.Lesson;

namespace Services.Contracts.Course
{
    /// <summary>
    /// ДТО курса.
    /// </summary>
    public class CourseDto
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
        public List<LessonDto> Lessons { get; set; }
    }
}