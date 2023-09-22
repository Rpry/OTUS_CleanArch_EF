namespace Services.Contracts.Lesson
{
    /// <summary>
    /// ДТО урока.
    /// </summary>
    public class LessonDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }
    }
}