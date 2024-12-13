
using ClinicaStomatologicaApp.Models;
using System;
using System.Collections.Generic;
namespace ClinicaStomatologicaApp;
    public partial class TreatmentsPage : ContentPage
    {
        public Treatment Treatment { get; set; }

        public TreatmentsPage()
        {
            InitializeComponent();
            Treatment = new Treatment();
            BindingContext = Treatment;
        }

        // Se salvează tratamentul
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            await App.Database.SaveTreatmentAsync(Treatment);
            await DisplayAlert("Success", "Treatment saved!", "OK");
            treatmentsListView.ItemsSource = await App.Database.GetTreatmentAsync();
        }

        // Se șterge tratamentul
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await App.Database.DeleteTreatmentAsync(Treatment);
            await DisplayAlert("Deleted", "Treatment deleted!", "OK");
            treatmentsListView.ItemsSource = await App.Database.GetTreatmentAsync();
        }

        // Se încarcă lista de tratamente când pagina apare
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            treatmentsListView.ItemsSource = await App.Database.GetTreatmentAsync();
        }
    }
