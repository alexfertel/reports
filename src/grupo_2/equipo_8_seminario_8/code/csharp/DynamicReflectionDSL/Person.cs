using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CSharp.DynamicReflectionDSL
{
    class Person : DynamicObject
    {
        private Dictionary<string, object> fields = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return this.fields.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.fields[binder.Name] = value;
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            return this.fields.TryGetValue(indexes[0] as string, out result);
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            this.fields[indexes[0] as string] = value;
            return true;
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            for (int i = 0; i < args.Length; i++)
                this.fields[binder.CallInfo.ArgumentNames[i]] = args[i];

            result = this;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            this.fields[binder.Name] = args[0];
            result = this;
            return true;
        }

        public override string ToString()
        {
            var result = "{\n";
            result += "  <Person>\n";
            foreach (var item in this.fields)
                result += string.Format(
                    "  {0}: {1}\n",
                    item.Key,
                    item.Value
                    .ToString()
                    .Replace("\n", "\n  ")
                );
            return result + "}";
        }
    }
}