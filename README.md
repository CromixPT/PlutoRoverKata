# PlutoRoverKata

PlutoRoverKata is a simple API and Service Layer aimed to demonstrate the simple capabilities of our friendly lonely rover in Pluto. 

It was built in the simplest way possible, where one of the main challenges was to avoid adding unecessary complexity.

The API allows a user to send a string that represents a group of actions for the rover to perform.

Valid inputs are: L, R, F, B where:
- L instructs the rover to rotate Left
- R instructs the rover to rotate Right
- F instructs the rover to move Forward
- B instructs the rover to rotate Backwards

A valid instruction group would be `FFRBFFLFF` 

Since Pluto might not be so friendly as it seems, our navigator system ensures that the rover will not move into any hazzard grid slot or move out of the planettary grid system. Also inputs that are not valid are ignored.

## Test Instructions
 - PlutoRoverKata has a suite of unit tests, to run them localy, from the root folder run: `dotnet test`
 
 ## Mutation Test Report
 Mutation Testing is also available, to review the mutation score from the root folder

1. `dotnet tool restore`
2. `dotnet stryker -o`

The mutation testing should take a few minutes, once it is finished it will open the html report.
## Run instructions
You can run this project using any .NET IDE or from the commandline.
- From the root folder and run ` dotnet run --project .\src\PlutoRoverKata.WebApi\`

  Once the service has started the API is exposed on port 5087 or you can use swagger found at: http://localhost:5087/swagger/index.html