
## 4gaDWR - 4ga board daily work review

### Tech Stack

>Client - **React.js, Vite.js, TailwindCss,  useState, useEffect, date-fns**
>Server - **.NET 8.0, EF Core, ASP NET Core, MediatR, Dapper** 
>Architecture - **DI, CQRS**
>Database - **PostgreSQL**

### Description

A full-stack SPA application `React and ASP.NET Core` template for useful work progress and tasks review.

- Kanban tasks progress documentation lists for choosed Day.
- postgreSQL db mapped by `Entity Framework Core` tools.

### Development

**Install Development 4ga Boards project from RARgames repository:**

	`https://github.com/RARgames/4gaBoards`
	
**Clone 4gaBoardDailyWorkReview repository into a directory of your choice**

	`git clone https://github.com/Inferysp/4gaBoardDailyWorkReview.git`

**_Install dependencies if needed_**

**Set `ConnectionString:` for PostgreSQL database of 4ga Boards dev setup**

	`Host=127.0.0.1;Database=4gaBoards;Username=postgres`

**Start the development server**

	`4gaDailyWorkReview.Server> dotnet run --launch-profile https`

**Start the development client**

	`4gaDailyWorkReview.Client> npm run dev`
