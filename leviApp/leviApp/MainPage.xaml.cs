using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace leviApp
{
    public partial class MainPage : ContentPage
    {
        private readonly List<string> soundFiles = new List<string>()
        {
            "leviApp.Resources.levi2.ogg",
            "leviApp.Resources.levi3.ogg",
            "leviApp.Resources.levi4.mp3",
            "leviApp.Resources.levi5.mp3"
        };
        private List<string> soundFilesWithoutLast;

        public MainPage()
        {
            InitializeComponent();

            soundFilesWithoutLast = new List<string>(soundFiles);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnImageTapped;
            var myImage = this.FindByName<Image>("myImage");
            myImage.GestureRecognizers.Add(tapGestureRecognizer);
            playSong("leviApp.Resources.levi1.ogg");
        }

        private void OnImageTapped(object sender, EventArgs e)
        {
            var random = new Random();
            string soundFile = soundFilesWithoutLast[random.Next(soundFilesWithoutLast.Count)];
            soundFilesWithoutLast = soundFiles.Where(item => item != soundFile).ToList();
            playSong(soundFile);
        }
        private void playSong(string songFile)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(songFile);
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(stream);
            player.Play();
        }
    }
}
