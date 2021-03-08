using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Office.Interop.Excel;
using Microsoft.Scripting.Hosting;

namespace ConsoleApp1
{
    class Program
    {
        private static int CountImpl<T>(ICollection<T> collection)
        {
            return collection.Count;
        }
        private static int CountImpl(ICollection collection)
        {
            return collection.Count;
        }
        private static int CountImpl(string text)
        {
            return text.Length;
        }
        private static int CountImpl(IEnumerable collection)
        {
            int count = 0;
            foreach (object item in collection)
            {
                count++;
            }
            return count;
        }
        public static void PrintCount(IEnumerable collection)
        {
            dynamic d = collection;
            int count = CountImpl(d);
            Console.WriteLine(count);
        }
        static void Main(string[] args){
            // DLR Examples
            // Aunque no es objetivo profundizar en que hace cada elemento usado en estos ejemplos se dara un poco de contexto para ayudar 
            // a entenderlo mejor. Si tienen dudas recomendamos leer el libro de la Bibliografia de nuestro Seminario, que fue de donde 
            // sacamos todos estos ejemplos.

            #region dynamic usage
            //dynamic dyn = 1;
            //object obj = 1;

            // Ponga el puntero encima de dyn o obj para ver su tipo en tiempo de compilacion

            //dyn = dyn + 3;
            //obj = obj + 3;

            //Console.WriteLine(dyn.GetType());
            //Console.WriteLine(obj.GetType());
            #endregion

            #region Simple dynamic example
            // Using dynamic to iterate through a list, concatenating strings
            //dynamic items = new List<string> { "First", "Second", "Third" };
            //dynamic valueToAdd = "!";
            //foreach (dynamic item in items)
            //{
            //    string result = item + valueToAdd;
            //    Console.WriteLine(result);
            //}

            // Adding integers to strings dynamically
            //dynamic items = new List<string> { "First", "Second", "Third" };
            //dynamic valueToAdd = 2;
            //foreach (dynamic item in items)
            //{
            //    string result = item + valueToAdd;
            //    Console.WriteLine(result);
            //}

            //Adding integers to integers
            //dynamic items = new List<int> { 1, 2, 3 };
            //dynamic valueToAdd = 2;
            //foreach (dynamic item in items)
            //{
            //    string result = item + valueToAdd; // Exception, no existe conversion de int a string. RuntimeBinderException
            //    Console.WriteLine(result);
            //}

            // Puede arreglarse simplemente cambiando result a dynamic, o quitando result y pasandole a Console.WriteLine() direcamente
            // item + valueToAdd.

            #endregion

            #region DLR example Usage

            #region COM, Microsoft Excel Example
            // Setting a range of values with static typing
            /* Aqui lo que estamos haciendo es escribir en las primeras 20 casillas de la primera fila de un Excel 1, 2, 3 .... 20
             * Lo importante a notar aqui es que aunque se ve relativamente claro, es que este ejemplo es muy sencillo y sin embargo,
             * hemos tenido que usar 3 casts en 6 lineas de codigo un codigo muy simple. */

            //var app = new Application { Visible = true };
            //app.Workbooks.Add();
            //Worksheet worksheet = (Worksheet)app.ActiveSheet;
            //Range start = (Range)worksheet.Cells[1, 1];
            //Range end = (Range)worksheet.Cells[1, 20];
            //worksheet.Range[start, end].Value = Enumerable.Range(1, 20)
            //.ToArray();

            /* Como estamos usando el ensamblado de interoperabilidad (gracias a DLR) configurado para añadir los tipos necesarios en 
             * nuestro propio binario, todos estos ejemplos se vuelven dinámicos. Con la conversión implícita de dinámico a otros tipos, 
             * simplemente podemos eliminar todos los casteos, asi que esto funciona. */

            //var app = new Application { Visible = true };
            //app.Workbooks.Add();
            //Worksheet worksheet = app.ActiveSheet;
            //Range start = worksheet.Cells[1, 1];
            //Range end = worksheet.Cells[1, 20];
            //worksheet.Range[start, end].Value = Enumerable.Range(1, 20)
            //.ToArray();

            #endregion

            #region IronPython
            // Printing “hello, world” twice using Python embedded in C#

            //ScriptEngine engine = Python.CreateEngine();
            //engine.Execute("print 'hello, world'");
            //engine.ExecuteFile("HelloWorld.py");

            /* Esto puede parecer como algo muy sorprendente o no. No lleva explicacion es algo muy sencillo en cuanto a lo que hace, 
             * sin embargo que sea tan sencillo incluir codigo de Python en C# es soprendente.
             */


            // Ejemplo algo mas util, como guardar y recuperar informacion de un ScriptScope
            //            string python = @"
            //text = 'hello'
            //output = input + 1
            //";
            //            ScriptEngine engine = Python.CreateEngine();
            //            ScriptScope scope = engine.CreateScope();
            //            scope.SetVariable("input", 10);
            //            engine.Execute(python, scope);
            //            Console.WriteLine(scope.GetVariable("text"));
            //            Console.WriteLine(scope.GetVariable("input"));
            //            Console.WriteLine(scope.GetVariable("output"));

            // Los metodos SetVariable y GetVariable simplemente ponen valores en el scope y los sacan respectivamente. Pero GetVariable 
            // también te permite especificar un argumento tipo, que actúa como una solicitud de conversión. Por ejemplo.

            //scope.SetVariable("num", 20); // Colocamos una variable en el scope
            //double x = scope.GetVariable<double>("num"); // Aqui se logra una conversion satisfactoria
            //double y = (double)scope.GetVariable("num"); // Unboxing lanza excepcion
            #endregion

            #region MULTIPLE DISPATCH

            //PrintCount(new BitArray(5));
            //PrintCount(new HashSet<int> { 1, 2 });
            //PrintCount("ABC");
            //PrintCount("ABCDEF".Where(c => c > 'B'));


            #endregion

            #endregion

            #region Excersice 4
            //string text = "text to cut";
            //dynamic startIndex = 2;
            //string substring = text.Substring(startIndex);
            #endregion

            #region Expando Object Example
            //dynamic sampleObject = new ExpandoObject();

            //sampleObject.test = "Dynamic Property";
            //Console.WriteLine(sampleObject.test);
            //Console.WriteLine(sampleObject.test.GetType());
            // This code example produces the following output:
            // Dynamic Property
            // System.String

            //sampleObject.number = 10;
            //sampleObject.Increment = (Action)(() => { sampleObject.number++; });

            // Before calling the Increment method.
            //Console.WriteLine(sampleObject.number);

            //sampleObject.Increment();

            // After calling the Increment method.
            //Console.WriteLine(sampleObject.number);
            // This code example produces the following output:
            // 10
            // 11
            #endregion

            #region Dynamic Object Example
            // Creating a dynamic dictionary.

            //dynamic person = new DynamicDictionary();

            // Adding new dynamic properties. 
            // The TrySetMember method is called.

            //person.FirstName = "Ellen";
            //person.LastName = "Adams";

            // Getting values of the dynamic properties.
            // The TryGetMember method is called.
            // Note that property names are case-insensitive.
            
            //Console.WriteLine(person.firstname + " " + person.lastname);

            // Getting the value of the Count property.
            // The TryGetMember is not called, 
            // because the property is defined in the class.
            
            //Console.WriteLine(
            //    "Number of dynamic properties:" + person.Count);

            // The following statement throws an exception at run time.
            // There is no "address" property,
            // so the TryGetMember method returns false and this causes a
            // RuntimeBinderException.
            
            // Console.WriteLine(person.address);

            // This example has the following output:
            // Ellen Adams
            // Number of dynamic properties: 2
            #endregion

            Console.ReadLine();
        }
        // The class derived from DynamicObject.
        public class DynamicDictionary : DynamicObject{
            // The inner dictionary.
            Dictionary<string, object> dictionary
                = new Dictionary<string, object>();

            // This property returns the number of elements
            // in the inner dictionary.
            public int Count{
                get{
                    return dictionary.Count;
                }
            }

            // If you try to get a value of a property 
            // not defined in the class, this method is called.
            public override bool TryGetMember(
                GetMemberBinder binder, out object result){
                // Converting the property name to lowercase
                // so that property names become case-insensitive.
                string name = binder.Name.ToLower();

                // If the property name is found in a dictionary,
                // set the result parameter to the property value and return true.
                // Otherwise, return false.
                return dictionary.TryGetValue(name, out result);
            }

            // If you try to set a value of a property that is
            // not defined in the class, this method is called.
            public override bool TrySetMember(
                SetMemberBinder binder, object value){
                // Converting the property name to lowercase
                // so that property names become case-insensitive.
                dictionary[binder.Name.ToLower()] = value;

                // You can always add a value to a dictionary,
                // so this method always returns true.
                return true;
            }
        }

    }
}
