using Microsoft.Maui.Controls;
using System.Windows.Input;
using AuroraDiary.Models;
using AuroraDiary.Data;
using System;

namespace AuroraDiary.Views
{
    public partial class EditEntryPage : ContentPage
    {
        public DiaryEntry Entry { get; private set; }
        public ICommand SaveEntryCommand { get; }

        public EditEntryPage(DiaryEntry entry)
        {
            InitializeComponent();
            Entry = entry;
            SaveEntryCommand = new Command(OnSaveEntry);
            BindingContext = this;
        }

        private async void OnSaveEntry()
        {
            try
            {
                var database = await DiaryEntryDatabase.Instance;
                await database.SaveItemAsync(Entry);

                // Send a message to notify that an entry has been edited
                MessagingCenter.Send(this, "EntryEdited");

                await Navigation.PopAsync(); // Navigate back to AllEntryList
            }
            catch (Exception ex)
            {
                // Log or display the exception
                await DisplayAlert("Error", "Failed to save entry: " + ex.Message, "OK");
            }
        }
    }
}
