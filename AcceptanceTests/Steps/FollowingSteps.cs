using AcceptanceTests.Infrastructure;
using Should;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class FollowingSteps
    {
        [Given(@"I have published some messages")]
        public void GivenIHavePublishedSomeMessages()
        {
            TheNewTwitterApplication.Start();
            TheNewTwitterApplication.PublishMessage("Juan -> My message");
        }

        [Given(@"Another user has message in its timeline")]
        public void GivenAnotherUserHasMessageInItsTimeline()
        {
            TheNewTwitterApplication.PublishMessage("Another -> This is other message");
        }

        [Given(@"I have opted to follow user")]
        public void GivenIHaveOptedToFollowUser()
        {
            TheNewTwitterApplication.PublishMessage("Juan follows Another");
        }
        
        [When(@"I want to see my wall")]
        public void WhenIWantToSeeMyWall()
        {
            TheNewTwitterApplication.PublishMessage("Juan wall");
        }
        
        [Then(@"I can see view messages")]
        public void ThenICanSeeViewMessages()
        {
            var secondMessage = TheNewTwitterApplication.ReadConsole();
            secondMessage.ShouldContain("Another - This is other message");
            var firstMessage = TheNewTwitterApplication.ReadConsole();
            firstMessage.ShouldContain("Juan - My message");
        }
    }
}
