Feature: Create a dependency
    In order to create mocks that will be used to initialise the subject of my tests
    As a developer
    I want to ask the observation context to create the mock

Scenario: Create a dependency
    Given I have an observation context
    When I ask the observation context to create a mock a dependency
    Then the observation context should use the subject dependency builder to create the mock
    And the mock should be returned
