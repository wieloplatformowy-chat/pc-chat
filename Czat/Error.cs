using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czat
{
    /// <summary>
    /// This class is used when you try to deserialize JSON, which represent error (JSON is aquired from server).
    /// </summary>
    public class Error
    {
        private int id;
        public int ID { get; set; }

        private string name;
        public int Name { get; set; }

        private string message;
        public int Message { get; set; }

        public Error(int id, string name, string message)
        {
            this.id = id;
            this.name = name;
            this.message = message;
        }
    }
}
