using System;
using System.IO;
using AdvMidi.PreFab;
using Melanchall.DryWetMidi.Devices;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace AdvMidi
{
    public static class UserExecution
    {
        private static Script<object> Case11 { get; set; }
        private static Script<object> Case12 { get; set; }
        private static Script<object> Case13 { get; set; }
        private static Script<object> Case14 { get; set; }
        private static Script<object> Case15 { get; set; }
        private static Script<object> Case16 { get; set; }
        private static Script<object> Case17 { get; set; }
        private static Script<object> Case18 { get; set; }
        private static Script<object> Case21 { get; set; }
        private static Script<object> Case22 { get; set; }
        private static Script<object> Case23 { get; set; }
        private static Script<object> Case24 { get; set; }
        private static Script<object> Case25 { get; set; }
        private static Script<object> Case26 { get; set; }
        private static Script<object> Case27 { get; set; }
        private static Script<object> Case28 { get; set; }
        private static Script<object> Case31 { get; set; }
        private static Script<object> Case32 { get; set; }
        private static Script<object> Case33 { get; set; }
        private static Script<object> Case34 { get; set; }
        private static Script<object> Case35 { get; set; }
        private static Script<object> Case36 { get; set; }
        private static Script<object> Case37 { get; set; }
        private static Script<object> Case38 { get; set; }
        private static Script<object> Case41 { get; set; }
        private static Script<object> Case42 { get; set; }
        private static Script<object> Case43 { get; set; }
        private static Script<object> Case44 { get; set; }
        private static Script<object> Case45 { get; set; }
        private static Script<object> Case46 { get; set; }
        private static Script<object> Case47 { get; set; }
        private static Script<object> Case48 { get; set; }
        private static Script<object> Case51 { get; set; }
        private static Script<object> Case52 { get; set; }
        private static Script<object> Case53 { get; set; }
        private static Script<object> Case54 { get; set; }
        private static Script<object> Case55 { get; set; }
        private static Script<object> Case56 { get; set; }
        private static Script<object> Case57 { get; set; }
        private static Script<object> Case58 { get; set; }
        private static Script<object> Case61 { get; set; }
        private static Script<object> Case62 { get; set; }
        private static Script<object> Case63 { get; set; }
        private static Script<object> Case64 { get; set; }
        private static Script<object> Case65 { get; set; }
        private static Script<object> Case66 { get; set; }
        private static Script<object> Case67 { get; set; }
        private static Script<object> Case68 { get; set; }
        private static Script<object> Case71 { get; set; }
        private static Script<object> Case72 { get; set; }
        private static Script<object> Case73 { get; set; }
        private static Script<object> Case74 { get; set; }
        private static Script<object> Case75 { get; set; }
        private static Script<object> Case76 { get; set; }
        private static Script<object> Case77 { get; set; }
        private static Script<object> Case78 { get; set; }
        private static Script<object> Case81 { get; set; }
        private static Script<object> Case82 { get; set; }
        private static Script<object> Case83 { get; set; }
        private static Script<object> Case84 { get; set; }
        private static Script<object> Case85 { get; set; }
        private static Script<object> Case86 { get; set; }
        private static Script<object> Case87 { get; set; }
        private static Script<object> Case88 { get; set; }


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

        private static void PreloadAllExecutionFiles()
        {
            Case11 = CSharpScript.Create(File.ReadAllText(@"UserExecution/11.txt"));
            Case12 = CSharpScript.Create(File.ReadAllText(@"UserExecution/12.txt"));
            Case13 = CSharpScript.Create(File.ReadAllText(@"UserExecution/13.txt"));
            Case14 = CSharpScript.Create(File.ReadAllText(@"UserExecution/14.txt"));
            Case15 = CSharpScript.Create(File.ReadAllText(@"UserExecution/15.txt"));
            Case16 = CSharpScript.Create(File.ReadAllText(@"UserExecution/16.txt"));
            Case17 = CSharpScript.Create(File.ReadAllText(@"UserExecution/17.txt"));
            Case18 = CSharpScript.Create(File.ReadAllText(@"UserExecution/18.txt"));
            Case21 = CSharpScript.Create(File.ReadAllText(@"UserExecution/21.txt"));
            Case22 = CSharpScript.Create(File.ReadAllText(@"UserExecution/22.txt"));
            Case23 = CSharpScript.Create(File.ReadAllText(@"UserExecution/23.txt"));
            Case24 = CSharpScript.Create(File.ReadAllText(@"UserExecution/24.txt"));
            Case25 = CSharpScript.Create(File.ReadAllText(@"UserExecution/25.txt"));
            Case26 = CSharpScript.Create(File.ReadAllText(@"UserExecution/26.txt"));
            Case27 = CSharpScript.Create(File.ReadAllText(@"UserExecution/27.txt"));
            Case28 = CSharpScript.Create(File.ReadAllText(@"UserExecution/28.txt"));
            Case31 = CSharpScript.Create(File.ReadAllText(@"UserExecution/31.txt"));
            Case32 = CSharpScript.Create(File.ReadAllText(@"UserExecution/32.txt"));
            Case33 = CSharpScript.Create(File.ReadAllText(@"UserExecution/33.txt"));
            Case34 = CSharpScript.Create(File.ReadAllText(@"UserExecution/34.txt"));
            Case35 = CSharpScript.Create(File.ReadAllText(@"UserExecution/35.txt"));
            Case36 = CSharpScript.Create(File.ReadAllText(@"UserExecution/36.txt"));
            Case37 = CSharpScript.Create(File.ReadAllText(@"UserExecution/37.txt"));
            Case38 = CSharpScript.Create(File.ReadAllText(@"UserExecution/38.txt"));
            Case41 = CSharpScript.Create(File.ReadAllText(@"UserExecution/41.txt"));
            Case42 = CSharpScript.Create(File.ReadAllText(@"UserExecution/42.txt"));
            Case43 = CSharpScript.Create(File.ReadAllText(@"UserExecution/43.txt"));
            Case44 = CSharpScript.Create(File.ReadAllText(@"UserExecution/44.txt"));
            Case45 = CSharpScript.Create(File.ReadAllText(@"UserExecution/45.txt"));
            Case46 = CSharpScript.Create(File.ReadAllText(@"UserExecution/46.txt"));
            Case47 = CSharpScript.Create(File.ReadAllText(@"UserExecution/47.txt"));
            Case48 = CSharpScript.Create(File.ReadAllText(@"UserExecution/48.txt"));
            Case51 = CSharpScript.Create(File.ReadAllText(@"UserExecution/51.txt"));
            Case52 = CSharpScript.Create(File.ReadAllText(@"UserExecution/52.txt"));
            Case53 = CSharpScript.Create(File.ReadAllText(@"UserExecution/53.txt"));
            Case54 = CSharpScript.Create(File.ReadAllText(@"UserExecution/54.txt"));
            Case55 = CSharpScript.Create(File.ReadAllText(@"UserExecution/55.txt"));
            Case56 = CSharpScript.Create(File.ReadAllText(@"UserExecution/56.txt"));
            Case57 = CSharpScript.Create(File.ReadAllText(@"UserExecution/57.txt"));
            Case58 = CSharpScript.Create(File.ReadAllText(@"UserExecution/58.txt"));
            Case61 = CSharpScript.Create(File.ReadAllText(@"UserExecution/61.txt"));
            Case62 = CSharpScript.Create(File.ReadAllText(@"UserExecution/62.txt"));
            Case63 = CSharpScript.Create(File.ReadAllText(@"UserExecution/63.txt"));
            Case64 = CSharpScript.Create(File.ReadAllText(@"UserExecution/64.txt"));
            Case65 = CSharpScript.Create(File.ReadAllText(@"UserExecution/65.txt"));
            Case66 = CSharpScript.Create(File.ReadAllText(@"UserExecution/66.txt"));
            Case67 = CSharpScript.Create(File.ReadAllText(@"UserExecution/67.txt"));
            Case68 = CSharpScript.Create(File.ReadAllText(@"UserExecution/68.txt"));
            Case71 = CSharpScript.Create(File.ReadAllText(@"UserExecution/71.txt"));
            Case72 = CSharpScript.Create(File.ReadAllText(@"UserExecution/72.txt"));
            Case73 = CSharpScript.Create(File.ReadAllText(@"UserExecution/73.txt"));
            Case74 = CSharpScript.Create(File.ReadAllText(@"UserExecution/74.txt"));
            Case75 = CSharpScript.Create(File.ReadAllText(@"UserExecution/75.txt"));
            Case76 = CSharpScript.Create(File.ReadAllText(@"UserExecution/76.txt"));
            Case77 = CSharpScript.Create(File.ReadAllText(@"UserExecution/77.txt"));
            Case78 = CSharpScript.Create(File.ReadAllText(@"UserExecution/78.txt"));
            Case81 = CSharpScript.Create(File.ReadAllText(@"UserExecution/81.txt"));
            Case82 = CSharpScript.Create(File.ReadAllText(@"UserExecution/82.txt"));
            Case83 = CSharpScript.Create(File.ReadAllText(@"UserExecution/83.txt"));
            Case84 = CSharpScript.Create(File.ReadAllText(@"UserExecution/84.txt"));
            Case85 = CSharpScript.Create(File.ReadAllText(@"UserExecution/85.txt"));
            Case86 = CSharpScript.Create(File.ReadAllText(@"UserExecution/86.txt"));
            Case87 = CSharpScript.Create(File.ReadAllText(@"UserExecution/87.txt"));
            Case88 = CSharpScript.Create(File.ReadAllText(@"UserExecution/88.txt"));
        }

        private static async void DoExecution(int note)
        {
            switch (note)
            {
                case 11:
                {
                    await Case11.RunAsync();
                    break;
                }
                case 12:
                {
                    await Case12.RunAsync();
                    break;
                }
                case 13:
                {
                    await Case13.RunAsync();
                    break;
                }
                case 14:
                {
                    await Case14.RunAsync();
                    break;
                }
                case 15:
                {
                    await Case15.RunAsync();
                    break;
                }
                case 16:
                {
                    await Case16.RunAsync();
                    break;
                }
                case 17:
                {
                    await Case17.RunAsync();
                    break;
                }
                case 18:
                {
                    await Case18.RunAsync();
                    break;
                }
                case 21:
                {
                    await Case21.RunAsync();
                    break;
                }
                case 22:
                {
                    await Case22.RunAsync();
                    break;
                }
                case 23:
                {
                    await Case23.RunAsync();
                    break;
                }
                case 24:
                {
                    await Case24.RunAsync();
                    break;
                }
                case 25:
                {
                    await Case25.RunAsync();
                    break;
                }
                case 26:
                {
                    await Case26.RunAsync();
                    break;
                }
                case 27:
                {
                    await Case27.RunAsync();
                    break;
                }
                case 28:
                {
                    await Case28.RunAsync();
                    break;
                }
                case 31:
                {
                    await Case31.RunAsync();
                    break;
                }
                case 32:
                {
                    await Case32.RunAsync();
                    break;
                }
                case 33:
                {
                    await Case33.RunAsync();
                    break;
                }
                case 34:
                {
                    await Case34.RunAsync();
                    break;
                }
                case 35:
                {
                    await Case35.RunAsync();
                    break;
                }
                case 36:
                {
                    await Case36.RunAsync();
                    break;
                }
                case 37:
                {
                    await Case37.RunAsync();
                    break;
                }
                case 38:
                {
                    await Case38.RunAsync();
                    break;
                }
                case 41:
                {
                    await Case41.RunAsync();
                    break;
                }
                case 42:
                {
                    await Case42.RunAsync();
                    break;
                }
                case 43:
                {
                    await Case43.RunAsync();
                    break;
                }
                case 44:
                {
                    await Case44.RunAsync();
                    break;
                }
                case 45:
                {
                    await Case45.RunAsync();
                    break;
                }
                case 46:
                {
                    await Case46.RunAsync();
                    break;
                }
                case 47:
                {
                    await Case47.RunAsync();
                    break;
                }
                case 48:
                {
                    await Case48.RunAsync();
                    break;
                }
                case 51:
                {
                    await Case51.RunAsync();
                    break;
                }
                case 52:
                {
                    await Case52.RunAsync();
                    break;
                }
                case 53:
                {
                    await Case53.RunAsync();
                    break;
                }
                case 54:
                {
                    await Case54.RunAsync();
                    break;
                }
                case 55:
                {
                    await Case55.RunAsync();
                    break;
                }
                case 56:
                {
                    await Case56.RunAsync();
                    break;
                }
                case 57:
                {
                    await Case57.RunAsync();
                    break;
                }
                case 58:
                {
                    await Case58.RunAsync();
                    break;
                }
                case 61:
                {
                    await Case61.RunAsync();
                    break;
                }
                case 62:
                {
                    await Case62.RunAsync();
                    break;
                }
                case 63:
                {
                    await Case63.RunAsync();
                    break;
                }
                case 64:
                {
                    await Case64.RunAsync();
                    break;
                }
                case 65:
                {
                    await Case65.RunAsync();
                    break;
                }
                case 66:
                {
                    await Case66.RunAsync();
                    break;
                }
                case 67:
                {
                    await Case67.RunAsync();
                    break;
                }
                case 68:
                {
                    await Case68.RunAsync();
                    break;
                }
                case 71:
                {
                    await Case71.RunAsync();
                    break;
                }
                case 72:
                {
                    await Case72.RunAsync();
                    break;
                }
                case 73:
                {
                    await Case73.RunAsync();
                    break;
                }
                case 74:
                {
                    await Case74.RunAsync();
                    break;
                }
                case 75:
                {
                    await Case75.RunAsync();
                    break;
                }
                case 76:
                {
                    await Case76.RunAsync();
                    break;
                }
                case 77:
                {
                    await Case77.RunAsync();
                    break;
                }
                case 78:
                {
                    await Case78.RunAsync();
                    break;
                }
                case 81:
                {
                    await Case81.RunAsync();
                    break;
                }
                case 82:
                {
                    await Case82.RunAsync();
                    break;
                }
                case 83:
                {
                    await Case83.RunAsync();
                    break;
                }
                case 84:
                {
                    await Case84.RunAsync();
                    break;
                }
                case 85:
                {
                    await Case85.RunAsync();
                    break;
                }
                case 86:
                {
                    await Case86.RunAsync();
                    break;
                }
                case 87:
                {
                    await Case87.RunAsync();
                    break;
                }
                case 88:
                {
                    await Case88.RunAsync();
                    break;
                }

                default:
                    Console.WriteLine("You have some weird launchpad with more than 64 buttons.");
                    break;
            }
        }
    }
}