Feature: View latest news headline
    In order to keep up to date with the news
    As a user
    I want to view the latest news headline

Scenario: Viewing latest headline
    Given I am viewing news
    When I ask for the view
    Then the result should contain the latest headline
