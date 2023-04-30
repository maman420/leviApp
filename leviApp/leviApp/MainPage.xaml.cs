using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace leviApp
{
    public partial class MainPage : ContentPage
    {
        private Random random = new Random();

        private List<string> soundFiles = new List<string>()
        {
            "leviApp.Resources.levi4.mp3",
            "leviApp.Resources.levi2.ogg",
            "leviApp.Resources.levi3.ogg"
        };

        public MainPage()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnImageTapped;
            var myImage = this.FindByName<Image>("myImage");
            myImage.GestureRecognizers.Add(tapGestureRecognizer);
            playSong("leviApp.Resources.levi1.ogg");

        }

        private void OnImageTapped(object sender, EventArgs e)
        {
            playSongs(soundFiles);
        }

        private void playSongs(List<string> songFiles)
        {
            string soundFile = songFiles[random.Next(songFiles.Count)];
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(soundFile);
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(stream);
            player.Play();
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
