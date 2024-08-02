namespace QuizSystem.Models
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
