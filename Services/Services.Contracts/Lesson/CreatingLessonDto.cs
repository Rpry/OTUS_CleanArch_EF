namespace Services.Contracts.Lesson
{
    /// <summary>
    /// ДТО урока.
    /// </summary>
    public class CreatingLessonDto
    {
        /// <summary>
        /// Идентификатор курса.
        /// </summary>
        public int CourseId { get; set; }
        
        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }
    }
}