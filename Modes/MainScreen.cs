using System;

namespace AdvMidi
{
    public class MainScreen
    {
        public static void ModeSelection()
        {
            Console.WriteLine("What mode do you want to do?\n");
            Console.WriteLine(@"1: Velocity to Light colors
2:   User Execution-in progress
3:   Audio visualizer-not implemented yet
4:   image - not implemented yet
4.5: gif - not implemented yet
5:   Tetris - not implemented yet
");
            int intModeChoice;
            while (!int.TryParse(Console.ReadLine(), out intModeChoice))
            {
                Console.WriteLine("You did not enter a number. Please try again.");
            }
            switch (intModeChoice)
            {
                case 1:
                    Console.Clear();
                    VeloToLight.VelocityToLight();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("This has not been implemented yet");
                    Console.ReadKey();
                    break;
            }
        }
    }
}