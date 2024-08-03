namespace QuizSystem.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int CreditHours { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
