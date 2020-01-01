using System;
using AdvMidi.Modes.PreFab;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;

namespace AdvMidi.Modes
{
    public static class VeloToLight
    {
        public static void VelocityToLight()
        {
            (int inputTemp, int outputTemp) = FlowInitiation.Devices();

            //unless you want your computer to break, do not remove the using 
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
                outputDevice.SendEvent(new NoteOnEvent(SevenBitNumber.Parse(note.ToString()),
                    SevenBitNumber.Parse((velocity).ToString())));

                Console.WriteLine($"{note}:{velocity}");
            }
        }
    }
}