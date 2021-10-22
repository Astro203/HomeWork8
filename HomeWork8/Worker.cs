using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork8
{
    class Worker
    {
        public Worker(int TabNumber, string LastName, string FirstName, int Age, string Dep, int Salary)
        {
            this.tabNumber = TabNumber;
            this.lastName = LastName;
            this.firstName = FirstName;
            this.age = Age;
            this.dep = Dep;
            this.salary = Salary;
        }
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int tabNumber { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string lastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string firstName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int age { get; set; }
        /// <summary>
        /// Департамент
        /// </summary>
        public string dep { get; set; }
        /// <summary>
        /// Заработная плата
        /// </summary>
        public int salary { get; set; }

        public static bool CreateWorker(bool create)
        {
            Console.Clear();
            int numberWorkers = 0;
            Random rand = new Random();
            List<Departament> Departaments = new List<Departament>();
            List<Worker> Workers = new List<Worker>();
            string json = "";
            if (!create && Departaments.Count >= 1)
            {
                for (int i = 0; i < Departaments.Count; i++) numberWorkers += Departaments[i].numberWorkers;
                Console.WriteLine($"Количество сотрудников: {numberWorkers}");
            }
            else
            {
                if (File.Exists("Workers.json"))
                {
                    json = File.ReadAllText("Departaments.json");
                    Departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
                }
                else
                {
                    Console.WriteLine("Добавьте департаменты");
                    Console.ReadKey();
                    return false;
                }
                Console.Write("Количество сотрудников: "); numberWorkers = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            try
            {
                json = File.ReadAllText("Workers.json");
                Workers = JsonConvert.DeserializeObject<List<Worker>>(json);
                for (int i = 1; i <= numberWorkers; i++)
                {
                    Console.Write("Идентификатор сотрудника: "); string tabWorker = Console.ReadLine();
                    Console.Write("Фамилия: "); string lastName = Console.ReadLine();
                    Console.Write("Имя: "); string firstname = Console.ReadLine();
                    Console.Write("Возраст: "); string age = Console.ReadLine();
                    string departament = Departaments[rand.Next(1, Departaments.Count)].depName;
                    Console.Write("Заработная плата: "); string salary = Console.ReadLine();
                    Console.WriteLine();
                    Workers.Add(
                        new Worker(
                            int.Parse(tabWorker),
                            lastName,
                            firstname,
                            int.Parse(age),
                            departament,
                            int.Parse(salary)));
                }
                create = true;
                json = JsonConvert.SerializeObject(Workers);
                File.WriteAllText("Workers.json", json);
            }
            catch { Console.WriteLine("Во введенных данных ошибка"); Console.ReadKey(); }
            return true;
            Console.ReadKey();
        }

        public static void DeleteWorker()
        {
            Console.Clear();
            string json = "";
            List<Worker> Workers = new List<Worker>();
            json = File.ReadAllText("Workers.json");
            Workers = JsonConvert.DeserializeObject<List<Worker>>(json);
            int k = 1;
            Console.WriteLine("№   Таб.номер Фамилия    Имя     Возраст  Департамент   Зарплата");
            foreach (var item in Workers)
            {
                Console.WriteLine($"{item.tabNumber,4}{item.lastName,11}{item.firstName,11}{item.age,5}{item.dep,20}{item.salary,6}");
            }
            Console.WriteLine();
            Console.Write("Выберите идентификатор сотрудника: "); int tabNumber = int.Parse(Console.ReadLine());
            try
            {
                Workers.RemoveAll(x => x.tabNumber == tabNumber);
            }
            catch { Console.WriteLine("Нет совпадений"); }
            json = JsonConvert.SerializeObject(Workers);
            File.WriteAllText("Workers.json", json);
            Console.ReadKey();
        }

        public static void EditWorker()
        {
            Console.Clear();
            int m = 1;
            bool exitEditWorkers = false;
            string json = "";
            List<Worker> Workers = new List<Worker>();
            json = File.ReadAllText("Workers.json");
            Workers = JsonConvert.DeserializeObject<List<Worker>>(json);
            Console.WriteLine("№   Таб.номер Фамилия    Имя     Возраст  Департамент   Зарплата");
            foreach (var item in Workers)
            {
                Console.WriteLine($"{item.tabNumber,4}{item.lastName,11}{item.firstName,11}{item.age,5}{item.dep,20}{item.salary,6}");
            }
            Console.WriteLine();
            Console.Write("Выберите номер строки для редактирования"); int n = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("Выберите поле:\n" +
                    "1 - идентификатор, 2 - фамилия, 3 - имя, 4 - возраст, 5 - департамент, 6 - зарплата");
                int fieldEditDepartament = int.Parse(Console.ReadLine());
                switch (fieldEditDepartament)
                {
                    case 1:
                        Console.Write("Введите идентификатор: "); int newTabNumber = int.Parse(Console.ReadLine());
                        Workers[n - 1].tabNumber = newTabNumber;
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Введите фамилию: "); string newLastName = Console.ReadLine();
                        Workers[n - 1].lastName = newLastName;
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Введите имя: "); string newFirstName = Console.ReadLine();
                        Workers[n - 1].firstName = newFirstName;
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("Введите возраст: "); int newAge = int.Parse(Console.ReadLine());
                        Workers[n - 1].age = newAge;
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Write("Введите департамент: "); string newDepartament = Console.ReadLine();
                        Workers[n - 1].dep = newDepartament;
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Write("Введите зарплату: "); int newSalary = int.Parse(Console.ReadLine());
                        Workers[n - 1].salary = newSalary;
                        Console.ReadKey();
                        break;
                    default:
                        exitEditWorkers = true;
                        break;
                }
            } while (!exitEditWorkers);
            json = JsonConvert.SerializeObject(Workers);
            File.WriteAllText("Workers.json", json);
            Console.ReadKey();
        }

        public static void SortWorkers()
        {
            Console.Clear();
            Console.WriteLine("Поля для сортировки работников: идентификатор, фамилия, имя, возраст, департамент, зарплата");
            Console.Write("Выберите поле для сортировки: "); string fieldNameOfWorkers = Console.ReadLine();
            string json = "";
            List<Worker> Workers = new List<Worker>();
            json = File.ReadAllText("Workers.json");
            Workers = JsonConvert.DeserializeObject<List<Worker>>(json);
            if (fieldNameOfWorkers == "идентификатор")
            {
                Workers.Sort((x, y) => (((IComparable)x.tabNumber).CompareTo(y.tabNumber)));
            }
            if (fieldNameOfWorkers == "фамилия")
            {
                Workers.Sort((x, y) => (((IComparable)x.lastName).CompareTo(y.lastName)));
            }
            if (fieldNameOfWorkers == "имя")
            {
                Workers.Sort((x, y) => (((IComparable)x.firstName).CompareTo(y.firstName)));
            }
            if (fieldNameOfWorkers == "возраст")
            {
                Workers.Sort((x, y) => (((IComparable)x.age).CompareTo(y.age)));
            }
            if (fieldNameOfWorkers == "департамент")
            {
                Workers.Sort((x, y) => (((IComparable)x.dep).CompareTo(y.dep)));
            }
            if (fieldNameOfWorkers == "зарплата")
            {
                Workers.Sort((x, y) => (((IComparable)x.salary).CompareTo(y.salary)));
            }
            json = JsonConvert.SerializeObject(Workers);
            File.WriteAllText("Workers.json", json);
            foreach (var item in Workers)
            {
                Console.WriteLine($"{item.tabNumber,4}{item.lastName,11}{item.firstName,11}{item.age,5}{item.dep,20}{item.salary,6}");
            }
            Console.ReadKey();
        }
    }
}
