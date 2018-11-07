Feature: Validate MyRental SendRequest page
Scenario: Verfiy if the user who logged in as a Tenant, is able to send a request 
  Given user is in the send a request page with tenant credentials
   When user enters the required request details in the rental request page and clicks submit button
   Then the rental properties page should be displayed after saving the send request details 