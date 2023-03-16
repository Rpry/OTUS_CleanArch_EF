namespace WebApi.Models
{
    public class LessonModel
    {
        /// <summary>
        /// Идентификатор курса
        /// </summary>
        public int CourseId { get; set; }
        
        /// <summary>
        /// Тема
        /// </summary>
        public string Subject { get; set; }
    }
}