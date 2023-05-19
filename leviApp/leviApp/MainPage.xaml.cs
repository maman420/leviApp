using leviApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace leviApp
{
    public partial class MainPage : ContentPage
    {
        private List<string> soundFilesWithoutLast;
        private Person person;

        public MainPage()
        {
            InitializeComponent();

            var random = new Random();
            var randomNum = random.Next(0, 7);
            switch (randomNum)
            {
                case 0:
                    person = new Person("orel", new List<string> {
                        "leviApp.Resources.orel.orel1.ogg",
                        "leviApp.Resources.orel.orel2.ogg",
                        "leviApp.Resources.orel.orel3.ogg",
                        "leviApp.Resources.orel.orel4.ogg"
                    }, "leviApp.Resources.orel.orelIntro.ogg", "Resources/orel.png");
                    break;
                case 1:
                    person = new Person("ron", new List<string> { 
                        "leviApp.Resources.ron.ron1.ogg",
                        "leviApp.Resources.ron.ron2.ogg",
                        "leviApp.Resources.ron.ron3.ogg",
                        "leviApp.Resources.ron.ron4.ogg",
                        "leviApp.Resources.ron.ron6.ogg",
                        "leviApp.Resources.ron.ron5.ogg"
                    }, "leviApp.Resources.ron.ronIntro.ogg", "Resources/ron.png");
                    break;
                case 2:
                    person = new Person("shemesh", new List<string> { 
                        "leviApp.Resources.shemesh.shemesh1.ogg",
                        "leviApp.Resources.shemesh.shemesh2.ogg",
                        "leviApp.Resources.shemesh.shemesh3.ogg",
                        "leviApp.Resources.shemesh.shemesh4.ogg"
                    }, "leviApp.Resources.shemesh.shemeshIntro.ogg", "Resources/shemesh.png");
                    break;
                case 3:
                    person = new Person("ida", new List<string> { 
                        "leviApp.Resources.ida.ida1.ogg",
                        "leviApp.Resources.ida.ida2.ogg",
                        "leviApp.Resources.ida.ida3.ogg",
                        "leviApp.Resources.ida.ida4.ogg"
                    }, "leviApp.Resources.ida.idaIntro.ogg", "Resources/ida.png");
                    break;
                case 4:
                    person = new Person("liya", new List<string> { 
                        "leviApp.Resources.liya.liya1.ogg",
                        "leviApp.Resources.liya.liya2.ogg",
                        "leviApp.Resources.liya.liya3.ogg",
                        "leviApp.Resources.liya.liya4.ogg"
                    }, "leviApp.Resources.liya.liyaIntro.ogg", "Resources/liya.png");
                    break;
                case 5:
                    person = new Person("maman", new List<string> { 
                        "leviApp.Resources.maman.maman1.ogg",
                        "leviApp.Resources.maman.maman2.ogg",
                        "leviApp.Resources.maman.maman3.ogg",
                        "leviApp.Resources.maman.maman4.ogg"
                    }, "leviApp.Resources.maman.mamanIntro.ogg", "Resources/maman.png");
                    break;
                case 6:
                    person = new Person("levi", new List<string> {            
                        "leviApp.Resources.levi.levi2.ogg",
                        "leviApp.Resources.levi.levi3.ogg",
                        "leviApp.Resources.levi.levi4.mp3",
                        "leviApp.Resources.levi.levi5.mp3",
                        "leviApp.Resources.levi.levi6.ogg"
                    }, "leviApp.Resources.levi.leviIntro.ogg", "Resources/leviLong.png");
                    break;
            }


            soundFilesWithoutLast = new List<string>(person.SoundFiles);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnImageTapped;
            var myImage = this.FindByName<Image>("myImage");
            myImage.Source = person.Image;
            myImage.GestureRecognizers.Add(tapGestureRecognizer);
            playSong(person.IntroSound);
        }

        private void OnImageTapped(object sender, EventArgs e)
        {
            var random = new Random();
            string soundFile = soundFilesWithoutLast[random.Next(soundFilesWithoutLast.Count)];
            soundFilesWithoutLast = person.SoundFiles.Where(item => item != soundFile).ToList();

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
