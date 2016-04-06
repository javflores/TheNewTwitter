using System;
using System.Diagnostics;
using Should;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class PostingSteps
    {
        readonly string TheNewTwitterApplicationPath = $"{AppDomain.CurrentDomain.BaseDirectory}/CommandLine.exe";
        Process _theNewTwitter;

        [Given(@"I have started The New Twitter")]
        public void GivenIHaveStartedTheNewTwitter()
        {
            _theNewTwitter = new Process();
            var startInfo = new ProcessStartInfo(TheNewTwitterApplicationPath)
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };

            _theNewTwitter.StartInfo = startInfo;
            _theNewTwitter.Start();
        }

        [When(@"I publish a message to a personal timeline")]
        public void WhenIPublishAMessageToAPersonalTimeline()
        {
            _theNewTwitter.StandardInput.WriteLine("Alice -> I love the weather today");
        }
        
        [Then(@"message appears in users timeline")]
        public void ThenMessageAppearsInUsersTimeline()
        {
            _theNewTwitter.StandardInput.WriteLine("Alice");
            var timeline = _theNewTwitter.StandardOutput.ReadLine();

            timeline.ShouldContain("I love the weather today");

            _theNewTwitter.Kill();
        }
    }
}
