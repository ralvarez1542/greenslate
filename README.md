# greenslate

Coding Challenge is a project to know the projects that belong to users, in the same way, calculating the start date, end date, verifying if the project has already been started, how many days left to start it, also knowing whether the project is active or not.

# Steps

  - Clone or Download the project.
  - Change the ConnectionStrings for connection to the database.
  - Run both script for creating the database and tables, finally load the information, these files are located in Database file.
    1- Database Creation Script.
    2- Data Loading Script.
  - If you want to connect to the previously created database through Entity Framework (DB First) using the console, you could use this       script, selecting the project CodingChallenge.Domain in the part of Default project located at the top of the console. 
    
    # Script
    Scaffold-DbContext "Server=(LocalDb)\MSSQLLocalDB;Database=CodingChallenge;Trusted_Connection=True;"         
    Microsoft.EntityFrameworkCore.SqlServer -OutputDir DomainModels 
    # Note
    Change the Server for the name of your server.
