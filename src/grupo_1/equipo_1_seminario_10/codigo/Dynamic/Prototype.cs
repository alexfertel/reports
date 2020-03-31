using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Dynamic
{
    public class Prototype: DynamicObject, ICloneable, ICopiable
    {
        private Dictionary<string, dynamic> _memberDictionary = new Dictionary<string, dynamic>();
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _memberDictionary.TryGetValue(binder.Name, out result);
        }
        
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _memberDictionary[binder.Name] = value;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            args = new object[] {this}.Concat(args).ToArray();
            result = _memberDictionary[binder.Name].DynamicInvoke(args);
            return true;
        }

        public Prototype BlendWith(Prototype other)
        {
            var prototype = new Prototype();

            foreach (var pair in _memberDictionary)
                prototype._memberDictionary[pair.Key] = pair.Value;

            foreach (var pair in other._memberDictionary)
                prototype._memberDictionary[pair.Key] = pair.Value;

            return prototype;
        }

        public object Clone()
        {
            return ShallowCopy();
        }

        public object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public object DeepCopy()
        {
            var prototype = (Prototype) MemberwiseClone();
            prototype._memberDictionary = new Dictionary<string, dynamic>(_memberDictionary);
            return prototype;
        }
    }
}