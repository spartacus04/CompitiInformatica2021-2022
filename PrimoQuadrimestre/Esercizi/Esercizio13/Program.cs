using System;


namespace Esercizio13
{
    class Program
    {
        struct Agent {
            public char[] name;
            public int[] code;

            public Agent(string name, int[] code) {
                this.name = name.ToCharArray();
                this.code = code;
            }

            public string decode() {
                // Bubblesort name e code
                for (int i = 0; i < name.Length - 1; i++) {
                    if (name[i] > name[i + 1]) {
                        char temp = name[i];
                        name[i] = name[i + 1];
                        name[i + 1] = temp;

                        int temp2 = code[i];
                        code[i] = code[i + 1];
                        code[i + 1] = temp2;
                    }
                }

                return new string(name);  
            }
        }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Inserisci il nome in codice dell'agente");
                string name = Console.ReadLine();

                Console.WriteLine("Inserisci la chiave dell'agente (separato da spazi)");
                string code = Console.ReadLine();

                string[] codes = code.Split(' ', StringSplitOptions.TrimEntries);

                int[] code_int = new int[codes.Length];
                for (int i = 0; i < codes.Length; i++)
                {
                    code_int[i] = int.Parse(codes[i]);
                }

                Agent agent = new Agent(name, code_int);

                Console.WriteLine("Il nome dell'agente è: " + agent.decode());

                Console.WriteLine("Vuoi continuare? (y/n)");
            } while (Console.ReadLine() == "y" || Console.ReadLine() == "Y");
        }
    }
}
