using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    interface Target
    {
        void Play();
        void Pause();
        //void Skip(); can add more functionality
    }

    class MP3
    {
        public void Play()
        {
            //Implement mp3 play
        }

        public void Pause()
        {
            //Implement mp3 pause
        }
    }

    // This Adapter makes the MP3 interface compatible with the Target's interface.
    class MP3Adapter : Target
    {
        private readonly MP3 _adaptee;

        public MP3Adapter(MP3 adaptee)
        {
            this._adaptee = adaptee;
        }

        public void Play()
        {
            this._adaptee.Play();
        }
        public void Pause()
        {
            this._adaptee.Pause();
        }
        /* Implementation example
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
        */
    }

}
