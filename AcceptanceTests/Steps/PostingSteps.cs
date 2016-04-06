using AcceptanceTests.Infrastructure;
using Should;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class PostingSteps
    {
        [Given(@"I have started The New Twitter")]
        public void GivenIHaveStartedTheNewTwitter()
        {
            TheNewTwitterApplication.Start();
        }

        [When(@"I publish a message to a personal timeline")]
        public void WhenIPublishAMessageToAPersonalTimeline()
        {
            TheNewTwitterApplication.PublishMessage("Alice -> I love the weather today");
        }
        
        [Then(@"message appears in users timeline")]
        public void ThenMessageAppearsInUsersTimeline()
        {
            TheNewTwitterApplication.PublishMessage("Alice");
            var timeline = TheNewTwitterApplication.ReadConsole();
            timeline.ShouldContain("I love the weather today");
        }
    }
}
