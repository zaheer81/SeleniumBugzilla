Feature: Login 
		In order to access my account
		As a user of the website
		I want to log into the website

@Positive @Primary
Scenario: Successful login with correct credentials
    Given a web browser is at Bugzilla main page
	When user enters correct user name and password and clicks login button
    Then user is successfully logged in


@Negative
Scenario Outline: Login failed with incorrect credentials
	Given a web browser is at Bugzilla main page
	When user enters incorrect <UserName> and <Password> and clicks login button	
    Then user is not logged in
Examples: 
	| UserName			| Password |
	| abc				| 123      |
	| zaheer			| 444      |	
	| test@1			| 123456   |	