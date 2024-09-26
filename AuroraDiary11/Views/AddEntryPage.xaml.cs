using Microsoft.Maui.Controls;
using System.Windows.Input;
using AuroraDiary.Models;
using AuroraDiary.Data;
using System;
using Microsoft.Maui.Media;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace AuroraDiary.Views
{
    public partial class AddEntryPage : ContentPage
    {
        public DiaryEntry Entry { get; private set; }
        public ICommand SaveEntryCommand { get; }
        private string photoPath;

        public AddEntryPage()
        {
            InitializeComponent();
            Entry = new DiaryEntry { Date = DateTime.Now };
            SaveEntryCommand = new Command(OnSaveEntry);
            BindingContext = this;
        }

        private async void OnUploadPhotoClicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Add Photo", "Cancel", null, "Take Photo", "Choose from Gallery");

            if (action == "Take Photo")
            {
                await TakePhotoAsync();
            }
            else if (action == "Choose from Gallery")
            {
                await PickPhotoAsync();
            }
        }

        private async Task TakePhotoAsync()
        {
            try
            {
                var status = await Permissions.RequestAsync<Permissions.Camera>();
                if (status == PermissionStatus.Granted)
                {
                    var result = await MediaPicker.CapturePhotoAsync();
                    if (result != null)
                    {
                        var stream = await result.OpenReadAsync();
                        using (var memoryStream = new System.IO.MemoryStream())
                        {
                            await stream.CopyToAsync(memoryStream);
                            Entry.Photo = Convert.ToBase64String(memoryStream.ToArray());
                            photoImage.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(memoryStream.ToArray()));
                            photoPath = result.FullPath;
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Permission Denied", "Camera permission is required to take photos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to take photo: " + ex.Message, "OK");
            }
        }

        private async Task PickPhotoAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        Entry.Photo = Convert.ToBase64String(memoryStream.ToArray());
                        photoImage.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(memoryStream.ToArray()));
                        photoPath = result.FullPath;
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Photo picking was canceled.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to upload photo: " + ex.Message, "OK");
            }
        }

        private async void OnSaveEntry()
        {
            Entry.Title = titleEntry.Text;
            Entry.Content = contentEditor.Text;
            Entry.Date = datePicker.Date;
            Entry.Emotion = emotionPicker.SelectedItem?.ToString();
            Entry.PhotoPath = photoPath;

            try
            {
                var database = await DiaryEntryDatabase.Instance;
                await database.SaveItemAsync(Entry);

                // Send a message to notify that a new entry has been added
                MessagingCenter.Send(this, "NewEntryAdded");

                await Navigation.PopAsync(); 
            }
            catch (Exception ex)
            {
                // Log or display the exception
                await DisplayAlert("Error", "Failed to save entry: " + ex.Message, "OK");
            }
        }
    }
}
