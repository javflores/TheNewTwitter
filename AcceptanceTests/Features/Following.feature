Feature: Following

Scenario: User can subscribe to other users' timelines and view an aggregated list of all subscriptions.
	Given I have published some messages
	And Another user has message in its timeline
	And I have opted to follow user
	When I want to see my wall
	Then I can see view messages
