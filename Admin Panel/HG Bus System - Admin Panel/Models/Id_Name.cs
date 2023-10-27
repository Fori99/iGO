using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG_Bus_System___Admin_Panel.Models
{
    class Id_Name
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Id_Name(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
