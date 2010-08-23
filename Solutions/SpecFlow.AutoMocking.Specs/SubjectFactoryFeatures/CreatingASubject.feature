Feature: Creating a subject
    In order to provide a test subject to inherited classes
    As a developer
    I want to be able to create a test subject given its type

Scenario: Create a subject when no dependencies are required
    Given I have a subject that has no dependencies
    When I request the subject be created
    Then an instance of the subject should be returned
