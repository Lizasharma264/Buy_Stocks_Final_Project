1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools and select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
Update-Database -Context Buy_Stocks_DBIdContext



5. On the console execute the following command

 Update-Database -Context Buy_Stocks_DBContext



6. After migration is successful Run the project 

7 if you login as admin  from the following credentials will be able to see the Companies,  
Stock buyers   and Stock payments Links. Onnly admin can Add delete and update Companies, payments and buyers

User : admin@stocks.com
Password: 1qaz2wsX@

8. Also you can login with the following credentials to visit the site as a Stock buyer
 Can View and buy Company stocks. Optionally you can sign up as a buyer from "Sign up as a buyer" Link

 User : james@stocks.com
Password: 1qaz2wsX@



9 if you need to create another  admin login with the admin credentials on step 7 above and
Click in "REGISTER Stock admin" register a new admin 





The identity  authentication code used in the project were obtained by following URLS

Introduction to Identity on ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.0&tabs=visual-studio
