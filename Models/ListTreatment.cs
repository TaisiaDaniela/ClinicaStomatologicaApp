using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ClinicaStomatologicaApp.Models
{
    public class ListTreatment
    { 
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Patient))]
        public int PatientList{ get; set; }
        public int ProductID { get; set; }
       
    }
}
