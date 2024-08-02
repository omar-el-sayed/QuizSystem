using Autofac;
using QuizSystem.Data;
using QuizSystem.Repository;
using QuizSystem.Services.Choices;
using QuizSystem.Services.Courses;
using QuizSystem.Services.Questions;
using QuizSystem.Services.Quizzes;
using QuizSystem.Services.UserManagement;

namespace QuizSystem
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<QuizService>().As<IQuizService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<ChoiceService>().As<IChoiceService>().InstancePerLifetimeScope();
        }
    }
}
