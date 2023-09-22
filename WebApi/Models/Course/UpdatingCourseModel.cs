namespace WebApi.Models.Course
{
    /// <summary>
    /// Модель редактируемого курса.
    /// </summary>
    public class UpdatingCourseModel
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