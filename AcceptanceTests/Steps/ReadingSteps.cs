using AcceptanceTests.Infrastructure;
using Should;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Scope(Feature = "Reading")]
    [Binding]
    public class ReadingSteps
    {
        [Given(@"I have started The New Twitter")]
        public void GivenIHaveStartedTheNewTwitter()
        {
            TheNewTwitterApplication.Start();
        }

        [Given(@"I have published some messages to a personal timeline")]
        public void GivenIHavePublishedSomeMessagesToAPersonalTimeline()
        {
            TheNewTwitterApplication.PublishMessage("Alice -> My first message");
            TheNewTwitterApplication.PublishMessage("Alice -> My second message");
        }
        
        [When(@"I read users timeline")]
        public void WhenIReadUsersTimeline()
        {
            TheNewTwitterApplication.PublishMessage("Alice");
        }
        
        [Then(@"I view the messages")]
        public void ThenIViewTheMessages()
        {
            var secondMessage = TheNewTwitterApplication.ReadConsole();
            secondMessage.ShouldContain("My second message");
            var firstMessage = TheNewTwitterApplication.ReadConsole();
            firstMessage.ShouldContain("My first message");
        }
    }
}
