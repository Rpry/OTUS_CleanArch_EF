namespace Services.Contracts.Course
{
    /// <summary>
    /// ДТО редактируемого курса.
    /// </summary>
    public class UpdatingCourseDto
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