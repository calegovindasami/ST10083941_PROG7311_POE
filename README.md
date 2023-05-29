# ST10083941_PROG7311_POE

The Farm Central Blazor website is an application that allows farmers to manage their stock inventory.
It is built using Blazor WASM with MudBlazor for styling as the frontend and WebAPIs for the backend. Authorization is implemented
using JWT and .NET identity, each have their own class library and API. The repository pattern is used for the backend of 
the stock management side. I attempted to apply SOLID principles for authentication as well. The databases
have been published on Azure. The sql schema is in the repository, the APIs are local.

To begin, please install Visual Studio Community Edition 2022 from the following link: https://visualstudio.microsoft.com/downloads/
Once done, please run the installer and select
- ASP.NET and web development
- Under the individual components, ensure .NET 6 is checked
![Install Options](https://github.com/cgov-0406/ST10083941_PROG7311_POE/assets/96740648/19bf34f7-d454-45b6-a360-29cb2775280a)

When complete, run Visual Studio 2022. Then copy this current repos link and go go to clone repository.
Paste the link and click clone.
<img width="508" alt="clone repo" src="https://github.com/cgov-0406/ST10083941_PROG7311_POE/assets/96740648/69d775af-049e-4962-aaaa-c5c24740483d">

When the repo has been cloned, please double click the Farm Central .sln file. Right click the solution once open and click set startup
project. Ensure the API.Identity, API.Application and Ui.Blazor is set to start. Once, done, you can exit the menu.
Right click the solution once again and click build. Once the solutution has been built, click start.
When the project runs, you may be asked to accept a certificate, agree to this and continue.

To begin using the application, please register and enter your details. Once done you can login and add a farmer.
You can then give the login details to a farmer and they can login. 

As an employee you will be able to add farmers, view farmers and then view their products. You can filter them by date and search.

As a farmer, you can add products to your own account.

References:
MudBlazor: https://mudblazor.com/ 
Authentication: https://www.udemy.com/course/aspnet-core-solid-and-clean-architecture-net-5-and-up/

