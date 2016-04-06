using System;
using System.Diagnostics;
using AcceptanceTests.Infrastructure;
using Should;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class PostingSteps
    {
        TheNewTwitterApplication _theNewTwitter;

        [Given(@"I have started The New Twitter")]
        public void GivenIHaveStartedTheNewTwitter()
        {
            _theNewTwitter = new TheNewTwitterApplication();
            _theNewTwitter.Start();
        }

        [When(@"I publish a message to a personal timeline")]
        public void WhenIPublishAMessageToAPersonalTimeline()
        {
            _theNewTwitter.PublishMessage("Alice -> I love the weather today");
        }
        
        [Then(@"message appears in users timeline")]
        public void ThenMessageAppearsInUsersTimeline()
        {
            _theNewTwitter.PublishMessage("Alice");
            var timeline = _theNewTwitter.ReadConsole();
            timeline.ShouldContain("I love the weather today");

            _theNewTwitter.Stop();
        }
    }
}
