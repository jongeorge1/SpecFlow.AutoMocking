Feature: Create a subject
	In order to create a subject with all of the expected dependencies provided
	As a developer
	I want to ask the observation context to create the subject

Scenario: Create a subject
    Given I have an observation context
	When I ask the observation context to create the subject
    Then the observation context should use the subject factory to create the subject
    And the subject should be returned
