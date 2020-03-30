using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace testing_dinamic
{
    public class Prototype : DynamicObject, ICloneable
    {
        Dictionary<string, object> dictionary_fun = new Dictionary<string, object>();
        Dictionary<string, object> dictionary_prop = new Dictionary<string, object>();
        public int Count_fun { get { return dictionary_fun.Count; } }
        public int Count_prop { get { return dictionary_prop.Count; } }
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return dictionary_prop.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            try
            {
                var function = ((Delegate)value);
                dictionary_fun[binder.Name] = value;
            }
            catch
            {
                dictionary_prop[binder.Name] = value;
            }
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = null;
            object fun;
            if(dictionary_fun.TryGetValue(binder.Name, out fun))
            {
                var function = ((Delegate)fun);
                var param = function.Method.GetParameters();
                object[] arguments = new object[param.Length];
                int j = 0;
                for(int i = 0; i < param.Length; i++)
                {
                    if(param[i].Name.ToLower() == "self")
                    {
                        arguments[i] = this;
                    }
                    else
                    {
                        if(j >= args.Length)
                        {
                            throw new ArgumentException ("Insuficient Arguments");
                        }
                        arguments[i] = args[j++];
                    }
                }
                
                result = function.DynamicInvoke(arguments);
                return true;
            }
            return false;
        }

        public Prototype BlendWith(Prototype other)
        {  
            Prototype proto = new Prototype();
            proto.dictionary_fun = new Dictionary<string, object>(this.dictionary_fun);
            
            foreach(var item in other.dictionary_fun)
                if(!this.dictionary_fun.ContainsKey(item.Key))
                    proto.dictionary_fun.Add(item.Key,item.Value);
            
            return proto;
        }

        public object Clone()
        {
            Prototype proto = new Prototype();
            proto.dictionary_fun = dictionary_fun;
            proto.dictionary_prop = new Dictionary<string, object>();
            return proto;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            dynamic person2 = new Prototype();


            person2.frase = "GUATYYYYY";
            person2.A = (Action<dynamic>)((self) => Console.WriteLine("Name is '{0}'", self.frase));
            person2.A();

            dynamic person1 = person2.Clone();
            person1.frase = "CARMEN";
            person1.A();

            dynamic person3 = new Prototype();
            person3.MetodoB = (Action<dynamic>)((self) => Console.WriteLine("Metodo B dice '{0}'", self.frase));
            person3.frase = "Soy la person3";
            person3.MetodoB();

            dynamic obj = person3.BlendWith(person2);
            obj.frase="Union";
            obj.A();
            obj.MetodoB();
            
        }
    }
}
