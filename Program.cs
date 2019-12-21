using System;
using System.Linq;
using Melanchall.DryWetMidi.Devices;

namespace MidiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var inputDevices = InputDevice.GetAll().ToArray();
            
            #region Input
            // 0 for Live, 1 for PGM
            using var inputDevice = InputDevice.GetByName(inputDevices[1].ToString());
            inputDevice.EventReceived += OnEventReceived;

            do {
                while (! Console.KeyAvailable) {
                    inputDevice.StartEventsListening();
                }       
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            // NoteOnEvent
            
            void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
            {
                var midiDevice = (MidiDevice) sender;
                string keyEvent = e.Event.ToString();
                var inputs = keyEvent.Split(',');
                bool on = Convert.ToBoolean(int.Parse(inputs[1]));
                int note = int.Parse(inputs[0]);
                var input = (on, note);
                
                Console.WriteLine($"{input.on} {input.note}");
            }
            #endregion
            
            
        }
    }
}