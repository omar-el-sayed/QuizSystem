namespace QuizSystem.Models
{
    public class Instructor : User
    {
        public double Salary { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }

        public Instructor()
        {
            UserType = UserType.Instructor;
        }
    }
}
