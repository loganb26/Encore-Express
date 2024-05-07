using System;
using System.Collections.Generic;


namespace EncoreExpress.Pages
{
    public partial class PlaylistPage : ContentPage
    {
        private const string SongsKey = "SongsList";

        public List<string> Songs { get; set; }

        public PlaylistPage()
        {
            InitializeComponent();

            // Load songs from secure storage on page initialization
            LoadSongsFromSecureStorage();
        }

        private async void LoadSongsFromSecureStorage()
        {
            try
            {
                // Retrieve the list of songs from Secure Storage
                var songsString = await SecureStorage.GetAsync(SongsKey);
                Songs = !string.IsNullOrEmpty(songsString) ? new List<string>(songsString.Split(',')) : new List<string>();

                // Update the ListView to reflect the loaded songs
                songsListView.ItemsSource = Songs;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during data loading
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }

        private async void SaveSongsToSecureStorage()
        {
            try
            {
                // Save the list of songs to Secure Storage as a comma-separated string
                await SecureStorage.SetAsync(SongsKey, string.Join(",", Songs));
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during data saving
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }

        private async void AddSongsButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var options = new PickOptions
                {
                    PickerTitle = "Select one or more songs"
                };

                var selectedFiles = await FilePicker.PickMultipleAsync(options);
                if (selectedFiles != null)
                {
                    foreach (var file in selectedFiles)
                    {
                        // Add the selected file names to the list of songs
                        Songs.Add(file.FileName);
                    }

                    // Update the ListView to reflect the changes
                    songsListView.ItemsSource = null;
                    songsListView.ItemsSource = Songs;

                    // Save uploaded songs to Secure Storage
                    SaveSongsToSecureStorage();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file picking
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }

        private async void SongsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is string selectedSong)
            {
                // Navigate to the PlayerPage and pass the selected song
                await Navigation.PushAsync(new PlayerPage());
            }
        }

        private void OnMenuClicked(object sender, EventArgs e)
        {
            //This is wrong just creates new page !have to change
            App.Current.MainPage = new MenuPage();
        }
    }
}
