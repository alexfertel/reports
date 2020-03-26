using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Dynamic
{
    public class Prototype: DynamicObject
    {
        private Dictionary<string, dynamic> _dictionary = new Dictionary<string, dynamic>();

        public override bool TryGetMember(GetMemberBinder binder, out dynamic result)
        {
            return _dictionary.TryGetValue(binder.Name, out result);
        }
        
        public override bool TrySetMember(SetMemberBinder binder, dynamic value)
        {
            _dictionary[binder.Name] = value;
            return true;
        }

        public Prototype BlendWith(Prototype other)
        {
            var prototype = new Prototype();

            foreach (var (key, value) in _dictionary)
                prototype._dictionary[key] = (Action) (() => value(prototype));

            foreach (var (key, value) in other._dictionary)
                prototype._dictionary[key] = (Action) (() => value(prototype));

            return prototype;
        }

        public Prototype Clone()
        {
            return new Prototype{_dictionary = _dictionary};
        }
    }
}