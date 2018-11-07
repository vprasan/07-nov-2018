Feature: Validate My Rentals page

@mytag
Scenario: Verfiy if the user who logged in as Tenant, is able to see his rentals 
	Given user is in application   
	When  user clicks on the Main Menu Tenant and further on MyRentals sub Menu option 
	Then the user should see MyRentals page with his rental property details