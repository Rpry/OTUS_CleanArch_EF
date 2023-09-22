namespace Services.Contracts.Course
{
    /// <summary>
    /// ДТО курса.
    /// </summary>
    public class CreatingCourseDto
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