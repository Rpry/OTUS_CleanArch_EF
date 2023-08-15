﻿namespace Services.Contracts
{
    /// <summary>
    /// ДТО урока.
    /// </summary>
    public class LessonDto
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