using System;
using System.Collections.Generic;
using System.Text;

namespace leviApp.Models
{
    public class Person
    {
        public string Name { get; set; }
        public List<string> SoundFiles { get; set; }
        public string IntroSound { get; set; }
        public string Image { get; set; }
        public Person(string name, List<string> soundFiles, string introSound, string image)
        {
            Name = name;
            SoundFiles = soundFiles;
            IntroSound = introSound;
            Image = image;
        }


    }
}
