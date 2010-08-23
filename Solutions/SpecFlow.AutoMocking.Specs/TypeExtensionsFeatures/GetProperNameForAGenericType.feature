Feature: Get proper name for a generic type
	In order to avoid registering multiple arguments with the same type
	As a developer
	I want to get the proper name of a generic type

Scenario: Get proper name for type with no type parameter
	Given I have a class with no type parameters
	When I ask for the proper name
	Then the result should contain the proper name for the type

Scenario: Get proper name for type with single type parameter
	Given I have a class with a single type parameter
	When I ask for the proper name
	Then the result should contain the proper name for the type

Scenario: Get proper name for type with multiple type parameters
	Given I have a class with a multiple type parameters
	When I ask for the proper name
	Then the result should contain the proper name for the type