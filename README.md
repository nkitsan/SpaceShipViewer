# SpaceShipViewer

## APIs this project uses
- SpaceX API and Oddity Client

## Functionality of SpaceShipViewer
- Worker saves launches data from API to DB
- Controllers allow to retreive list of launches ordered by launch date and filtered by name and launch date

## Futher improvement
- Create generic repositories with generic filtering capabilitites
- Clean up dependency injections to forbbid adding services which already exsist and improve set up of configuration sections
- Move Core part of the application to a separate project called Contracts (domain entities, interfaces for repositories, queries)
- Tests for business logic in Application and tests for repositories implementations
- Create documentation for SpaceShipViewer.SpaceX.RestApi
- Exception Middleware to return BadRequest and so on
- Migrate from Oddity to Kiota
- Consider alternatives for Automapper