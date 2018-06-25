using System.Collections.Generic;

namespace FluentBDD
{
    public class ScenarioContext
    {
        private readonly IDictionary<string, object> _context = new Dictionary<string, object>();

        public string Name { get; set; }

        public void Add<T>(T obj, string name = null)
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            _context.Add(name ?? typeof(T).FullName, obj);
        }

        public T Get<T>(string name = null)
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            return (T)_context[name ?? typeof(T).FullName];
        }
    }
}
