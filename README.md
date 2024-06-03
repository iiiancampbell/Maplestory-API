# test-API
This repo will be for a C# API with MySQL Database. 

# Database
Working with this repo will require MySQL Workbench to work with the DB on localhost
## To-Do
1. Push DB to AWS
2. Create cred store in AWS 

# Creating DB Connection in MySQL Workbench
1. Open Workbench
2. Go to Database -> Manage Connections > New
3. Setup new local DB connection using "localhost", port 3306, password = _yourpassword_
# Running C# app 
1. Ensure _yourpassword_ for database connection is set in "appsettings.json" -> "DefaultConnection"
2. Open Terminal / CMD
3. Navigate to project folder
4. Use command

~~~
dotnet run
~~~
