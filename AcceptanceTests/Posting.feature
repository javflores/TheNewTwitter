Feature: Posting

Scenario: User can publish messages to a personal timeline
	Given I have started The New Twitter	
	When I publish a message to a personal timeline
	Then message appears in users timeline
