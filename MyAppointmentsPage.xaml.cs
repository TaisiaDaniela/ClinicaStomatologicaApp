using ClinicaStomatologicaApp.Models;
using System.Collections.ObjectModel;

namespace ClinicaStomatologicaApp;

public partial class MyAppointmentsPage : ContentPage
{
    public ObservableCollection<Appointment> Appointments { get; set; }
    public ObservableCollection<Treatment> Treatments { get; set; }

    public MyAppointmentsPage()
    {
        InitializeComponent();
        Appointments = new ObservableCollection<Appointment>();
        Treatments = new ObservableCollection<Treatment>();
        BindingContext = this; // Setează BindingContext-ul pentru a lega datele    }

        // Navighează la pagina de tratamente
        async void OnGoToTreatmentsClicked(object sender, EventArgs e)
        {
            // Navigăm către pagina de tratamente
            await Navigation.PushAsync(new TreatmentsPage());
        }

        // Adaugă un tratament la programarea pacientului
        async void OnAddAppointmentClicked(object sender, EventArgs e)
        {
            // Asumăm că tratamentul și programarea au fost selectate
            var selectedTreatment = TreatmentsListView.SelectedItem as Treatment;
            var selectedAppointment = (Appointment)appointmentsListView.SelectedItem;

            if (selectedAppointment != null && selectedTreatment != null)
            {
                // Asociezi tratamentul la programarea pacientului
                selectedAppointment.TreatmentName = selectedTreatment.TreatmentName;

                // Salvezi programarea actualizată în baza de date
                await App.Database.SaveAppointmentAsync(selectedAppointment);

                await DisplayAlert("Success", "Treatment added to appointment!", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Please select an appointment and a treatment.", "OK");
            }
        }
        async void OnAppointmentSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedAppointment = e.SelectedItem as Appointment;

            if (selectedAppointment != null)
            {
                await DisplayAlert("Appointment Selected", $"Patient: {selectedAppointment.Name}\nTreatment: {selectedAppointment.TreatmentName}", "OK");
            }

        // Deselect the item after it's selected to remove the highlight
        ((ListView)sender).SelectedItem = null;
        }

        // Șterge o programare
        async void OnDeleteAppointmentClicked(object sender, EventArgs e)
        {
            var selectedAppointment = (Appointment)appointmentsListView.SelectedItem;

            if (selectedAppointment != null)
            {
                // Șterge programarea din baza de date
                await App.Database.DeleteAppointmentAsync(selectedAppointment);
                await DisplayAlert("Deleted", "Appointment deleted!", "OK");

                // Reîncarcă lista de programări
                appointmentsListView.ItemsSource = await App.Database.GetAppointmentsAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please select an appointment to delete.", "OK");
            }
        }
    }

    // Se încarcă lista de programări când pagina apare
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Încarcă programările din baza de date
        appointmentsListView.ItemsSource = await App.Database.GetAppointmentsAsync();
    }
}
