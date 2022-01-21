# Task Tracker

#### The completed test task for Akvelon

Manage your projects and tasks easily with this app.

## Installation

There are no real instructions for installation, you just clone the repo or download it and launch it on your localhost. The only thing is you will need to configure the database. I used PostgreSQL database, so the code doesn't support any other database services. To link the Task Tracker to your PostgreSQL database go to "appsettings.json" file, find "DefaultConnection" and set it for your server and database. <br><br>
It has a Swagger page with all the documentation needed, so I recommend using it.

## Packages used and their versions 

* AutoMapper.Extensions.Microsoft.DependencyInjection: **11.0.0**
* Microsoft.AspNetCore.JsonPatch: **5.0.13**
* Microsoft.AspNetCore.Mvc.NewtonsoftJson: **5.0.13**
* Microsoft.EntityFrameworkCore: **5.0.13**
* Microsoft.EntityFrameworkCore.Design: **5.0.13**
* Microsoft.EntityFrameworkCore.Tools: **5.0.13**
* Npgsql.EntityFrameworkCore.PostgreSQL: **5.0.10**
* Swashbuckle.AspNetCore: **5.6.3**

## Remarks

Code is done with 3 layers: Repository -> Service -> Controller. Repository works with Database Context, meaning it is the database access layer, which has no other responsibility. Service is the layer where the "logic" of controller methods are implemented with its documentation. Here, I included the validation methods additionally, which throw custom Exceptions, thus if there is need for back-end API methods, you should call service methods wrapped into try-catches, because there are many exceptions that can be thrown if you are not accurate. Finally, the Controller layer has the methods for Web API with the documentation for Swagger.
