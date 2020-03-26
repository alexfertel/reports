using System;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace CSharp.DynamicReflectionDSL
{
    class InstanceCreator : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Namespace == this.GetType().Namespace)
            .SingleOrDefault(t => t.Name == binder.Name);

            if (type == null)
            {
                result = null;
                return false;
            }

            result = Activator.CreateInstance(type);
            return true;
        }
    }
}