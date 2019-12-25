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
            int inputTemp = FlowInitiation.Devices().Item1;
            using var inputDevice = InputDevice.GetById(inputTemp);

            inputDevice.EventReceived += OnEventReceived;
            do
            {
                inputDevice.StartEventsListening();
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);

            void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
            {
                if (e.Event.EventType.ToString() != "NoteOn") return;
                string keyEvent = e.Event.ToString();
                var inputs = keyEvent.Split(',');
                int note = int.Parse(inputs[0]);
                if (int.Parse(inputs[1]) == 127) DoExecution(note);
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
            int x = note - 11 - 2 * (note / 10 - 1);
            Console.WriteLine(x);
            await CaseT[x].RunAsync();
        }
    }
}