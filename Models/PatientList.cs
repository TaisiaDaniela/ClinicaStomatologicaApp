﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
namespace ClinicaStomatologicaApp.Models
{
    public class PatientList
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        [MaxLength(250), Unique]

        public string Description { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(typeof(Patient))]
        public int PatientID { get; set; }
    }
}
