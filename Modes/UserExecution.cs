using System;
using System.Collections.Generic;
using System.IO;
using AdvMidi.PreFab;
using Melanchall.DryWetMidi.Devices;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace AdvMidi
{
    public static class UserExecution
    {
        private static List<Script<object>> CaseT { get; set; }


        public static void Execution()
        {
            PreloadAllExecutionFiles();
            (int inputTemp, int outputTemp) = FlowInitiation.Devices();
            using var outputDevice = OutputDevice.GetById(outputTemp);
            using var inputDevice = InputDevice.GetById(inputTemp);

            inputDevice.EventReceived += OnEventReceived;
            do
            {
                inputDevice.StartEventsListening();
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);

            void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
            {
                if (e.Event.EventType.ToString() == "NoteOn")
                {
                    string keyEvent = e.Event.ToString();
                    var inputs = keyEvent.Split(',');
                    int note = int.Parse(inputs[0]);
                    if (int.Parse(inputs[1]) == 127)
                    {
                        DoExecution(note);
                        Console.WriteLine(note);
                    }
                }
            }
        }
        
        private static bool IsIndexValid(int i)
        {
            if (!i.ToString().Contains("9") && !i.ToString().Contains("0")) return true;
            return false;
        }


        private static void PreloadAllExecutionFiles()
        {
            CaseT = new List<Script<object>>();
            for (int i = 11; i < 89; i++)
            {
                if (IsIndexValid(i))
                {
                    if (!File.Exists($"UserExecution/{i}.txt") || File.ReadAllText($"UserExecution/{i}.txt") == "")
                    {
                        File.WriteAllText($"UserExecution/{i}.txt", "//write your code here");
                    }
                    CaseT.Add(CSharpScript.Create(File.ReadAllText($"UserExecution/{i}.txt")));
                }
            }
        }

        private static async void DoExecution(int note)
        {
            Dictionary<int, int> notes = new Dictionary<int, int>()
            {
                {11,  0}, {12,  1}, {13,  2}, {14,  3}, {15,  4}, {16,  5}, {17,  6}, {18,  7}, {21,  8}, {22,  9}, 
                {23, 10}, {24, 11}, {25, 12}, {26, 13}, {27, 14}, {28, 15}, {31, 16}, {32, 17}, {33, 18}, {34, 19}, 
                {35, 20}, {36, 21}, {37, 22}, {38, 23}, {41, 24}, {42, 25}, {43, 26}, {44, 27}, {45, 28}, {46, 29}, 
                {47, 30}, {48, 31}, {51, 32}, {52, 33}, {53, 34}, {54, 35}, {55, 36}, {56, 37}, {57, 38}, {58, 39}, 
                {61, 40}, {62, 41}, {63, 42}, {64, 43}, {65, 44}, {66, 45}, {67, 46}, {68, 47}, {71, 48}, {72, 49},
                {73, 50}, {74, 51}, {75, 52}, {76, 53}, {77, 54}, {78, 55}, {81, 56}, {82, 57}, {83, 58}, {84, 59}, 
                {85, 60}, {86, 61}, {87, 62}, {88, 63}
            };
            await CaseT[notes[note]].RunAsync();
            
        }
    }
}