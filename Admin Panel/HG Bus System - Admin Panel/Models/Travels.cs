using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG_Bus_System___Admin_Panel.Models
{
    internal class Travels
    {
        public int ID { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime Start_Time { get; set; }
        public string Bus_Driver { get; set; }
        public string Bus { get; set; }
        public string Route { get; set; }
    }
}
