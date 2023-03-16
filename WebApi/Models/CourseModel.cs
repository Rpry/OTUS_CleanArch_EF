using System.Collections.Generic;
using Services.Contracts;

namespace WebApi.Models
{
    /// <summary>
    /// ДТО курса
    /// </summary>
    public class CourseModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Уроки
        /// </summary>
        public List<LessonDto> Lessons { get; set; }
    }
}