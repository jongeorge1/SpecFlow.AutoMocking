Feature: Get all headlines
	In order to keep up to date with the news
	As a user
	I want to get all news headlines

Scenario: Getting all headlines
	Given There are 20 headlines available
	When I ask for all the headlines
	Then a list of 20 headlines should be returned

Scenario: Getting all headlines when there are no headlines
	Given There are 0 headlines available
	When I ask for all the headlines
	Then a list of 0 headlines should be returned
