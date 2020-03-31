using System;
using System.Collections.Generic;

namespace Seminario9 {
    public interface ITalk {
    }

    public static class TalkImpl {
        private static Dictionary<ITalk, string> States = new Dictionary<ITalk, string>();

        public static void Talk(this ITalk t) {
            if (States.ContainsKey(t)) {
                string state = States[t];
                if (state.Equals("Hola")) {
                    Console.WriteLine("Adiós");
                    States[t] = "Adiós";
                    return;
                }
            }

            Console.WriteLine("Hola");
            States[t] = "Hola";
        }
    }

    public class Talker : ITalk {
    }
}