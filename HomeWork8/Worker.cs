using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Вывод данных на экран
        /// </summary>
        /// <returns></returns>
    }
}
