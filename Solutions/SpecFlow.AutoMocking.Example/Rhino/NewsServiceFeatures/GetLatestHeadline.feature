Feature: Get latest headline
	In order to keep up to date with the news
	As a user
	I want to see the latest headline

Scenario: Getting latest headline
	Given There are 5 headlines available
	When I ask for the latest headline
	Then the most recent headline should be returned

Scenario: Getting latest headline when there are no headlines
	Given There are 0 headlines available
	When I ask for the latest headline
	Then no result should be returned
