﻿using System;

namespace Services.Contracts.Lesson
{
    /// <summary>
    /// ДТО редактируемого урока.
    /// </summary>
    public class UpdatingLessonDto
    {
        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }

        public DateTime DateTime { get; set; }
    }
}