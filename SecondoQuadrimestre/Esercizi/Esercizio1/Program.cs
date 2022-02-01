using System;

namespace Esercizio1
{
	struct Student {
		public string name;
		public int year;
		public int sufficientExams;
		public int[] grades;
	}
    class Program
    {
        static void Main(string[] args)
        {
			// Creo un array di studenti con lunghezza in input (max 100 elementi)
			int n;
			do
			{
				Console.WriteLine("Inserisci il numero degli studenti (max: 100)");
				n = int.Parse(Console.ReadLine());
			} while (n < 0 || n > 100);

			Student[] students = new Student[n];

			loadArr(students);

			while(true) {
				switch(menu()) {
					case 1:
						loadArr(students);
						break;
					case 2:
						Console.WriteLine("Inserisci il numero dello studente ");
						int index = int.Parse(Console.ReadLine());

						if (index < 1 || index > n)
							Console.WriteLine("Numero non valido");
						else
							Console.WriteLine("Media studente " + index + ":" + studentAverage(students[index - 1]));

						break;
					case 3:
						Console.WriteLine("Media di tutti gli studenti");
						for (int i = 0; i < students.Length; i++)
						{
							Console.WriteLine("Media studente " + (i + 1) + ":" + studentAverage(students[i]));
						}
						break;
					case 4:
						Student[] over20Exams = filterOverExamsNumber(students);

						Console.WriteLine("Studenti con più di 20 esami:");
						for (int i = 0; i < over20Exams.Length; i++)
						{
							Console.WriteLine("Student " + (i + 1) + ":" + over20Exams[i].name);
						}
						break;
					case 5:
						Console.WriteLine("Scegli un anno");
						int year = int.Parse(Console.ReadLine());

						if(year < 1 || year > 3)
							Console.WriteLine("Anno non valido");
						else 
							Console.WriteLine("Le persone iscritte all'anno " + year + " sono: " + subscribedToYear(students, year));

						break;
					case 6:

						for (int i = 0; i < 3; i++)
						{
							Console.WriteLine("Le persone iscritte all'anno " + (i + 1) + " sono: " + subscribedToYear(students, i + 1));
						}

						break;
					case 7:
						Console.WriteLine("Inserisci il numero dello studente ");
						int index2 = int.Parse(Console.ReadLine());

						lastGrade(students[index2 - 1]);
						break;
					case 8:
						removeFinishedStudents(ref students);
						break;
					case 9:
						return;
				}
			}
        }

		static void loadArr(Student[] students) {
			Random random = new Random();
			for (int i = 0; i < students.Length; i++) {
				Console.WriteLine("Inserisci il nome e cognome dello studente");
				students[i].name = Console.ReadLine();

				Console.WriteLine("Inserisci l'anno dello studente");
				students[i].year = random.Next(1, 4);

				Console.WriteLine("Inserisci il numero di esami superati");
				students[i].sufficientExams = random.Next(1, 26);

				Console.WriteLine("Inserisci i voti dello studente");
				students[i].grades = new int[25];
				for (int j = 0; j < students[i].grades.Length; j++) {
					students[i].grades[j] = random.Next(18, 32);
				}

				Console.WriteLine("\nLo studente " + students[i].name + " ha registrato i seguenti dati:");
				Console.WriteLine("Anno: " + students[i].year);
				Console.WriteLine("Esami superati: " + students[i].sufficientExams);
				Console.WriteLine("Voti: ");
				for (int j = 0; j < students[i].grades.Length; j++) {
					Console.Write(students[i].grades[j] + " ");
				}
				Console.WriteLine("\n");
			}
		}

		static int menu() {
			Console.WriteLine("\n");
			Console.WriteLine("1) Ricaricamento dei dati");
			Console.WriteLine("2) Visualizzazione della media di uno studente");
			Console.WriteLine("3) Elenco delle medie di tutti gli studenti");
			Console.WriteLine("4) Stampa di un vettore con studenti che hanno superato almeno 20 esami");
			Console.WriteLine("5) Visualizzazione del numero di studenti iscritti ad un determinato anno");
			Console.WriteLine("6) Visualizzazione del numero di studenti iscritti ai vari anni");
			Console.WriteLine("7) Visualizzazione dell'ultimo voto di uno studente");
			Console.WriteLine("8) Rimuovere tutti gli studenti che hanno superato tutti gli esami");
			Console.WriteLine("9) Esci\n");


			int n;
			do
			{
				Console.WriteLine("Inserisci il numero dell'operazione da eseguire");
				n = int.Parse(Console.ReadLine());
			} while (n < 0 || n > 9);

			return n;

		}
    
		static float studentAverage(Student student) {
			float sum = 0;
			for (int i = 0; i < student.grades.Length; i++) {
				sum += student.grades[i];
			}
			return sum / student.grades.Length;
		}

		static Student[] filterOverExamsNumber(Student[] students) {
			Student[] overExamThreshold = new Student[students.Length];
			int index = 0;
			for (int i = 0; i < students.Length; i++)
			{
				if (students[index].sufficientExams >= 20)
					overExamThreshold[i++] = students[index];
			}

			// Resize array
			Student[] overExamThreshold2 = new Student[index];
			for (int i = 0; i < overExamThreshold2.Length; i++)
			{
				overExamThreshold2[i] = overExamThreshold[i];
			}

			return overExamThreshold2;
		}
	
		static int subscribedToYear(Student[] students, int year) {
			int count = 0;
			for (int i = 0; i < students.Length; i++)
			{
				if (students[i].year == year)
					count++;
			}
			return count;
		}

		static void lastGrade(Student student) {
			if(student.sufficientExams == 25) return;
			student.sufficientExams++;
			int grade;
			do
			{
				Console.WriteLine("Inserisci il nuovo voto dello studente");
				grade = int.Parse(Console.ReadLine());
			} while (grade < 18 || grade > 31);
			student.grades[student.sufficientExams - 1] = grade;
		}

		static void removeFinishedStudents(ref Student[] students) {
			int length = 0;
			for (int i = 0; i < students.Length; i++)
			{
				if (students[i].sufficientExams < 25) {
					length++;
				}
				else {
					students[i].name = "";
				}
			}

			Student[] students2 = new Student[length];

			for (int i = 0, j = 0; i < students.Length || j < length; i++)
			{
				if (students[i].name != "") {
					students2[j++] = students[i];
				}	
			}

			students = students2;
		}
	}

}
