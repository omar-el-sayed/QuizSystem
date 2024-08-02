﻿namespace QuizSystem.Models
{
    public class QuizQuestion : BaseEntity
    {
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
