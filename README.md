# Coding Challenge

To run the application, require .NET Core 3.1 and Angular CLI 8.2.14. Build the application in Visual Studio 2019 and it will automatically restore the nuget packages and angular npm packages and run with F5.

I have added following features here.

- Swagger for Testing and UI.
- Added validation in front end and backend for required fields.
- Middleware for Exception Handling and Logging
- NSubstitute for Mocking (similar to Moq)
- Strategy Patterns to implement Searching logic.

API can be tested separately though swagger. It also provide documentation of API.

The link of swagger [https://localhost:44369/swagger/index.html](https://localhost:44369/swagger/index.html)

- UI display list of occupation in dropdown calling the endpoint

GET ​/api​/DeathSumPremium​/Occupations

- To Calculate the monthly premium with valid input call the method
  - POST ​/api​/DeathSumPremium​/MonthlyDeathPremium

Request schema{

&quot;name&quot;: &quot;Nick&quot;,

&quot;age&quot;: 20,

&quot;dateOfBirth&quot;: &quot;2001-01-24&quot;,

&quot;deathSumInsured&quot;: 10000,

&quot;occupation&quot;: &quot;Doctor&quot;

}

Response:

DealthPreimumModel{

&quot;monthlyDeathPremium&quot;: 16.67

}
