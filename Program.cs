using System;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Core;

namespace AdvMidi
{
    class Program
    {
        static void Main()
        {
            
            (int inputTemp, int outputTemp) = Initiate.Devices();
            
            using var outputDevice = OutputDevice.GetById(outputTemp);
            using var inputDevice = InputDevice.GetById(inputTemp);
            
            inputDevice.EventReceived += OnEventReceived;

            do
            {
                inputDevice.StartEventsListening();
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);

            // NoteAftertouchEvent
            // NoteOnEvent
            void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
            {
                string keyEvent = e.Event.ToString();
                var inputs = keyEvent.Split(',');
                (int velocity, int note) = (int.Parse(inputs[1]), int.Parse(inputs[0]));
                outputDevice.SendEvent(new NoteOnEvent(SevenBitNumber.Parse(note.ToString()), SevenBitNumber.Parse((velocity).ToString())));
                
                Console.WriteLine($"{note}:{velocity}");
            }
        }
    }
}