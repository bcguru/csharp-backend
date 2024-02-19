using Autofac;
using Backend.Services;
using Backend.Model;
using System.Collections.Generic;
using log4net;
using log4net.Config;
using System;

namespace Backend
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            try
            {
                BasicConfigurator.Configure();
                var container = ConfigureContainer();

                // Get your application menu class
                var application = container.Resolve<ApplicationService>();

                // Run your application
                application.Run();
            }
            catch (Exception ex)
            {
                _log.Error("An error occurred while running the application", ex);
                throw;  // Re-throw the exception
            }
        }

        //You should configure DI container (Autofac) or other DI Framework
        private static IContainer ConfigureContainer()
        {
            try
            {
                var builder = new ContainerBuilder();

                // Here you should register Interfaces with their referent classes
                builder.RegisterType<MovieStarService>().As<IMovieStarService>();
                builder.RegisterType<ApplicationService>()
                    .UsingConstructor(typeof(IMovieStarService), typeof(ISalaryService));
                // Register ITaxMethod implementations
                builder.RegisterType<FlatTax>().As<ITaxMethod>();
                // Register new TaxMethod Class in here

                // Register SalaryService with a list of ITaxMethod
                builder.RegisterType<SalaryService>()
                    .WithParameter(
                       (pi, ctx) => pi.ParameterType == typeof(IEnumerable<ITaxMethod>),
                       (pi, ctx) => ctx.Resolve<IEnumerable<ITaxMethod>>()
                    )
                    .As<ISalaryService>();

                return builder.Build();
            }
            catch (Exception ex)
            {
                _log.Error("An error occurred while configuring the container", ex);
                throw;
            }
        }
    }
}
