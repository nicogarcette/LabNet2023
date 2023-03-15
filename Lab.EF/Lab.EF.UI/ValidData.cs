using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI {
    public class ValidData {

        public int AskForNumber() {

            int id = 0;
            bool valid = false;

            while (!valid) {
                Console.Write("ID:");
                valid = int.TryParse(Console.ReadLine(), out id);

                if (!valid) Console.WriteLine("Por favor, solo numeros!");
            }

            return id;
        }

        public string AskForString(string txt) {
           
            string data = Console.ReadLine();

            while (string.IsNullOrEmpty(data)) {
                Console.Write($"Campo vacio. Ingrese {txt}: ");
                data = Console.ReadLine();
            }

            return data;
        }
    }
}
