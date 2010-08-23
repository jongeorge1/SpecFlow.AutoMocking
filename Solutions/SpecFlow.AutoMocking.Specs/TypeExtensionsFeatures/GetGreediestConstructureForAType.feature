Feature: Get greediest constructor for a type
	In order to automock all dependencies
	As a developer
	I want to find the greediest constructor for a type

Scenario: Type with no constructor parameters
	Given I have a type that only has the default constructor
	When I ask for the greediest constructor
	Then the default constructor should be returned

Scenario: Type with single parameterised constructor
	Given I have a type that has a single parameterised constructor
	When I ask for the greediest constructor
	Then the single constructor should be returned

Scenario: Type with multiple parameterised constructor
	Given I have a type that multiple parameterised constructors
	When I ask for the greediest constructor
	Then the constructor with the most parameters should be returned
