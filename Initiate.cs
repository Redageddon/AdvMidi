using System;
using Melanchall.DryWetMidi.Devices;

namespace AdvMidi
{
    public class Initiate
    {
        public static (int, int) Devices()
        {
            return (Input(), Output());
        }
        private static int Input() 
        {
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
            return inputTemp;
        }

        private static int Output()
        {
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
            if (outputTemp > OutputDevice.GetDevicesCount())
            {
                outputTemp = OutputDevice.GetDevicesCount();
            }
            return outputTemp;
        }
    }
}