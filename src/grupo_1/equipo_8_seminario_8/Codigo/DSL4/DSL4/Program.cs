using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Reflection;

namespace DSL4
{
    public class Factory
    {
        public static dynamic New
        {
            get { return new Create(); }

        }
    }

    public class Create: DynamicObject
    {
        Assembly myAss = Assembly.GetExecutingAssembly();//Se obtienen todas las clases, metodos, 
                                                          //propiedades del Ensablado en myAss
        public override bool TryGetMember(GetMemberBinder binder, out object result)//Usando Dynamic
        {
            Type[] myclasstype = myAss.GetTypes();//Se obtiene el acceso a los metadatos
            foreach (var item in myclasstype)
            {
                if(item.Name == binder.Name)//Si el typo se encuentra en el Assembly entonces 
                                            //guarda la instancia en el parametro de salida y devuelve true
                {
                    Type[] newtype = { };
                    result = Activator.CreateInstance(item);//crea una instancia del tipo item q se encuentra en el Ensamblado
                    return true;
                }
               
            }
            result = null;
            return false;
        }

    }

    public class Person: DynamicObject
    {
        public string FName;
        public string LName;

        public Dictionary<string, object> thisproperties = new Dictionary<string, object>();


        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var Name = binder.Name;
            if(thisproperties.ContainsKey(Name))
            {
                result = thisproperties[Name];
                return true;
            }
            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var Name = binder.Name;
            if (thisproperties.ContainsKey(Name))
                thisproperties[Name] = value;
            else
                thisproperties.Add(Name, value);
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            try
            {
                var Name = indexes[0].ToString();
                if (thisproperties.ContainsKey(Name))
                {
                    result = thisproperties[Name];
                    return true;
                }
                result = null;
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Solo se indexa en una dimension");
            }
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            try
            {
                var Name = indexes[0].ToString();
                if (thisproperties.ContainsKey(Name))
                    thisproperties[Name] = value;
                else
                    thisproperties.Add(Name, value);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Solo se indexa en una dimension");
            }
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            for (int i = 0; i < args.Length; i++)
            {
                thisproperties.Add(binder.CallInfo.ArgumentNames[i], args[i]);
            }
            result = this;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var Name = binder.Name;
            if (thisproperties.ContainsKey(Name))
            {
                if (args.Length > 1)
                    thisproperties[Name] = args;
                else
                    thisproperties[Name] = args[0];
                result = this;
                return true;
            }
            if (args.Length > 1)
                thisproperties.Add(Name, args);
            else
                thisproperties.Add(Name, args[0]);
            result = this;
            return true;


        }
        public override string ToString()
        {
            return "Nombre: " + FName + " | Apellido: " + LName;
        }
    }

    public class Estudiante
    {
        string name;
        int age;
        string discipline;
        // No se le puede definir constructor 
    

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Discipline
        {
            get
            {
                return discipline;
            }
            set
            {
                discipline = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public override string ToString()
        {
            return "Name: " + this.Name + " Edad: " + this.Age + " Discipline: " + this.Discipline;
        }
    }

    class Program
    {        
        static void Main(string[] args)
        {
            var p3 = Factory.New.Person(
                               FirstName: "Yami",
                               LastName: "Reynoso",
                               Ayudante:
                                   Factory.New.Person(
                                       FirstName: "Day",
                                       LastName: "Fundora"));
            Console.WriteLine("Nombre de la Persona: " + p3.FirstName + " | Apellido: " + p3.LastName);

            Console.WriteLine("Nombre del ayudante: " + p3.Ayudante.FirstName + " | Apellido: " + p3.Ayudante.LastName);


            var p4 = Factory.New.Person(FirstName: "Camilo", LastName: "Hurtado");
            Console.WriteLine("Nombre: " + p4.FirstName + " | Apellido: " + p4.LastName);
            var p1 = Factory.New.Person;
            p1.FirstName = "Gelin"; //Se invoca a TrySetMember
            p1.LastName = "Equinosa";
            Console.WriteLine("Nombre: " + p1.FirstName + " | Apellido: " + p1.LastName); // Se invoca a TryGetMember
            var p2 = Factory.New.Person;
            p2["FirstName"] = "Rafael"; //Se invoca a TrySetIndex
            p2["LastName"] = "Diaz";
            Console.WriteLine("Nombre: " + p2["FirstName"] + " | Apellido: " + p2["LastName"]);//Se invoca a TryGetIndex


            var p5 = Factory.New.Person.FirstName("Yami Day").LastName("Reyfun");
            Console.WriteLine("Nombre: " + p5.FirstName + " | Apellido: " + p5.LastName);

            var estudiante = Factory.New.Estudiante;
            estudiante.Age = 22;
            estudiante.Name = "Laura";
            estudiante.Discipline = "Ciencias de la Computacion";
            Console.WriteLine("Estudiante: " + estudiante);
        }
    }
}
