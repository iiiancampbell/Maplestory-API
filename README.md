# Maplestory-API
This is an C# API to show various information about playable characters from the MMORPG "Maplestory". End goal for this project is to have this website that users can view to get the latest information about the game (Jobs, JobMaxLevel, EndGameBosses etc). Might extend functionality to allow users to generate their own characters (Name, job etc) with a pixel sprite.

# Database
Working with this repo will require MySQL Workbench to work with the DB on localhost


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

# To-Do
1. Fix "PUT" call for Users table -> currently getting a 400 bad request
2. Push DB to AWS
3. Create cred store in AWS
4. Add new tables to test
5. Reevalute whether JWT authentication is most suitable VS oAufh

# JWT vs oAuth
- **Use JWT** when you need simple, stateless authentication for your applications. JWT is excellent for single-page applications (SPA), mobile applications, and microservices where you need to validate tokens quickly and efficiently without maintaining server-side state.
- **Use OAuth** when you need to delegate access to third-party applications, require fine-grained access control, or need to provide secure API access. OAuth is ideal for more complex scenarios where robust security and permission management are required