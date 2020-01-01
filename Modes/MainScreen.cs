﻿using System;
using System.Windows;

namespace AdvMidi.Modes
{
    public static class MainScreen
    {
        public static void ModeSelection()
        {
            Console.WriteLine("What mode do you want to do?\n");
            Console.WriteLine(@"1:   Velocity to Light colors
2:   User Execution - some things might not work yet idk
3:   midi to key stroke  
4:   image - not implemented yet
4.5: gif - not implemented yet
5:   Tetris - not implemented yet
6:   Snake - not implemented yet
7:   Audio visualizer - not implemented yet
8:   Minesweeper - not implemented yet
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
                case 2:
                    Console.Clear();
                    UserExecution.Execution();
                    break;
                case 3:
                    Console.Clear();
                    new Application().Run(new MainWindow());
                    Console.WriteLine("Key Presets finished. You can use it now.");
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