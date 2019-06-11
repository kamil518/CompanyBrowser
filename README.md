# CompanyBrowser

Company Browser is a web application prepared for sake of Recruitment Process in order to present my programming skills. It is simple browser which queries the database of companies by one of 3 keys: Nip, Krs or Regon code. As a result, user gets company's details. Application has been produced due to the requirements provided by recruiting company using programming best practices.

## Technology stack
The following technologies has been used to produce this application:
* ASP.NET CORE 2.2
* ANGULAR 6
* ENTITY FRAMEWORK CORE
* SQLite

For unit testing purposes nUnit and Moq libraries have been used.

## Building solution
In order to build the solution first you need to install npm packages with "npm install" command (you need to have npm and node installed) and nuget packages with "dotnet restore" command. Next you need to either build ("dotnet build"), execute "dotnet ef update database" to create database file and run migrations on it and "dotnet publish" to produce binaries ready for running the application (.net core 2.2 sdk has to be installed). 

## Running unit testing
To run unit tests you need to use "dotnet test" command in solution directory.

## Running the application
In order to run the application, you need to run command "dotnet" on project's dll (NIPApplication.dll) produced in "publish" directory. 

## Using the application
Client site of the application has one input where user can provide one of three keys (Nip, Regon or KRS) by which the companies table will be queried. After pressing the button details of queried company would be displayed.

There is a theoretical possibility that company A can have the same NIP number as Regon of company B. By the design in such situation NIP filter has priority and company A would be displayed. 

Querying by empty string or white space results in 400 Bad Request server response.

If there is no record with provided key, appropriate message will appear.

