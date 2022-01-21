# Task Tracker

#### The completed test task for Akvelon

## Installation

There are no real instructions for installation, you just clone the repo or download it and launch it on your localhost. The only thing is you will need to configure the database.
I used PostgreSQL database, so the code doesn't support any other database services. To link the Task Tracker to your PostgreSQL database go to "appsettings.json" file, find "DefaultConnection" and set it for your server and database. <br><br>
It has 

## Packages used and their versions 

* AutoMapper.Extensions.Microsoft.DependencyInjection: **11.0.0**
* Microsoft.AspNetCore.JsonPatch: **5.0.13**
* Microsoft.AspNetCore.Mvc.NewtonsoftJson: **5.0.13**
* Microsoft.EntityFrameworkCore: **5.0.13**
* Microsoft.EntityFrameworkCore.Design: **5.0.13**
* Microsoft.EntityFrameworkCore.Tools: **5.0.13**
* Npgsql.EntityFrameworkCore.PostgreSQL: **5.0.10**
* Swashbuckle.AspNetCore: **5.6.3**
