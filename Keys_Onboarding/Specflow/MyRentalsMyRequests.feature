Feature: Validate MyRental My Requests page
Scenario: Verfiy if the user who logged in as a Tenant, is able to view My Requests page 
	Given user is in the rental properties page  
	When  user clicks on the menu option My Requests 
	Then the My Requests page should be displayed 
