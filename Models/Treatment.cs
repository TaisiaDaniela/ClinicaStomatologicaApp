using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace ClinicaStomatologicaApp.Models
{
    public class Treatment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TreatmentName { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<ListTreatment> ListTreatment { get; set; }
    }
}
