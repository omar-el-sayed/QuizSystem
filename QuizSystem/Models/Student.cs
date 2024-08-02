namespace QuizSystem.Models
{
    public class Student : User
    {
        public Student()
        {
            UserType = UserType.Student;
        }
    }
}
