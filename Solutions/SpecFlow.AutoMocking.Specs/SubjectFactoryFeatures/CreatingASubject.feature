Feature: Creating a subject
    In order to provide a test subject to inherited classes
    As a developer
    I want to be able to create a test subject given its type

Scenario: Create a subject when no dependencies are required
    When I request a subject with no dependencies be created
    Then an instance of the subject should be returned

Scenario: Create a subject when dependencies are required
    When I request a subject with dependencies be created
    Then an instance of the subject should be returned
    And it should pass the constructor parameters retrieved from the subject dependency builder
