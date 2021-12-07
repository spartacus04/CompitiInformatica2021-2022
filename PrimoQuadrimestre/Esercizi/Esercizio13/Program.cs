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
                for (int i = 0; i < code.Length; i++)
                {
                    for (int j = 0; j < code.Length - 1; j++)
                    {
                        if(code[j] > code[j + 1]) {
                            int temp = code[j];
                            code[j] = code[j + 1];
                            code[j + 1] = temp;

                            char temp2 = name[j];
                            name[j] = name[j + 1];
                            name[j + 1] = temp2;

                        }
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
                string code = Console.ReadLine().Trim();

                string[] codes = code.Split(' ', StringSplitOptions.TrimEntries);

                int[] code_int = new int[codes.Length];
                for (int i = 0; i < codes.Length; i++)
                {
                    code_int[i] = int.Parse(codes[i]);
                }

                Agent agent = new Agent(name, code_int);

                Console.WriteLine("Il nome dell'agente è: " + agent.decode());

                Console.WriteLine("Vuoi continuare? (y/n)");
            } while (Console.ReadLine() == "y");
        }
    }
}
