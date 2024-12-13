using ClinicaStomatologicaApp.Models;
using SQLiteNetExtensions.Attributes;
namespace ClinicaStomatologicaApp;
public partial class MyPatientsPage : ContentPage
{
	public MyPatientsPage()
	{
		InitializeComponent();
	}
    async void OnGoToTreatmentsClicked(object sender, EventArgs e)
    {
        // Navigăm către pagina de tratamente
        await Navigation.PushAsync(new TreatmentsPage());
    }

    // Adaugă un pacient
    async void OnAddPatientClicked(object sender, EventArgs e)
    {
        var newPatient = (Patient)BindingContext;

        if (!string.IsNullOrEmpty(newPatient.Name))
        {
            // Salvează pacientul în baza de date
            await App.Database.SavePatientAsync(newPatient);
            await DisplayAlert("Success", "Patient added!", "OK");

            // Reîncarcă lista de pacienți
            patientsListView.ItemsSource = await App.Database.GetPatientsAsync();
        }
        else
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
        }
    }
    async void OnPatientSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedPatient = e.SelectedItem as Patient;

        if (selectedPatient != null)
        {
            // Optionally, show some details about the selected patient
            await DisplayAlert("Patient Selected", $"Patient Name: {selectedPatient.Name}", "OK");

            // You can also perform any other actions when a patient is selected, like navigating to a detail page
        }

        // Deselect the item (important to prevent it from remaining highlighted after selection)
        ((ListView)sender).SelectedItem = null;
    }
    // Șterge un pacient
    async void OnDeletePatientClicked(object sender, EventArgs e)
    {
        var selectedPatient = (Patient)patientsListView.SelectedItem;

        if (selectedPatient != null)
        {
            // Șterge pacientul din baza de date
            await App.Database.DeletePatientAsync(selectedPatient);
            await DisplayAlert("Deleted", "Patient deleted!", "OK");

            // Reîncarcă lista de pacienți
            patientsListView.ItemsSource = await App.Database.GetPatientsAsync();
        }
        else
        {
            await DisplayAlert("Error", "Please select a patient to delete.", "OK");
        }
    }

    // Se încarcă lista de pacienți când pagina apare
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Încarcă pacienții din baza de date
        patientsListView.ItemsSource = await App.Database.GetPatientsAsync();
    }
}