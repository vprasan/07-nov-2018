Feature: ListARentals
	Validate the listing of a property as rental
	


Scenario: Validate to see if the owner can list his property for rental 
	Given user is in the application 
	When user clicks on list rentals button and types all the required fields and click Save button
	Then users property is listed as rental.		
