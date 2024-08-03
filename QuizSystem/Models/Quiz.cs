namespace QuizSystem.Models
{
    public class Quiz : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public int TotalGrade { get; set; }
        public QuizType QuizType { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }

    public enum QuizType
    {
        Quiz, Final
    }
}
