using Autofac;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace FluentBDD
{
    public class Scenario
    {
        private static readonly ContainerBuilder ContainerBuilder = new ContainerBuilder();

        public static void RegisterType<T>()
        {
            ContainerBuilder.RegisterType<T>();
        }

        public static Scenario Create([CallerMemberName]string name = null)
        {
            return new Scenario(name);
        }

        private readonly ScenarioContext _scenarioContext;
        private readonly IContainer _container;
        private readonly IStepFormatter _stepFormatter;

        private Scenario(string name)
        {
            _stepFormatter = new StepFormatter();
            _scenarioContext = new ScenarioContext
            {
                Name = name
            };
            ContainerBuilder.RegisterInstance(_scenarioContext);
            _container = ContainerBuilder.Build();

            WriteToTestOutput($"Scenario: {name}");
        }

        public Scenario Step<TStep>(Expression<Action<TStep>> exp)
        {
            WriteToTestOutput(_stepFormatter.Format(exp));
            try
            {
                exp.Compile()(_container.Resolve<TStep>());
            }
            catch
            {
                WriteToTestOutput("Failed!");
                throw;
            }
            return this;
        }

        private void WriteToTestOutput(string message)
        {
            Console.WriteLine($"-> {message}");
        }
    }
}
