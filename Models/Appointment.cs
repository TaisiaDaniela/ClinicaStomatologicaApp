﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ClinicaStomatologicaApp.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int? PatientID { get; set; }
        public Patient? Patients { get; set; }
        public int? TreatmentID { get; set; }
        public Treatment? Treatments { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        public DateOnly Date { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        public TimeOnly Time { get; set; }
        public string Description { get; set; }
        public string? TreatmentName { get; internal set; }
        public string Name { get; set; }

    }
}
