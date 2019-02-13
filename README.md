# OpenWrksCodeTest

Use the token controller to get a bearer token.

http://localhost:5000/api/v1/token

Every endpoint aspart from the token endpoint requires a authorization header.

Notes: 
	- Running on HTTP rather than HTTPS for ease of development. A production API would run with HTTPS.
	- Using an InMemory database with basic data wrapped up in the contstruction of it for ease of developlment. In a non-code-test example this would be an actual datasource with no data construction or assumption.
	- The Auth service only handles basic authentication, it does nothing with roles to handle authorization. In a production setup i would extend the code futher to do this.
	- We use URL versioning because my experience is its easier to work with going forward. Refactoring and making changes is easier to do while avoiding breaking changes. 


	TODO:
	Logging


Explicition Decisions
	- UsersController handles both "userids" and accounts. One is not valid without the other so dispite preconseptions they are a single entity which we will called "UserAccount"