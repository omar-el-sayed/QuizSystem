using Autofac;
using QuizSystem.Data;
using QuizSystem.Repository;
using QuizSystem.Services.Courses;
using QuizSystem.Services.Quizzes;

namespace QuizSystem
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<QuizService>().As<IQuizService>().InstancePerLifetimeScope();
        }
    }
}
