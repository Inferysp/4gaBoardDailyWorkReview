

## 4gaDWR - 4ga board daily work review

### Case study

An example of a daily task list, including a description of actual programming task and a summary of the working day.

<img width="718" height="711" alt="firefox_4GroLHDzWz" src="https://github.com/user-attachments/assets/e2764f8b-44f2-4b6b-8b0c-3b6d2fcd27e8" />

### Tech Stack

- Client - **React.js, Vite.js, TailwindCss,  useState, useEffect, date-fns**
- Server - **.NET 8.0, EF Core, ASP NET Core, MediatR, Dapper** 
- Architecture - **DI, CQRS**
- Database - **PostgreSQL**

### Description

A full-stack SPA application `React and ASP.NET Core` template for useful work progress and tasks review.

- Kanban tasks progress documentation lists for choosed Day.
- postgreSQL db mapped by `Entity Framework Core` tools.

## Deploy

**_Docker Compose (recommended)_ 4ga Boards Deploy**

    https://github.com/RARgames/4gaBoards

**Pull images and start 4ga DWR**

    docker compose up -d

Default 4ga DWR url: http://localhost:5000/

## Development

**Install Development 4ga Boards project from RARgames repository:**

	https://github.com/RARgames/4gaBoards
	
**Clone 4gaBoardDailyWorkReview repository into a directory of your choice**

	git clone https://github.com/Inferysp/4gaBoardDailyWorkReview.git

**_Install dependencies if needed_**

**Set `ConnectionString:` for PostgreSQL database of 4ga Boards dev setup**

	Host=127.0.0.1;Database=4gaBoards;Username=postgres

**Start the development server**

	4gaDailyWorkReview.Server> dotnet run --launch-profile https

**Start the development client**

	4gaDailyWorkReview.Client> npm run dev
