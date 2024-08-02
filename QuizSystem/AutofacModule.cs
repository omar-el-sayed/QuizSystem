using Autofac;
using QuizSystem.Data;
using QuizSystem.Repository;

namespace QuizSystem
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            //builder.RegisterType<ExamService>().As<IExamService>().InstancePerLifetimeScope();

        }
    }
}
