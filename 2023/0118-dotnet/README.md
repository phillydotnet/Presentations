# Philly.NET
# January 18, 2023

## Short Link to This Content: https://bit.ly/pdn230118
## or Scan Here
<img src="images/bit.ly_pdn230118.png" alt="alt text" title="image Title" width="140"/>

## YouTube Replay: *to be determined*

## [Meetup site](https://www.meetup.com/philly-net/events/290824709/) for this event

***

## .NET Encryption
Alan Silverblatt - Consultant

### Slides
Slides and Code can be found at: http://silverblatt.net/encryption.htm


- definition of encryption terminology
- a quick history of encryption
- overview of the two main types of encryption (symmetric and asymmetric)
- a simple application implementing encryption in Dot Net 6
- hashes and digital signatures
- worst practices (things to avoid)

### Notes
Cryptography classes are in the System.Security.Cryptography namespace.

***

## Minimal APIs in .NET Core
Bill Wolff - Agility Systems

### Slides

[View Slides Online](https://1drv.ms/p/s!AnWWJr_PqAvkiGBXvrItkHKzKYV2?e=hGJDgN)

-or- [Click to Download Powerpoint pptx file](files/MinimalAPI-BillWolff.pptx)

Minimal APIs are a simplified approach for building fast HTTP APIs with ASP.NET Core. You can build fully functioning REST endpoints with minimal code and configuration. Skip traditional scaffolding and avoid unnecessary controllers by fluently declaring API routes and actions.

### Notes

[What's new in .NET 7](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7)

Bill noted an emphasis on [Performance (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7#performance)


How to create a new Minimal API Project called `pdn-minimal-api` from the command line
``` cmd
dotnet new webapi -minimal -n pdn-minimal-api
```

Bill noted that if you are afraid of using Swagger because it exposes your API to anyone who can figure out the endpoint, note that the template only uses Swagger in Development builds.
``` C#
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

VS Code Extensions needed:
- C# Extension

***

### More about Philly.NET: https://www.meetup.com/philly-net/
Meets the third Wednesday of the month (Nov, Dec may be different, see Meetup Site)

Code Camps will be announced here.

### More about Philly Azure: https://www.meetup.com/philly-azure/
Meets the first Wednesday of the month (see Meetup site)

### YouTube Channel
Philly.NET: https://www.youtube.com/phillydotnet

Philly Azure: https://www.youtube.com/PhillyAzure