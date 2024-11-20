using System;

namespace Domain.Entities
{
    /// <summary>
    /// Урок.
    /// </summary>
    public class Lesson: IEntity<int>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Курс.
        /// </summary>
        public virtual Course Course { get; set; }
        
        /// <summary>
        /// Id курса.
        /// </summary>
        public int CourseId { get; set; }
        
        /// <summary>
        /// Удалено.
        /// </summary>
        public bool Deleted { get; set; }
        
        //public DateTime DateTime { get; set; }
    }
}