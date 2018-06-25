using Autofac;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace FluentBDD
{
    public class Scenario
    {
        private static readonly List<Type> Types = new List<Type>();
        
        public static void RegisterType<T>()
        {
            Types.Add(typeof(T));
        }

        public static Scenario Create([CallerMemberName]string name = null)
        {
            return new Scenario(name);
        }

        private readonly IContainer _container;
        private readonly IStepFormatter _stepFormatter;

        private Scenario(string name)
        {
            WriteToTestOutput($"Scenario: {name}");
            
            var containerBuilder = new ContainerBuilder();
            foreach (var type in Types)
                containerBuilder.RegisterType(type);
            containerBuilder.RegisterInstance(new ScenarioContext
            {
                Name = name
            });
            _container = containerBuilder.Build();
            _stepFormatter = new StepFormatter();
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

        private static void WriteToTestOutput(string message)
        {
            Console.WriteLine($"-> {message}");
        }
    }
}
