using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Курс.
    /// </summary>
    public class Course: IEntity<int>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Уроки.
        /// </summary>
        public virtual List<Lesson> Lessons { get; set; }
        
        /// <summary>
        /// Удалено.
        /// </summary>
        public bool Deleted { get; set; }
    }
}