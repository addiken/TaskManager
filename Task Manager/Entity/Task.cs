using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Entity
{
    public class Task
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
    }
}
