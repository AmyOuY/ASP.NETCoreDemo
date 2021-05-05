# ASP.NET Core3.1 Blazor and MVC apps with Redis cache
<h3> Use <em>Student Model</em> to demonstrate how to Create, Read, Update, Delete (CRUD) in ASP.NET Core Blazor and MVC. </h3> 
<h3> The apps use Dapper as an object–relational mapping (ORM) to access SQL database and Redis running inside Docker Container for caching. </h3>

<hr/>
<h4>PowerShell commands for using Redis in Docker<h4/>
<img src="/Images/powershell.png" >
  

<hr/>
<h4>Blazor page shows CRUD functions<h4/>
<img src="/Images/blazor.png" >
  
  
<hr/>
<h4>Data retrieved from SQL database and cached in Redis if it is not already stored in Redis cache<h4/>
<img src="/Images/blazor_sql.png" >
  

<hr/>
<h4>Data primarily retrieved from Redis cache if it is there<h4/>
<img src="/Images/blazor_redis.png" >
  
  
<hr/>
<h4>MVC view shows CRUD functions<h4/>
<img src="/Images/mvc.png" >
  
  
<hr/>
<h4>Data retrieved from SQL database and cached in Redis if it is not already stored in Redis cache<h4/>
<img src="/Images/mvc_sql.png" >
  

<hr/>
<h4>Data primarily retrieved from Redis cache if it is there<h4/>
<img src="/Images/mvc_redis.png" >
