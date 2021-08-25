@Counter
Feature: Counter should be property incrementing its value

Scenario: Click increases the counter 2
	Given a user in then counter page
	When the increase button is clicked 2 times
	Then the counter value is 2

Scenario: Click increases the counter 3
	Given a user in then counter page
	When the increase button is clicked 3 times
	Then the counter value is 3