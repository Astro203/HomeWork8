using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork8
{
    public interface ICommandWorkers
    {
        void Execute();
        void Undo();
    }

    class IcommandCreateWorker : ICommandWorkers
    {
        public void Execute() => Worker.CreateWorker(false)) return;
        public void Undo() => Worker.DeleteWorker();
    }

    class ICommandEditWorker : ICommandWorkers
    {
        public void Execute() => Worker.EditWorker();
        public void Undo() { }
    }

    class ICommandSortWorkers : ICommandWorkers
    {
        public void Execute() => Worker.SortWorkers();
        public void Undo() { }
    }

    public interface ICommandDepartaments
    {
        void Execute();
        void Undo();
    }

    class IcommandCreateDepartament : ICommandDepartaments
    {
        public void Execute() => Departament.CreateDepartament();
        public void Undo() => Departament.DeleteDepartament();
    }
    class ICommandEditDepartament : ICommandDepartaments
    {
        public void Execute() => Departament.EditDepartament();
        public void Undo() { }
    }

    class ICommandSortDepartaments : ICommandDepartaments
    {
        public void Execute() => Departament.SortDepartament();
        public void Undo() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
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
                IcommandCreateDepartament commandCreateDepartaments = new IcommandCreateDepartament();
                ICommandEditDepartament commandEditDepartament = new ICommandEditDepartament();
                ICommandSortDepartaments commandSortDepartaments = new ICommandSortDepartaments();
                IcommandCreateWorker commandCreateWorker = new IcommandCreateWorker();
                ICommandEditWorker commandEditWorker = new ICommandEditWorker();
                ICommandSortWorkers commandSortWorkers = new ICommandSortWorkers();

                int measurement = int.Parse(Console.ReadLine());

                switch (measurement)
                {
                    case 1:
                        commandCreateDepartaments.Execute();
                        break;
                    case 2:
                        commandCreateDepartaments.Undo();
                        break;
                    case 3:
                        commandEditDepartament.Execute();
                        break;
                    case 4:
                        commandCreateWorker.Execute();
                        exit = true;
                        break;
                    case 5:
                        commandCreateWorker.Undo();
                        break;
                    case 6:
                        commandEditWorker.Execute();
                        break;
                    case 7:
                        commandSortDepartaments.Execute();
                        break;
                    case 8:
                        commandSortWorkers.Execute();
                        break;
                    default:
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }

}
