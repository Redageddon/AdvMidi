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
                var (note, velocity) = (0, 0);
                
                switch (e.Event.EventType)
                {
                    case MidiEventType.NoteAftertouch:
                    {
                        var atEvent = (NoteAftertouchEvent) e.Event;
                        note = atEvent.NoteNumber;
                        velocity = atEvent.AftertouchValue;
                        break;
                    }
                    case MidiEventType.NoteOn:
                    {
                        var onEvent = (NoteOnEvent) e.Event;
                        note = onEvent.NoteNumber;
                        velocity = onEvent.Velocity;
                        break;
                    }
                    default:
                        Console.WriteLine("I have not implemented that yet. If you would like this to be implemented tell me or edit this on the github");
                        break;
                }
                outputDevice.SendEvent(new NoteOnEvent(SevenBitNumber.Parse(note.ToString()),
                    SevenBitNumber.Parse((velocity).ToString())));
                Console.WriteLine($"note: {note}, Velocity: {velocity}");
            }
        }
    }
}