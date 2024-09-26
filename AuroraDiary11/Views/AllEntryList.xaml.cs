using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AuroraDiary.Models;
using AuroraDiary.Data;
using System;
using System.Threading.Tasks;

namespace AuroraDiary.Views
{
    public partial class AllEntryList : ContentPage
    {
        public ObservableCollection<DiaryEntryViewModel> Entries { get; set; }
        public ICommand AddEntryCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        public ICommand EditEntryCommand { get; }
        public ICommand DeleteEntryCommand { get; }

        public AllEntryList()
        {
            InitializeComponent();
            Entries = new ObservableCollection<DiaryEntryViewModel>();
            AddEntryCommand = new Command(OnAddEntry);
            NavigateToSettingsCommand = new Command(OnNavigateToSettings);
            EditEntryCommand = new Command<DiaryEntryViewModel>(OnEditEntry);
            DeleteEntryCommand = new Command<DiaryEntryViewModel>(OnDeleteEntry);

            BindingContext = this;

            LoadEntries();

            // Subscribe to the message for reloading entries
            MessagingCenter.Subscribe<AddEntryPage>(this, "NewEntryAdded", (sender) =>
            {
                LoadEntries();
            });

            // Subscribe to the message for reloading entries after editing
            MessagingCenter.Subscribe<EditEntryPage>(this, "EntryEdited", (sender) =>
            {
                LoadEntries();
            });
        }

        private async void LoadEntries()
        {
            try
            {
                var database = await DiaryEntryDatabase.Instance;
                var entries = await database.GetItemsAsync();
                Entries.Clear();
                foreach (var entry in entries)
                {
                    Entries.Add(new DiaryEntryViewModel(entry));
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception
                await DisplayAlert("Error", "Failed to load entries: " + ex.Message, "OK");
            }
        }

        private async void OnAddEntry()
        {
            await Navigation.PushAsync(new AddEntryPage());
        }

        private async void OnNavigateToSettings()
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void OnEditEntry(DiaryEntryViewModel entryViewModel)
        {
            await Navigation.PushAsync(new EditEntryPage(entryViewModel.Entry));
        }

        private async void OnDeleteEntry(DiaryEntryViewModel entryViewModel)
        {
            bool confirm = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this entry?", "Yes", "No");
            if (confirm)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Entries.Remove(entryViewModel);
                });

                try
                {
                    var database = await DiaryEntryDatabase.Instance;
                    await database.DeleteItemAsync(entryViewModel.Entry);
                }
                catch (Exception ex)
                {
                    // Log or display the exception
                    await DisplayAlert("Error", "Failed to delete entry: " + ex.Message, "OK");
                }

                // Reload the entries to reflect the latest state
                LoadEntries();
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tappedItem = e.Item as DiaryEntryViewModel;
            if (tappedItem != null)
            {
                foreach (var entry in Entries)
                {
                    entry.IsButtonsVisible = false;
                    entry.IsContentVisible = false;
                }
                tappedItem.IsButtonsVisible = true;
                tappedItem.IsContentVisible = true;
            }
        }
    }

    public class DiaryEntryViewModel : BindableObject
    {
        private bool _isButtonsVisible;
        private bool _isContentVisible;

        public DiaryEntry Entry { get; }

        public DiaryEntryViewModel(DiaryEntry entry)
        {
            Entry = entry;
        }

        public bool IsButtonsVisible
        {
            get => _isButtonsVisible;
            set
            {
                _isButtonsVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsContentVisible
        {
            get => _isContentVisible;
            set
            {
                _isContentVisible = value;
                OnPropertyChanged();
            }
        }

        public string Title => Entry.Title;
        public string Date => Entry.Date.ToString("MM/dd/yyyy");
        public string Content => Entry.Content;
        public string Emotion => Entry.Emotion;

        public ImageSource Photo
        {
            get
            {
                if (string.IsNullOrEmpty(Entry.Photo))
                    return null;

                return ImageSource.FromStream(() => new System.IO.MemoryStream(Convert.FromBase64String(Entry.Photo)));
            }
        }
    }
}
