Feature: GetBooksAPI

@mytag
Scenario: Get List of Books
	Given I have a client
	When I make a 'GET' request
	Then I have '200' status code
	And The response body is as expected

Scenario: Create a new User
	Given I have a client
	When I make a 'POST' request
	Then I have '201' status code
	And The response body is as expected

Scenario Outline: Modify a User
	Given I have a client
	When I make a '<Type>' request
	Then I have '<StatusCode>' status code
	And The response body is as expected
Examples: 
| Type | StatusCode |
| PUT  | 200        |