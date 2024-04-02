## Theme

   The ultimate goal in this task was to create a page which would display a list of products and perform a front-end search by specified parameters
   
   
## Introduction

   The task is split into two projects (Client and Server) and each performs its own responsibility. Client tries to fetch products from Server side and if the Server side is offline or not configured it is also
   possible to proceed without it because in that case Client will fetch product data from a static JSON file that's placed in the project.
   

## Front-End

   Client part is built in C# front-end framework Blazor Web Assembly. We have 2 available pages: Home and Products. Both of the pages are pointing to the same products and are performing
   pretty much the same actions.

     Home page is built using "QuickGrid" plugin that helps us to render datatable which will also allow us to perform sort and pagination (20 products per page set as default)
     
     Products page is built ordinarily without plugins and will display all products by 4 products per row with the most important information for each product.

   Blazor PWA is also enabled which means we can download the app from a browser by clicking install icon on the right side of URL next to the Bookmarks icon.
   
   
## Back-End

  Server side is built in C# Asp.NET Core and this part was added from me as an additional implementation and the goal for server side is to run migration that will create a products
  table in database PostgreSQL and will try to seed that table with data that we are fetching from our static JSON file. This happens immediately after the project is run and products
  are then exposed via API on route: "http://localhost:8000/products" which is the route that's being called from our Client side.
  

## Setup

  To get the project we should clone it from github:

        git clone https://github.com/krizanact/BlazorApp.git
        
  Both projects and database as well are hosted via docker containers and the easiest way to run everything is by using CMD/PowerShell and executing this:

        docker-compose up

  OR executing button "docker-compose" manually on Visual Studio 2022. Docker is required to be installed on machine if we want to run Back-End and Database.
  If "docker-compose" successfully ran containers projects will be exposed to: 
    
       "http://localhost:8080/" => Front-End
       "http://localhost:8000/swagger/index.html" => Back-End with Swagger UI

  Another possibillity is to run only Front-End project without anything else, then it should be ran from Visual Studio with Client as a startup project
  and IIS Express. In this case Back-End request to fetch products will fail but exception won't be thrown and will continue to work using data fetched
  from static JSON file but will load products much slower due to the time that's needed for Back-End request to fail.
  


## Note

  .env file is included in the project so PosgresSQL container could easily be up even that I know any secret/secret files should never be included in the
  project but since this is only local development and local environment I didn't care about that.
