namespace WebApi.Models.Course
{
    /// <summary>
    /// Модель создаваемого курса.
    /// </summary>
    public class CreatingCourseModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; set; }
    }
}