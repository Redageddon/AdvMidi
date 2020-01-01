using System;
using Melanchall.DryWetMidi.Devices;

namespace AdvMidi.Modes.PreFab
{
    public static class FlowInitiation
    {
        public static (int, int) Devices()
        {
            return (Input(), Output());
        }
        private static int Input()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Pick a midi input device.\n");
            foreach (var device in InputDevice.GetAll())
            {
                Console.WriteLine($"{device.Id}: {device}", Console.ForegroundColor = ConsoleColor.White);
            }
            Console.WriteLine();
            
            int inputTemp;
            while (!int.TryParse(Console.ReadLine(), out inputTemp))
            {
                Console.WriteLine("You did not enter a number. Please try again");
            }
            Console.Clear();
            return inputTemp;
        }

        private static int Output()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pick a midi output device.\n");
            foreach (var device in InputDevice.GetAll())
                Console.WriteLine($"{device.Id}: {device}", Console.ForegroundColor = ConsoleColor.White);
            Console.WriteLine();

            
            int outputTemp;
            while (!int.TryParse(Console.ReadLine(), out outputTemp))
            {
                Console.WriteLine("You did not enter a number. Please try again");
            }
            Console.Clear();
            if (outputTemp > OutputDevice.GetDevicesCount())
            {
                outputTemp = OutputDevice.GetDevicesCount();
            }
            return outputTemp;
        }
    }
}