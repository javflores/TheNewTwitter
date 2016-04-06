using TechTalk.SpecFlow;

namespace AcceptanceTests.Infrastructure
{
    [Binding]
    class ApplicationProcess
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            TheNewTwitterApplication.BootstrapApplication();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            TheNewTwitterApplication.Stop();
        }
    }
}
