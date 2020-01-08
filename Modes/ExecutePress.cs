using System;
using System.IO;
using System.Windows.Input;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;
using WindowsInput.Native;
using WindowsInput;
using InputDevice = Melanchall.DryWetMidi.Devices.InputDevice;

namespace AdvMidi.Modes
{
    public static class ExecutePress
    {
        public static void OpenExecution()
        {
            string[] assignedKeys = File.ReadAllLines("KeyPresets.txt");
            var inputSimulator = new InputSimulator();

            var (inputTemp, outputTemp) = FlowInitiation.Devices();
            using var outputDevice = OutputDevice.GetById(outputTemp);
            using var inputDevice = InputDevice.GetById(inputTemp);
            inputDevice.EventReceived += OnEventReceived;

            while (true) inputDevice.StartEventsListening();
            
            void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
            {
                
                var _ = (NoteOnEvent) e.Event;
                int note = _.NoteNumber;
                if (_.Velocity != 127) return;
                int x = 63 - (note - 11 - 2 * (note / 10 - 1));

                if (Enum.TryParse(assignedKeys[x], true, out Key key))
                {
                    var virtualKeyCodeAtKey = Enum.GetName(typeof(VirtualKeyCode), KeyInterop.VirtualKeyFromKey(key));
                    VirtualKeyCode enumAtKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), virtualKeyCodeAtKey);
                    inputSimulator.Keyboard.KeyDown(enumAtKeyCode);
                    Console.WriteLine(key);
                }
                else
                {
                    Console.WriteLine("This key type is incorrect or blank.");
                }
            }
        }
    }
}