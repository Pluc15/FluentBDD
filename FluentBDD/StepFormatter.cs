using System;
using System.Linq.Expressions;

namespace FluentBDD
{
    public class StepFormatter : IStepFormatter
    {
        public string Format<TStep>(Expression<Action<TStep>> exp)
        {
            var methodCall = exp.Body.ToString();
            return methodCall.Substring(methodCall.IndexOf('.') + 1);
        }
    }
}
