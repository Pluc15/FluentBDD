using System;
using System.Linq.Expressions;

namespace FluentBDD
{
    public interface IStepFormatter
    {
        string Format<TStep>(Expression<Action<TStep>> exp);
    }
}