# Philly,NET - August 16, 2023

## [Meetup site](https://www.meetup.com/philly-net/events/295026043/) for this event

***

## Full Stack Hands-On Lab with .NET Core 7 Minimal APIs and Angular

### Presented by: Bill Wolff

#### Overview
Join our next hands-on lab as Bill Wolff takes us through a full stack journey. We'll start with building back-end services using Minimal APIs in .NET Core 7. Then, we make our way to the front-end by harnessing Angular to craft dynamic UIs. *Bring a laptop* if you intend to code alongside Bill.


### Notes



# Philly,NET - August 16, 2023

## Full Stack Hands-On Lab with .NET Core 7 Minimal APIs and Angular

## Short Link to This Content: https://bit.ly/pdn230816

## or Scan Here
<img src="images\pdn230816.png" alt="QR Code for direct link to this page" width="256"/>

## Lab

### Requirements

- you need some flavor of sql server to host the database
  - download [sql developer or express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- you need a code editor
  - install [vs code](https://code.visualstudio.com/)
- you need .net 7
  - download [.net core 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- download the sample database
  - [2023/0816-dotnet/files/AgilitySports.bak](https://github.com/phillydotnet/Presentations/blob/main/2023/0816-dotnet/files/AgilitySports.bak)
- we will show some vs code extensions, you might install them ahead of time, or you can just watch the demo
  - SQL Server (mssql) 1.20.1
  - C# 2.0.357
  - RestClient 0.25.1
  - Angular Language Service 16.1.8

### Course flow

- all the steps are documented below (this will be modified up to class time on wednesday)
- there is no need to download the instructions, the web page will be here for a long time
- i will perform each step and explain why
- if you fall behind, finish what you can
- you can start prior to the class

# Agility Full Stack: SQL < C# .NET Core 7 < Angular 16

Build 2 projects in VS Code that display data from a SQL Server database. A .NET Core minimal api layer project supplies the data to the Angular spa project via json structures. Learn some useful tools and techniques.

## Tools You Will Need

It really helps to download all of this before attending the class. Bandwidth may be minited and there will be dozens of developers doing the same thing at the same time.

The versions below are for reference. Any version close to this should work.

- SQL Server 2019
    - SQL Management Studio 18.9.1
- VS Code 1.81.1 with extensions
    - SQL Server (mssql) 1.20.1
    - C# 2.0.357
    - RestClient 0.25.1
    - Angular Language Service 16.1.8
    - Microsoft Edge Tools for VS Code 2.1.3
    - Markdown All in One 3.5.1
  - Angular 16.2

# database

1. download the sample database backup and restore to your local server
   > store anywhere on your local drive
2. review tables in SSMS
3. execute a query in SSMS
```
use AgilitySports

select
*
from NFL.roster
```

# .NET Core api project

1. open a new vs code window
2. create an api project in the terminal, then reload vs code
```
ctrl `

cd \code

dotnet new webapi -minimal -n agility-sports-api

cd agility-sports-api

code -r .
```
3. edit Properties/launchSettings.json
> change the port to 1106
4. run the sample application
```
ctrl `

dotnet run
```
5. test in your browser
```
http://localhost:1106/swagger/index.html
```
6. add folders
   1. Docs - markdown files
   2. Data - repository and interface
   3. Dtos - for query records
   4. Models - for table records
   5. SQL - for SQL statements
   6. Test - test files for the rest client extension
7. configure mssql connection settings
   1. F1, MS SQL: Manage Connection Profiles, search for SQL
   2. edit settings.json with you rconnection info
8. create SQL\nfl.sql
   1. paste in query above and execute
9. (optional) copy instructions to docs folder
10. add route groups to categorize apis above the app.Run() statement
```
var all = app.MapGroup("api");

var NFL = all.MapGroup("nfl");
var PGA = all.MapGroup("pga");
```
11. add a simple api in program.cs using lambda syntax, put this in a region
> remove the sample weather forecast code, then add the lines below
```
#region Version

all.MapGet("version", () => "0.1.0");

#endregion
```
12. test in your browser and swagger
```
http://localhost:1106/api/version

http://localhost:1106/swagger/index.html
```
13. test in rest client by creating Test\version.http, use send request to see results
```
### current version
get http://localhost:1106/api/version
```
14. add the dapper orm in the terminal (entity framework is another way to do this)
```
Dotnet add package Dapper
Dotnet add package Dapper.Contrib
Dotnet add package Microsoft.Data.SqlClient
```
15. add a connection string in appsettings.development, supply your own server name
```
,
    "ConnectionStrings": 
    {
	    "DefaultConnection" : "Server=Agility;Initial Catalog=AgilitySports;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
    }
```
16. add Models\NFLRoster.cs for the nfl roster table, use Dapper annotations for the table name
```
using Dapper.Contrib.Extensions;

namespace AgilitySportsAPI.Models;

[Table("NFL.roster")]
public record NFLRoster
{
    [Key]
    public int? PlayerId { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Team { get; set; }
    public string? Position { get; set; }
    public string? FantasyPosition { get; set; }
    public string? PositionCategory { get; set; }
    public string? Height { get; set; }
    public int? Weight { get; set; }
    public int? Number { get; set; }
    public string? CurrentStatus { get; set; }
    public string? CurrentStatusColor { get; set; }
    public DateTime? BirthDateShortString { get; set; }
    public string? Age { get; set; }
    public double? AgeExact { get; set; }
    public string? College { get; set; }
    public string? CollegeDraftRound { get; set; }
    public string? CollegeDraftPick { get; set; }
    public string? ExperienceDigit { get; set; }
    public string? PlayerUrlString { get; set; }
    public string? TeamName { get; set; }
    public string? TeamUrlString { get; set; }
    public string? PhotoUrl { get; set; }
    public string? PreferredHostedHeadshotUrl { get; set; }
    public string? LowResPreferredHostedHeadshotUrl { get; set; }
    public bool? IsAvailableToPlay { get; set; }
    public string? Status { get; set; }
    public string? InjuryStatus { get; set; }
    public string? InjuryBodyPart { get; set; }
    public string? ShortName { get; set; }
    public string? TeamDetails { get; set; }
    public string? CSName { get; set; }
}
```
17. add Data\INFLRepo.cs to define the method signature, required for injection into program.cs
```
using AgilitySportsAPI.Models;

namespace AgilitySportsAPI.Data;
public interface INFLRepo
{
    #region NFL

    Task<IEnumerable<NFLRoster>> GetAllNFLRoster();

    #endregion
}
```
18. add Data\NFLRepo.cs for the method, it needs dapper to access sql and the configuration string
```
using AgilitySportsAPI.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace AgilitySportsAPI.Data;
public class NFLRepo : INFLRepo
{
    private readonly IConfiguration configuration;

    public NFLRepo(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    #region NFL

    public async Task<IEnumerable<NFLRoster>> GetAllNFLRoster()
    {
        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        {
            return await connection.GetAllAsync<NFLRoster>();
        }

    }

    #endregion
}
```
19. edit program.cs to add an entry for this new method
> first add a using statement at the top
```
using AgilitySportsAPI.Data;
```
> then add the repository injection above builder.Build();
```
builder.Services.AddScoped<INFLRepo, NFLRepo>();
```
> finally add the endpoint below the version region
```
#region NFL

NFL.MapGet("roster/all", async (INFLRepo repo) => {
    return Results.Ok(await repo.GetAllNFLRoster());
});

#endregion
```
20. save all files, compile, and reload with dotnet run in the terminal
21. create Test\NFL.http and add a get call, but preface it with a variable
```
@url = http://localhost:1106/api/

### get all roster
get {{url}}nfl/roster/all
```
22. add Dtos\NLFRosterDto.cs for a more concise json payload
```
namespace AgilitySportsAPI.Dtos;

public class NFLRosterDto
{
    public string team { get; set; } = null!;
    public string name { get; set; } = null!;
    public string position { get; set; } = null!;
    public string number { get; set; } = null!;
    public string height { get; set; } = null!;
    public string weight { get; set; } = null!;
    public double ageExact { get; set; }
    public string college { get; set; } = null!;
}
```
23. add a second signature to Data\INFLRepo.cs
> add a using at the top
```
using AgilitySportsAPI.Dtos;
```
> add a signature below the existing one
```
Task<IEnumerable<NFLRosterDto>> GetNFLRoster();
```
24. add a matching method to Data\NFLRepo.cs
> add 2 usings at the top
```
using AgilitySportsAPI.Dtos;
using Dapper;
```
> add a method below the existing one
```
    public async Task<IEnumerable<NFLRosterDto>> GetNFLRoster()
    {
                var sql = @"
select 
  Team
, Name
, Position
, Number
, Height
, Weight
, AgeExact
, College
from NFL.Roster
order by 
  1, 3, 2";
        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        {
            return await connection.QueryAsync<NFLRosterDto>(sql);
        }
    }
```
25. finally, add the second endpoint to program.cs
```
NFL.MapGet("roster", async (INFLRepo repo) => {
    return Results.Ok(await repo.GetNFLRoster());
});
```
26. save all files, reload the terminal with dotnet run
27. add a second test to Test/NFL.http, we now have a smaller json payload
```
### list players
get http://localhost:1106/api/nfl/roster
``` 

# Angular project

1. open a new vs code window
2. open the terminal with ctrl ` or with the manu
3. change the directory to the parent folder used for your sample code
```
cd \code
```
4. make a new angular project using their command line interface (CLI)
> the -p is the prefix for all genrated items, --inline-style means put css in an array and not a sepaarate file, the --routing means add routing support to all modules since we will have many pages, select CSS for the stylesheet methid
```
ng new AgilitySports -p sports --inline-style --routing
```
5. change to the new directory
```
cd AgilitySports
```
6. look at the files, src has your new source code and node_modules has all the angular libraries
```
dir
```
7. restart vs code using the current folder and review the files created
```
code -r .
```
8. under .vscode, look at launch.json to see the default port number and commands
9. under node_modules, look at all the fun stuff, and yes, every angular package includes this baggage
10. under src, look at your generated code
    1.  index.html - builds your basic html page, note the <sports-root> entry
    2.  main.ts - bootstrap loader 
    3.  styles.css - for later reference
11. expand the app folder
    1.  app.module.ts - typescript, defines the app and will host and link other modules
    2.  app.component.html - default ui layout for a component
    3.  app.component.ts - defines code for a component, note the selector of sports-root, note the imports
    4.  app.component.spec.ts - unit testing framework, not covered today
    5.  app-routing.module.ts - defines url to component mapping
12. run the app
```
ctrl `
ng serve
```
13. ctrl click on the browser link
14. next we add modules for 5 major sports, run each of these separately in the terminal, watch the src folder while these are running
> hit the + in the terminal to make a new window while the app keeps running
```
ng g m nfl --routing -m app
ng g m nba --routing -m app
ng g m nhl --routing -m app
ng g m mlb --routing -m app
ng g m pga --routing -m app
```
15. each statement makes 2 new files and updates the main module.ts, briefly inspect all of these
16. now we add some a service to each module to store api call methods and an interface for data types
```
ng g s nfl/services/nfl
ng g i nfl/services/nfl

ng g s nfl/services/nba
ng g i nfl/services/nba

ng g s nfl/services/nhl
ng g i nfl/services/nhl

ng g s nfl/services/mlb
ng g i nfl/services/mlb

ng g s nfl/services/pga
ng g i nfl/services/pga

```
17. each statement makes a few new files, briefly inspect all of these
18. now we add home page to each module
```
ng g c nfl/nfl --inline-style -m nfl --flat
ng g c nba/nba --inline-style -m nba --flat
ng g c nhl/nhl --inline-style -m nhl --flat
ng g c mlb/mlb --inline-style -m mlb --flat
ng g c nfl/pga --inline-style -m pga --flat
```
20. each statement makes a few new files, briefly inspect all of these
21. finally, we add component pages to nfl and pga as examples
```
ng g c nfl/components/roster --inline-style
ng g c nfl/components/team --inline-style
ng g c nfl/components/schedule --inline-style
ng g c nfl/components/player --inline-style

ng g c pga/components/season --inline-style
ng g c pga/components/tournament --inline-style
```
21. each statement makes 3 new files and updates the parent module, briefly inspect all of these
22. test one of the new components with a manual url in the already open browser
```
http://localhost:4200/nfl/roster
```
23. this won't work unless we define some routes and outlets
24. edit app.module.html, replace all existing code, then test in the browser
```
<h1 style="background-color: aqua;padding: .5em;">Agility Sports</h1>
<router-outlet></router-outlet>
```
25. repeat this step for all 5 modules, edit only the top level html in each, use that cut and paste!
26. here is a sample for nfl
```
<h1 style="background-color: steelblue;padding: .5em;">National Football League</h1>
<router-outlet></router-outlet>
```
27. now that we have somethign to see, add routing as needed, edit nfl/nfl-routing.module.ts, put his inside the routes array
```
    path: "nfl",
    children: [
      {
        path: 'roster',
        component: RosterComponent
      },
      {
        path: 'schedule',
        component: ScheduleComponent
      },
      {
        path: 'team',
        component: TeamComponent
      },
      {
        path: '',
        component: NflComponent,
        pathMatch: 'full'
      }
    ]
  }

```
28. and this to the pga routing 
```
  {
    path: "pga",
    children: [
      {
        path: 'season',
        component: SeasonComponent
      },
      {
        path: 'tournament',
        component: TournamentComponent
      },
      {
        path: '',
        component: PgaComponent,
        pathMatch: 'full'
      },
    ]
  }

```
29. test all the new routing in your browser
```
http://localhost:4200/nfl
http://localhost:4200/nfl/roster
http://localhost:4200/pga
http://localhost:4200/pga/tournament
```
30. time permitting, add only top routing in mlb, nba, and nhl
```
  {
    path: "mlb",
    component: MlbComponent,
    pathMatch: 'full'
  }
```
31. it would be nice to have a menu, we will use a third party for this
> go to the terminal window
```
npm install primeng
npm install primeflex
npm install primeicons
```
32. edit styles.css
```
@import "primeng/resources/themes/lara-light-blue/theme.css";
@import "primeng/resources/primeng.css";
@import "primeicons/primeicons.css";
@import "primeflex/primeflex.css";

body {
    font-family: var(--font-family);
}
```
33. test style change in the browser
34. edit app.module.ts to add a reference to primeng
> near the top
```
import { MegaMenuModule } from 'primeng/megamenu';
```
> in the imports array
```
MegaMenuModule
```
35. edit app.component.ts to add the megamenu
> at the top
```
import { Component, OnInit } from '@angular/core';
```
> in the export class
```
export class AppComponent implements OnInit {

under the title
  items: MegaMenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      {
        label: 'NFL',
        items: [
          [
            {
              label: 'National Football League',
              items: [
                {
                  label: 'Roster',
                  url: 'nfl/roster'
                },
                {
                  label: 'Team',
                  url: 'nfl/team'
                },
                {
                  label: 'Schedule',
                  url: 'nfl/schedule'
                }
              ]
            }
          ],
        ]
      },
      {
        label: 'MLB',
        url: 'mlb'
      },
      {
        label: 'NBA',
        url: 'nba'
      },
      {
        label: 'NHL',
        url: 'nhl'
      },
      {
        label: 'PGA',
        items: [
          [
            {
              label: 'Professional Golf',
              items: [
                {
                  label: 'Season',
                  url: 'pga/season',
                },
                {
                  label: 'Tournament',
                  url: 'pga/tournament'
                }
              ]
            }
          ]
        ],
      },
    ];
  }
```
36. edit app.component.html to place the megamenu on each page
```
<h1 class="flex gap-4 bg-primary p-3">
  <p-megaMenu [model]="items"></p-megaMenu>
  <span>Agility Sports</span>
</h1>
<router-outlet></router-outlet>
```
37. add a grid to the nfl roster page by adding module support and html
38. edit nfl/nfl.module.ts
> at the top
```
import { TableModule } from 'primeng/table';
```
> in the imports array
```
TableModule
```
39. edit nfl/components/roster/roster.component.ts to add sample data
> inside the export
```
  roster: any = [
    {
      team: 'PHL',
      name: 'Jalen Hurts',
      position: 'QB',
      number: '1'
    },
    {
      team: 'PHL',
      name: 'AJ Brown',
      position: 'WR',
      number: '11'
    }
  ];
```
40. edit nfl/components/roster/roster.component.html and replace all markup
> primeng uses templates to shape the html for the table header and rows, headers have sorting, row cells reference the interface for field names, the word let-roster loops through the array
```
<p-table [value]="roster" [tableStyle]="{ 'min-width': '50rem' }">
    <ng-template pTemplate="header">
        <tr>
            <th pSortableColumn="team">Team <p-sortIcon field="team"></p-sortIcon></th>
            <th pSortableColumn="name">Name <p-sortIcon field="name"></p-sortIcon></th>
            <th pSortableColumn="position">Position <p-sortIcon field="position"></p-sortIcon></th>
            <th pSortableColumn="number">Number <p-sortIcon field="number"></p-sortIcon></th>
            <th pSortableColumn="height">Height <p-sortIcon field="height"></p-sortIcon></th>
            <th pSortableColumn="weight">Weight <p-sortIcon field="weight"></p-sortIcon></th>
            <th pSortableColumn="ageExact">Age <p-sortIcon field="ageExact"></p-sortIcon></th>
            <th pSortableColumn="college">College <p-sortIcon field="college"></p-sortIcon></th>
        </tr>
    </ng-template>
    <ng-template pTemplate="body" let-roster>
        <tr>
            <td>{{ roster.team }}</td>
            <td>{{ roster.name }}</td>
            <td>{{ roster.position }}</td>
            <td>{{ roster.number }}</td>
            <td>{{ roster.height }}</td>
            <td>{{ roster.weight }}</td>
            <td>{{ roster.ageExact }}</td>
            <td>{{ roster.college }}</td>
        </tr>
    </ng-template>
</p-table>
```
41. finally, we think about wiring this up to our api
42. we need an interface the for the nfl roster table, and a service method to call the api
43. edit nfl/services/nfl.ts to add the interface that matches our c# dto
> add at the bottom
```
export interface NFLRosterDto {
    team: string;
    name: string;
    position: string;
    number: string;
    height: string;
    weight: string;
    ageExact: number;
    college: string;
}
```
44. edit nfl/services/nfl.service.ts to add an api call, notice this is injectable
> the baseUrl must match the .NET core minimal api that is still running
```
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NFLRosterDto } from './nfl';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NflService {
  baseURL = 'http://localhost:1106/api/';

  constructor(
    private http: HttpClient
  ) { }

  GetRoster(): Observable<NFLRosterDto[]> {
    return this.http.get<NFLRosterDto[]>(this.baseURL + 'nfl/roster')
  }
}
```
46. the httpClient must be registered at the root of the application
47. edit app.module.ts
> add the import at the top
```
import { HttpClientModule } from '@angular/common/http'; 
```
> and mention it in the imports
```
HttpClientModule,
```
48. then the roster component must call the service to get the data
49. edit nfl/components/roster/roster.component.ts
> at the top, add the service import and a call to ngOnInit
```
import { Component, OnInit } from '@angular/core';
import { NflService } from '../../services/nfl.service';
```
> change the class declaration to use ngOnInit
```
export class RosterComponent implements OnInit {
```
> inject the service in the constructor
```
  constructor(
    private nflService: NflService
  ) {}
```
> subscribe to the api method in ngOnInit, the result will overwrite our sample data array
```
  ngOnInit(): void {
    this.nflService.GetRoster().subscribe({
      next: data => {
        this.roster = data;
      }
    })
  }
```
50. test in the browser, try sorting
51. our final task is pagination
52. edit nfl/components/roster/roster.component.html
> add this to the p-table element
```
dataKey="name"
[rows]="10"
[showCurrentPageReport]="true"
[rowsPerPageOptions]="[10, 25, 50]"
[paginator]="true"
currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
```  
