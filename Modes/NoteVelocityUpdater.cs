using System;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;

namespace AdvMidi.Modes
{
    public static class NoteVelocityUpdater
    {
        public static (int, int) Catcher (MidiEventReceivedEventArgs e)
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
                    Console.WriteLine(
                        "I have not implemented that yet. If you would like this to be implemented tell me or edit this on the github");
                    break;
            }
            return (note, velocity);
        }
    }
}