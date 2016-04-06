using System;
using System.Diagnostics;

namespace AcceptanceTests.Infrastructure
{
    public static class TheNewTwitterApplication
    {
        static Process _application;

        public static void BootstrapApplication()
        {
            _application = new Process();
            string TheNewTwitterApplicationPath = $"{AppDomain.CurrentDomain.BaseDirectory}/CommandLine.exe";

            var startInfo = new ProcessStartInfo(TheNewTwitterApplicationPath)
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };

            _application.StartInfo = startInfo;
        }

        public static void Start()
        {
            _application.Start();
        }

        public static void Stop()
        {
            _application.Kill();
        }

        public static void PublishMessage(string message)
        {
            _application.StandardInput.WriteLine(message);
        }

        public static string ReadConsole()
        {
            return _application.StandardOutput.ReadLine();
        }
    }
}
