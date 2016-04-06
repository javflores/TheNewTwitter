using System;
using System.Diagnostics;

namespace AcceptanceTests.Infrastructure
{
    public class TheNewTwitterApplication
    {
        readonly Process _application;

        public TheNewTwitterApplication()
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
            _application.Start();
        }

        ~TheNewTwitterApplication()
        {
            _application.Kill();
        }

        public void PublishMessage(string message)
        {
            _application.StandardInput.WriteLine(message);
        }

        public string ReadConsole()
        {
            return _application.StandardOutput.ReadLine();
        }
    }
}
