# OpenWrksCodeTest

Use the token controller to get a bearer token.

http://localhost:5000/api/v1/token

Every endpoint aspart from the token endpoint requires a authorization header.

I have added some base data to work with if you want to use it;

user: 1a44cb46-5556-4788-908a-1863b1898ed0
who has the bank accounts;
FairWayBank - 12345678
BizfiBank - 12345679

### Notes: 
	- Running on HTTP rather than HTTPS for ease of development. A production API would run with HTTPS.
	- Using an InMemory database with basic data wrapped up in the construction of it for ease of developlment. In a non-code-test example this would be an actual datasource with no data construction or assumption.
	- The Auth service only handles basic authentication, it does nothing with roles to handle authorization. In a production setup i would extend the code futher to do this. I would also use a authororization service / server and use a proper flow.
	- I'm using URL versioning because in my experience is its easier to work with going forward. Refactoring and making changes is easier to do while avoiding breaking changes. 
	- I've not added ANY logging or request tracing. I've not added it for time reasons, i would do this in a production solution.
	- I have used automapper to interchange between internal models and external view models.
	- I have not added any paging - I could have done this but its extra work i don't feel is required for this example.
	- The unit tests are not comprehensive - They are mearely examples of how i would test each thing.
	- HATEOAS - I've not added any links to the next actions which could be done.
	- Data Storage - I've used entity framework for demo purposes only.

### Talking points: 
	- ThirdPartyApiException - I'm not sure this is the best way to handle this
	- TransactionEnrichmentPipeline - I'm not sure what is meant by this, but i would think the TransactionsService could incorperate this.
	- OWBank - We would simply add another bank to the factory and another integration class and everything should "just work".
	- Unified formats - Perhaps there is a way to generically exclude null properties from the Json response?
	- Handling exceptions at the controller level. I've done this many ways before. Here i have left it to bubble up. BadRequests or NotFound?
	
## API Routes
	### Users
	- GET  http://localhost:5000/api/v1/users/ -- All users
	- GET  http://localhost:5000/api/v1/users/907110ad-00b4-499b-9365-1631d266d322 -- Specific users
	- POST http://localhost:5000/api/v1/users/ -- Create user. ViewModel comes from the body

	### Accounts
	- GET  http://localhost:5000/api/v1/users/907110ad-00b4-499b-9365-1631d266d322/accounts -- all accounts for user
	- GET  http://localhost:5000/api/v1/users/907110ad-00b4-499b-9365-1631d266d322/accounts/12345678 -- specific account for user

	### Transactions
	- GET  http://localhost:5000/api/v1/users/907110ad-00b4-499b-9365-1631d266d322/accounts/12345678/transactions -- transactions for user account