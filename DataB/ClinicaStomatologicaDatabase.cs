using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ClinicaStomatologicaApp.Models;


namespace ClinicaStomatologicaApp.DataB
{
    public class ClinicaStomatologicaDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ClinicaStomatologicaDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Appointment>().Wait();
            _database.CreateTableAsync<Patient>().Wait();
            _database.CreateTableAsync<Treatment>().Wait();
        }

        // CRUD pentru Appointments
        public Task<List<Appointment>> GetAppointmentsAsync() => _database.Table<Appointment>().ToListAsync();
        public Task<int> SaveAppointmentAsync(Appointment appointment) => appointment.ID != 0 ? _database.UpdateAsync(appointment) : _database.InsertAsync(appointment);
        public Task<int> DeleteAppointmentAsync(Appointment appointment) => _database.DeleteAsync(appointment);
        // CRUD pentru Treatment
        public Task<List<Treatment>> GetTreatmentAsync() => _database.Table<Treatment>().ToListAsync();
        public Task<int> SaveTreatmentAsync(Treatment treatment) => treatment.ID != 0 ? _database.UpdateAsync(treatment) : _database.InsertAsync(treatment);
        public Task<int> DeleteTreatmentAsync(Treatment treatment) => _database.DeleteAsync(treatment);

        // CRUD pentru Patients
        public Task<List<Patient>> GetPatientsAsync() => _database.Table<Patient>().ToListAsync();
        public Task<int> SavePatientAsync(Patient patient) => patient.Id != 0 ? _database.UpdateAsync(patient) : _database.InsertAsync(patient);
        public Task<int> DeletePatientAsync(Patient patient) => _database.DeleteAsync(patient);
    }
}

