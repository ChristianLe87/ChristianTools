using System;
using System.Collections.Generic;
using System.Linq;

namespace ChristianTools.Components
{
    public class Components
    {
        Dictionary<string, object> components = new Dictionary<string, object>();

        public T Get<T>(string key)
        {
            return (T)components[key];
        }

        public void Add<T>(string key, T value)
        {
            components.Add(key, (T)value);
        }

        public void Set<T>(string key, T value)
        {
            components[key] = (T)value;
        }

        public bool Exist(string key)
        {
            return components.Keys.Contains(key);
        }

        public void Remove(string key)
        {
            components.Remove(key);
        }
    }
}