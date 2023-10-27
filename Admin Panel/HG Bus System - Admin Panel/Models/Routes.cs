using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG_Bus_System___Admin_Panel.Models
{
    class Routes
    {
        public int ID { get; set; }
        public string Start_City_Name { get; set; }
        public string Destination_City_Name { get; set; }
        public int Price { get; set; }
    }
}
