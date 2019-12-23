using System;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Core;

namespace MidiTest
{
    class Program
    {
        static void Main()
        {
            #region initiation

            Console.WriteLine("Pick a midi input device.\n", Console.ForegroundColor = ConsoleColor.DarkRed);
            foreach (var device in InputDevice.GetAll())
            {
                Console.WriteLine($"{device.Id}: {device}", Console.ForegroundColor = ConsoleColor.White);
            }
            Console.WriteLine();

            string inputDeviceId = Console.ReadLine();
            int inputTemp;
            while (!int.TryParse(inputDeviceId, out inputTemp))
            {
                Console.WriteLine("You did not enter anything or you entered something incorrectly. Please try again");
                inputDeviceId = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Pick a midi output device.\n", Console.ForegroundColor = ConsoleColor.Blue);
            foreach (var device in InputDevice.GetAll())
                Console.WriteLine($"{device.Id}: {device}", Console.ForegroundColor = ConsoleColor.White);
            Console.WriteLine();

            string outputDeviceId = Console.ReadLine();
            int outputTemp;
            while (!int.TryParse(outputDeviceId, out outputTemp))
            {
                Console.WriteLine("You did not enter anything or you entered something incorrectly. Please try again");
                outputDeviceId = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Port is clear.");

            #endregion

            // output = outputDevice.SendEvent(new NoteOnEvent(SevenBitNumber.Parse("note"), SevenBitNumber.Parse("velocity")));
            if (outputTemp > OutputDevice.GetDevicesCount())
            {
                outputTemp = OutputDevice.GetDevicesCount();
            }
            using var outputDevice = OutputDevice.GetById(outputTemp);
             

            #region Input

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
                int velocity = int.Parse(inputs[1]);
                int note = int.Parse(inputs[0]);
                //DoExecution(note);
                outputDevice.SendEvent(new NoteOnEvent(SevenBitNumber.Parse(note.ToString()), SevenBitNumber.Parse(velocity.ToString())));
                Console.WriteLine($"{note}:{velocity}");
            }

            #endregion

            void DoExecution(int note)
            {
                switch (note)
                {
                    case 11:
                    {
                        Console.WriteLine("Case 11");
                        break;
                    }
                    case 12:
                    {
                        Console.WriteLine("Case 12");
                        break;
                    }
                    case 13:
                    {
                        Console.WriteLine("Case 13");
                        break;
                    }
                    case 14:
                    {
                        Console.WriteLine("Case 14");
                        break;
                    }
                    case 15:
                    {
                        Console.WriteLine("Case 15");
                        break;
                    }
                    case 16:
                    {
                        Console.WriteLine("Case 16");
                        break;
                    }
                    case 17:
                    {
                        Console.WriteLine("Case 17");
                        break;
                    }
                    case 18:
                    {
                        Console.WriteLine("Case 18");
                        break;
                    }
                    case 21:
                    {
                        Console.WriteLine("Case 21");
                        break;
                    }
                    case 22:
                    {
                        Console.WriteLine("Case 22");
                        break;
                    }
                    case 23:
                    {
                        Console.WriteLine("Case 23");
                        break;
                    }
                    case 24:
                    {
                        Console.WriteLine("Case 24");
                        break;
                    }
                    case 25:
                    {
                        Console.WriteLine("Case 25");
                        break;
                    }
                    case 26:
                    {
                        Console.WriteLine("Case 26");
                        break;
                    }
                    case 27:
                    {
                        Console.WriteLine("Case 27");
                        break;
                    }
                    case 28:
                    {
                        Console.WriteLine("Case 28");
                        break;
                    }
                    case 31:
                    {
                        Console.WriteLine("Case 31");
                        break;
                    }
                    case 32:
                    {
                        Console.WriteLine("Case 32");
                        break;
                    }
                    case 33:
                    {
                        Console.WriteLine("Case 33");
                        break;
                    }
                    case 34:
                    {
                        Console.WriteLine("Case 34");
                        break;
                    }
                    case 35:
                    {
                        Console.WriteLine("Case 35");
                        break;
                    }
                    case 36:
                    {
                        Console.WriteLine("Case 36");
                        break;
                    }
                    case 37:
                    {
                        Console.WriteLine("Case 37");
                        break;
                    }
                    case 38:
                    {
                        Console.WriteLine("Case 38");
                        break;
                    }
                    case 41:
                    {
                        Console.WriteLine("Case 41");
                        break;
                    }
                    case 42:
                    {
                        Console.WriteLine("Case 42");
                        break;
                    }
                    case 43:
                    {
                        Console.WriteLine("Case 43");
                        break;
                    }
                    case 44:
                    {
                        Console.WriteLine("Case 44");
                        break;
                    }
                    case 45:
                    {
                        Console.WriteLine("Case 45");
                        break;
                    }
                    case 46:
                    {
                        Console.WriteLine("Case 46");
                        break;
                    }
                    case 47:
                    {
                        Console.WriteLine("Case 47");
                        break;
                    }
                    case 48:
                    {
                        Console.WriteLine("Case 48");
                        break;
                    }
                    case 51:
                    {
                        Console.WriteLine("Case 51");
                        break;
                    }
                    case 52:
                    {
                        Console.WriteLine("Case 52");
                        break;
                    }
                    case 53:
                    {
                        Console.WriteLine("Case 53");
                        break;
                    }
                    case 54:
                    {
                        Console.WriteLine("Case 54");
                        break;
                    }
                    case 55:
                    {
                        Console.WriteLine("Case 55");
                        break;
                    }
                    case 56:
                    {
                        Console.WriteLine("Case 56");
                        break;
                    }
                    case 57:
                    {
                        Console.WriteLine("Case 57");
                        break;
                    }
                    case 58:
                    {
                        Console.WriteLine("Case 58");
                        break;
                    }
                    case 61:
                    {
                        Console.WriteLine("Case 61");
                        break;
                    }
                    case 62:
                    {
                        Console.WriteLine("Case 62");
                        break;
                    }
                    case 63:
                    {
                        Console.WriteLine("Case 63");
                        break;
                    }
                    case 64:
                    {
                        Console.WriteLine("Case 64");
                        break;
                    }
                    case 65:
                    {
                        Console.WriteLine("Case 65");
                        break;
                    }
                    case 66:
                    {
                        Console.WriteLine("Case 66");
                        break;
                    }
                    case 67:
                    {
                        Console.WriteLine("Case 67");
                        break;
                    }
                    case 68:
                    {
                        Console.WriteLine("Case 68");
                        break;
                    }
                    case 71:
                    {
                        Console.WriteLine("Case 71");
                        break;
                    }
                    case 72:
                    {
                        Console.WriteLine("Case 72");
                        break;
                    }
                    case 73:
                    {
                        Console.WriteLine("Case 73");
                        break;
                    }
                    case 74:
                    {
                        Console.WriteLine("Case 74");
                        break;
                    }
                    case 75:
                    {
                        Console.WriteLine("Case 75");
                        break;
                    }
                    case 76:
                    {
                        Console.WriteLine("Case 76");
                        break;
                    }
                    case 77:
                    {
                        Console.WriteLine("Case 77");
                        break;
                    }
                    case 78:
                    {
                        Console.WriteLine("Case 78");
                        break;
                    }
                    case 81:
                    {
                        Console.WriteLine("Case 81");
                        break;
                    }
                    case 82:
                    {
                        Console.WriteLine("Case 82");
                        break;
                    }
                    case 83:
                    {
                        Console.WriteLine("Case 83");
                        break;
                    }
                    case 84:
                    {
                        Console.WriteLine("Case 84");
                        break;
                    }
                    case 85:
                    {
                        Console.WriteLine("Case 85");
                        break;
                    }
                    case 86:
                    {
                        Console.WriteLine("Case 86");
                        break;
                    }
                    case 87:
                    {
                        Console.WriteLine("Case 87");
                        break;
                    }
                    case 88:
                    {
                        Console.WriteLine("Case 88");
                        break;
                    }
                }
            }
        }
    }
}