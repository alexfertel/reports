using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupBy
{
    public class Group<TKey, TSource> : IGrouping<TKey, TSource>
    {
        public TKey Key { get; private set; }
        private IEnumerable<TSource> Source;

        public Group(TKey key, IEnumerable<TSource> source)
        {
            Key = key;
            Source = source;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return Source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class MetodosExtensores
    {
        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>(
                            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TKey> keys_used = new List<TKey>();
            List<IGrouping<TKey, TSource>> groups = new List<IGrouping<TKey, TSource>>();

            foreach (var item in source)
            {
                TKey key = keySelector(item);
                if (!keys_used.Contains(key))
                {
                    keys_used.Add(key);

                    Group<TKey, TSource> group = new Group<TKey, TSource>(key,
                                            source.Where(i => key.Equals(keySelector(i))));
                    groups.Add(group);
                }
            }

            return groups;
        }

        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupByLazy<TSource, TKey>(
                            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TKey> keys_used = new List<TKey>();

            foreach (var item in source)
            {
                TKey key = keySelector(item);
                if (!keys_used.Contains(key))
                {
                    keys_used.Add(key);
                    Group<TKey, TSource> group = new Group<TKey, TSource>
                                        (key, source.Where(i => key.Equals(keySelector(i))));
                    yield return group;
                }
            }
        }
    }

    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Group { get; private set; }
        public int Age { get; private set; }

        public Student(string name, string last_name, int group, int age)
        {
            FirstName = name;
            LastName = last_name;
            Group = group;
            Age = age;
        }

        public override string ToString()
        {
            return "Mi nombre es " + FirstName + " " + LastName + ", soy del grupo C-" + Group + " y tengo " + Age + " años.";
        }
    }

    class Program
    {    
        static void Main(string[] args)
        {
            List<Student> equipo6 = new List<Student>();

            Student yenli = new Student("Yenli", "Gil", 412, 22);
            equipo6.Add(yenli);
            Student yunior = new Student("Yunior", "Tejeda", 412, 24);
            equipo6.Add(yunior);
            Student jotica = new Student("Juan Jose", "Lopez", 311, 22);
            equipo6.Add(jotica);
            Student carlos = new Student("Carlos", "Martinez", 411, 23);
            equipo6.Add(carlos);
            Student ariel = new Student("Ariel", "Plasencia", 311, 23);
            equipo6.Add(ariel);

            // Consulta que devuelve los nombres agrupados por edad
            Console.WriteLine("Equipo 6 agrupados por edad");
            foreach (var item in equipo6.MyGroupBy(i => i.Age))
            {
                item.ToList().ForEach(i => Console.Write("{0} ", i.FirstName));
                Console.WriteLine();
            }
            Console.WriteLine();

            // Consulta que devuelve los nombres y apellidos agrupados por grupo
            Console.WriteLine("Equipo 6 agrupados por grupo");
            foreach (var item in equipo6.MyGroupByLazy((i => i.Group)))
            {
                item.ToList().ForEach(i => Console.Write("{0} {1} ", i.FirstName, i.LastName));
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
