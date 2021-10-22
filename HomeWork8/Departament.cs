using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork8
{
    class Departament
    {

        public Departament(string DepName, DateTime DateCreate, int NumberWorkers)
        {
            this.depName = DepName;
            this.dateCreate = DateCreate;
            this.numberWorkers = NumberWorkers;
        }

        /// <summary>
        /// Наименование департамента
        /// </summary>
        public string depName { get; set; }
        /// <summary>
        /// Дата основания департамента
        /// </summary>
        public DateTime dateCreate { get; set; }
        /// <summary>
        /// Количество сотрудников в департаменте
        /// </summary>
        public int numberWorkers { get; set; }

        public static void CreateDepartament()
        {
            Console.Clear();
            List<Departament> Departaments = new List<Departament>();
            string json = "";
            json = File.ReadAllText("Departaments.json");
            Departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
            Console.Write("Сколько желаете добавить департаментов: "); int numberDepartament = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= numberDepartament; i++)
            {
                Console.Write("Введите название департамента: "); string nameDepartament = Console.ReadLine();
                Console.Write("Введите дату основания: "); string dateCreate = Console.ReadLine();
                Console.Write("Введите количество сотрудников в департаменте: "); string numberWorkersInDepartament = Console.ReadLine();
                Departaments.Add(
                    new Departament(
                        nameDepartament,
                        Convert.ToDateTime(dateCreate),
                        int.Parse(numberWorkersInDepartament)));
                Console.WriteLine();
            }
            json = JsonConvert.SerializeObject(Departaments);
            File.WriteAllText("Departaments.json", json);
            Console.ReadKey();
        }

        public static void DeleteDepartament()
        {
            Console.Clear();
            List<Departament> Departaments = new List<Departament>();
            List<Worker> Workers = new List<Worker>();
            string json = "";
            json = File.ReadAllText("Departaments.json");
            Departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
            int j = 1;
            Console.WriteLine("№   Название    Дата      Количество сотрудников");
            foreach (var item in Departaments)
            {
                Console.WriteLine($"{j,4},{item.depName,11},{item.dateCreate,11},{item.numberWorkers,4}"); j++;
            }
            Console.WriteLine();
            Console.Write("Выберите название департамента: "); string nameDep = Console.ReadLine();
            try
            {
                Departaments.RemoveAll(x => x.depName == nameDep);
            }
            catch { Console.WriteLine("Нет совпадений"); }
            json = JsonConvert.SerializeObject(Departaments);
            File.WriteAllText("Departaments.json", json);
            json = File.ReadAllText("Workers.json");
            Workers = JsonConvert.DeserializeObject<List<Worker>>(json);
            try
            {
                Workers.RemoveAll(x => x.dep == nameDep);
            }
            catch { }
            json = JsonConvert.SerializeObject(Workers);
            File.WriteAllText("Workers.json", json);
            Console.ReadKey();
        }

        public static void EditDepartament()
        {
            Console.Clear();
            List<Departament> Departaments = new List<Departament>();
            string json = "";
            int n = 1;
            bool exitEditDepartaments = false;
            json = File.ReadAllText("Departaments.json");
            Departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
            Console.WriteLine("№   Название    Дата      Количество сотрудников");
            foreach (var item in Departaments)
            {
                Console.WriteLine($"{n,4},{item.depName,11},{item.dateCreate,11},{item.numberWorkers,4}"); n++;
            }
            Console.WriteLine();
            Console.Write("Выберите номер строки для редактирования"); n = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("Выберите поле: 1 - название, 2 - дата создания"); int fieldEditDepartament = int.Parse(Console.ReadLine());
                switch (fieldEditDepartament)
                {
                    case 1:
                        Console.Write("Введите новое название: "); string newNameDepartament = Console.ReadLine();
                        Departaments[n - 1].depName = newNameDepartament;
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Введите новую дату: "); DateTime newDateDepartament = Convert.ToDateTime(Console.ReadLine());
                        Departaments[n - 1].dateCreate = newDateDepartament;
                        Console.ReadKey();
                        break;
                    default:
                        exitEditDepartaments = true;
                        break;
                }
            } while (!exitEditDepartaments);
            json = JsonConvert.SerializeObject(Departaments);
            File.WriteAllText("Departaments.json", json);
            Console.ReadKey();
        }

        public static void SortDepartament()
        {
            Console.Clear();
            Console.WriteLine("Поля для сортировки департаментов: название, дата_создания, количество_сотрудников");
            Console.Write("Выберите поле для сортировки: "); string fieldNameOfDepartaments = Console.ReadLine();
            List<Departament> Departaments = new List<Departament>();
            string json = "";
            json = File.ReadAllText("Departaments.json");
            Departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
            if (fieldNameOfDepartaments == "название")
            {
                Departaments.Sort((x, y) => (((IComparable)x.depName).CompareTo(y.depName)));
            }
            if (fieldNameOfDepartaments == "дата_создания")
            {
                Departaments.Sort((x, y) => (((IComparable)x.dateCreate).CompareTo(y.dateCreate)));
            }
            if (fieldNameOfDepartaments == "количество_сотрудников")
            {
                Departaments.Sort((x, y) => (((IComparable)x.numberWorkers).CompareTo(y.numberWorkers)));
            }
            json = JsonConvert.SerializeObject(Departaments);
            File.WriteAllText("Departaments.json", json);
            foreach (var item in Departaments)
            {
                Console.WriteLine($"{item.depName,20}{item.dateCreate,11}{item.numberWorkers,11}");
            }
            Console.ReadKey();
        }
    }
}

