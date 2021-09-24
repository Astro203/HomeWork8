using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork8
{
    class Program
    {
        static void Main(string[] args)
        {
          
            List<Departament> Departaments = new List<Departament>();
            List<Worker> Workers = new List<Worker>();
            Random rand = new Random();
            string json = "";
            bool exit = false;
            bool create = false;
            do
            {
                Console.Clear();  
                Console.WriteLine("1. Добавить департамент");
                Console.WriteLine("2. Удалить департамент");
                Console.WriteLine("3. Редактировать данные о департаментах");
                Console.WriteLine("4. Добавить сотрудника");
                Console.WriteLine("5. Удалить сотрудника");
                Console.WriteLine("6. Редактировать данные о сотрудниках");
                Console.WriteLine("7. Сортировка данных о департаментах");
                Console.WriteLine("8. Сортировка данных о сотрудниках");
                Console.Write("Выберите пункт меню: ");
                int measurement = int.Parse(Console.ReadLine());
                switch (measurement)
                {
                    case 1:
                        Console.Clear();
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
                        break;
                    case 2:
                        Console.Clear();
                        json = File.ReadAllText("Departaments.json");
                        Departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
                        int j = 1;
                        Console.WriteLine("№   Название    Дата      Количество сотрудников");
                        foreach (var item in Departaments)
                        {
                            Console.WriteLine($"{j, 4},{item.depName, 11},{item.dateCreate, 11},{item.numberWorkers, 4}"); j++;
                        }
                        Console.WriteLine();
                        Console.Write("Выберите название департамента: "); string nameDep = Console.ReadLine();
                        try
                        {
                            Departaments.RemoveAll(x => x.depName == nameDep);
                        }
                        catch { Console.WriteLine("Нет совпадений");}
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
                        break;
                    case 3:
                        Console.Clear();
                        int n = 1;
                        bool exitEditDepartaments = false;
                        json = File.ReadAllText("Departaments.json");
                        Departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
                        Console.WriteLine("№   Название    Дата      Количество сотрудников");
                        foreach (var item in Departaments)
                        {
                            Console.WriteLine($"{n, 4},{item.depName,11},{item.dateCreate,11},{item.numberWorkers,4}"); n++;
                        }
                        Console.WriteLine();
                        Console.Write("Выберите номер строки для редактирования"); n = int.Parse(Console.ReadLine());
                        do
                        {
                            Console.WriteLine("Выберите поле: название, дата_создания"); string fieldEditDepartament = Console.ReadLine();
                            switch (fieldEditDepartament)
                            {
                                case "название":
                                    Console.Write("Введите новое название: "); string newNameDepartament = Console.ReadLine();
                                    Departaments[n - 1].depName = newNameDepartament;
                                    Console.ReadKey();
                                    break;
                                case "дата_создания":
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
                        break;
                    case 4:
                        Console.Clear();
                        int numberWorkers = 0;
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
                                break;
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
                        catch { Console.WriteLine("Во введенных данных ошибка");Console.ReadKey(); }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
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
                        break;
                    case 6:
                        Console.Clear();
                        int m = 1;
                        bool exitEditWorkers = false;
                        json = File.ReadAllText("Workers.json");
                        Workers = JsonConvert.DeserializeObject<List<Worker>>(json);
                        Console.WriteLine("№   Таб.номер Фамилия    Имя     Возраст  Департамент   Зарплата");
                        foreach (var item in Workers)
                        {
                            Console.WriteLine($"{item.tabNumber,4}{item.lastName,11}{item.firstName,11}{item.age,5}{item.dep,20}{item.salary,6}");
                        }
                        Console.WriteLine();
                        Console.Write("Выберите номер строки для редактирования"); n = int.Parse(Console.ReadLine());
                        do
                        {
                            Console.WriteLine("Выберите поле: идентификатор, фамилия, имя, возраст, департамент, зарплата"); string fieldEditDepartament = Console.ReadLine();
                            switch (fieldEditDepartament)
                            {
                                case "идентификатор":
                                    Console.Write("Введите идентификатор: "); int newTabNumber = int.Parse(Console.ReadLine());
                                    Workers[n - 1].tabNumber = newTabNumber;
                                    Console.ReadKey();
                                    break;
                                case "фамилия":
                                    Console.Write("Введите фамилию: "); string newLastName = Console.ReadLine();
                                    Workers[n - 1].lastName = newLastName;
                                    Console.ReadKey();
                                    break;
                                case "имя":
                                    Console.Write("Введите имя: "); string newFirstName = Console.ReadLine();
                                    Workers[n - 1].firstName = newFirstName;
                                    Console.ReadKey();
                                    break;
                                case "возраст":
                                    Console.Write("Введите возраст: "); int newAge = int.Parse(Console.ReadLine());
                                    Workers[n - 1].age = newAge;
                                    Console.ReadKey();
                                    break;
                                case "департамент":
                                    Console.Write("Введите департамент: "); string newDepartament = Console.ReadLine();
                                    Workers[n - 1].dep = newDepartament;
                                    Console.ReadKey();
                                    break;
                                case "зарплата":
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
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Поля для сортировки департаментов: название, дата_создания, количество_сотрудников");
                        Console.Write("Выберите поле для сортировки: "); string fieldNameOfDepartaments = Console.ReadLine();
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
                            Console.WriteLine($"{item.depName, 20}{item.dateCreate,11}{item.numberWorkers,11}");
                        }
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Поля для сортировки работников: идентификатор, фамилия, имя, возраст, департамент, зарплата");
                        Console.Write("Выберите поле для сортировки: "); string fieldNameOfWorkers = Console.ReadLine();
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
                            Console.WriteLine($"{item.tabNumber, 4}{item.lastName, 11}{item.firstName, 11}{item.age, 5}{item.dep, 20}{item.salary, 6}");
                        }
                        Console.ReadKey();
                        break;
                    default:
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }
}
