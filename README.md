# API_CVPortalen
 
CVPortalen API documentation  


Updated: 10 sep 2020

setup
(assuming you got SqlServer installed with an empty database. 
https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

1. install .Net core https://dotnet.microsoft.com/download
2. install entityframework using console: dotnet tool install --global dotnet-ef
(On linux you may have to add to your paths by: ‘export PATH="$PATH:$HOME/.dotnet/tools/"’)
3. cd to project folder and run: dotnet restore
4. inside the project open the file ‘appsettings.json’ and change the defaultconnection string to your database.
5. run  dotnet ef migrations add inital --project API_CVPortalen
6. run dotnet ef database update --project API_CVPortalen




UserController

[get] site.com/api/user 

 (Admin only) returns all users without tokens and passwords. If you’re not admin you get error 401

[get] site.com/api/user/id 
  request needs to be authenticated (user or admin)
  returns user in following format:
  {"id": 10,
  "firstName": "name10",
  "lastName": "Lname10",
  "email": "user10@iths.se",
  "role": "User",
  "programmeId": 2}


[post] site.com/api/authenticate
  Expects a body with Email and password; 

{"Email":"admin@iths.se", "Password":"password123"}

  returns 200 + user with token;
    { "id": 99999,
    "firstName": "admin",
    "lastName": "Lname",
    "email": "admin@iths.se",
    "role": "Admin",
    "programmeId": 1,
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ijk5OTk5Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNTk5NzU5NTUzLCJleHAiOjE2MDAzNjQzNTMsImlhdCI6MTU5OTc1OTU1M30.k-DZY_Vt1Fb-I_DhRZ076gZxj3zz8s-QvgLZ2PYs0gE" }

  or error 401 if wrong credentials is provided. 
   {"error": "Username or password is incorrect"}


[post] site.com/api/user/register
  Expects  {"Email":"user@iths.se", "Password":"test", "FirstName":"asd", "Lastname":"asdasd"}

  returns code 200 w/ new user id, only the id. 
  Returns 400 on empty request
  returns 400 + error on bad credentials.  

[put] site.com/api/user/id
  updates the user with the provided id. Only the user or an admin should be able to call this.
  Returns 200 + 1 on success. 
  Returns 401 on user error (not correct user or admin) 
  returns 400 on varius errors with an error message. 

[delete]site.com/api/user/id
  Returns 200 + 1 on success. 
  Returns 401 on user error (not correct user or admin) 
  returns 400 on varius errors with an error message. 


ProgrammeController

  typical programme package: 
  {
  "id": 1,
  "name": "Webbutveckling",
  "start": "2000-01-02T00:00:00",
  "end": "2002-01-02T00:00:00"
  }

[post] site.com/api/programme
  requires admin. Creates new programme.

[get] site.com/api/programme
  returns all programmes 

[get] site.com/api/programme/id 
  returns programme with id or notfound 404

[put] site.com/api/programme/id 
  requires admin. Updates programme.
  expects a programme with id, name, start(date) , end(date)

[delete] site.com/api/programme/id 
  requires admin. Deletes programme. 

[get] site.com/api/programme/id/students
  requires authentication / token. 
  returns all studends in programme.

