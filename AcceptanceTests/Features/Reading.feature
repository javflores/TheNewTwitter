Feature: Reading

Scenario: View users timeline
	Given I have started The New Twitter
	And I have published some messages to a personal timeline
	When I read users timeline
	Then I view the messages
