Feature: DeleteProperty
		Validate to see if the owner can delete his proprety
	
Scenario: validate to see if the owner can delete his property
	Given user is in logged into the application
	When user clicks on the delete property button in the property page
	Then the selected property will be deleted from the owners property	