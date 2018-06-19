using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBDD
{
    public class ScenarioContext
    {
        private IDictionary<string, object> _context = new Dictionary<string, object>();

        public string Name { get; set; }

        public void Add<T>(T obj, string name = null)
        {
            _context.Add(name ?? typeof(T).FullName, obj);
        }

        public T Get<T>(string name = null)
        {
            return (T)_context[name ?? typeof(T).FullName];
        }
    }
}
