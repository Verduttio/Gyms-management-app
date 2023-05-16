# Gyms-management-app
This is a full stack application that consists of two projects: Web API and Blazor. 
The project is built using ASP.NET Core 6, Web API, and Blazor. 
Additionally, a library has been added to hold DTOs that are used by both Web API and Blazor.

## Prerequisites to run on your own machine
To run this project, you will need the following software:
  * Visual Studio 2022
  * ASP.NET Core 6
  * Web browser (Google Chrome, Mozilla Firefox, Safari, etc.)
  * SQL Server

## Usage
  1. Import the project in Visual Studio 2022.
  2. Ensure that the Web API and Blazor projects are set as the startup projects.
  3. Using the NuGet package manager, install all required dependencies.
  4. Configure connection to your DB using SQL Authentication. Change user (UID) and password (PWD) in file `appsettings.json`.
  5. In the Package Manager Console type `Update-Migration`. To open PMC, click on Tools -> NuGet Package Manager Console -> Package Manager Console.
  6. Run the project by clicking the "Start" button.
  7. [Optional] You will probably have to configure <Multiple Startup Projects> option next to the "Start" button to run web api and blazor together.
  
## Screenshots
![Club](https://github.com/Verduttio/Gyms-management-app/assets/72033031/8ec755d8-6bc1-46a7-ba8d-edd3728ebb16)
![Event](https://github.com/Verduttio/Gyms-management-app/assets/72033031/06145adc-3feb-47ed-b08e-7b0932dcfb03)
