using System;
using System.Collections.Generic;
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

    }
}

