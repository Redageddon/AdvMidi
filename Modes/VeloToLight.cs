using System;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;

namespace AdvMidi.Modes
{
    public static class VeloToLight
    {
        public static void VelocityToLight()
        {
            var (inputTemp, outputTemp) = FlowInitiation.Devices();

            //unless you want your computer to break, do not remove the using 
            using var outputDevice = OutputDevice.GetById(outputTemp);
            using var inputDevice = InputDevice.GetById(inputTemp);

            inputDevice.EventReceived += OnEventReceived;

            do
            {
                inputDevice.StartEventsListening();
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            
            void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
            {
                var (note, velocity) = NoteVelocityUpdater.Catcher(e);
                outputDevice.SendEvent(new NoteOnEvent(SevenBitNumber.Parse(note.ToString()),
                    SevenBitNumber.Parse((velocity).ToString())));
                Console.WriteLine($"note: {note}, Velocity: {velocity}");
            }
        }
    }
}