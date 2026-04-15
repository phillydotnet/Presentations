# Philly.NET - April 15, 2026

# Build an AI Pizza Ordering Bot in C# with Microsoft Foundry and .NET Aspire

Short Link to this content: https://tinyurl.com/pdn260415

### Overview
Join Chris Gomez for a practical look at building an AI-powered pizza ordering bot in C# with Microsoft Foundry and .NET Aspire. We will walk through the core pieces needed to create a conversational ordering experience, connect the services that support it, and see how modern .NET tooling helps you move from idea to working app faster.

Along the way, we will look at how .NET Aspire helps with orchestration, observability, and local development for distributed applications, and how Microsoft Foundry can fit into an AI-focused architecture. The result is a fun demo with patterns you can reuse in real-world intelligent applications.

## Chris Gomez
Chris Gomez is a software developer who loves sharing what he has learned with the community. A Microsoft MVP, Chris regularly presents on topics such as ASP.NET Core, game development, cloud development, and how to grow as a developer. You can find Chris at user groups, conferences, and on The Dev Talk Show on YouTube.

# Hands-On Lab

## Overview
The goal of this lab is to build a simple AI-powered pizza ordering bot using C# and Microsoft Foundry.

The bot will allow users to place pizza orders through a conversational interface, demonstrating how to integrate AI capabilities into a .NET application.

This was inspired by the AI Dev Days session "Build a Pizza Ordering Agent with Microsoft Foundry and MCP" which can be viewed on YouTube: https://www.youtube.com/watch?v=jcDhtVZONb4.

The workshop documentation is found at: https://jolly-field-035345f1e.2.azurestaticapps.net.

## Prerequisites
- An Azure Subscription (you can create a free account if you don't have one)
- An editor like Visual Studio Code or Visual Studio 2022/2026
- .NET 10 SDK or later installed on your machine
  - This may have been installed for you with Visual Studio.  But you can also get it from https://dotnet.microsoft.com/download/dotnet/10.0
- (Optional) Either [install the Azure CLI](https://learn.microsoft.com/en-us/cli/azure/get-started-with-azure-cli?view=azure-cli-latest) or use it through the Azure Cloud Shell.

## Clone the Sample Code
Samples Repo:
https://github.com/thedevtalkshow/PizzaBot-CSharp

Original Workshop Repo for Python: https://github.com/GlobalAICommunity/agentcon-pizza-workshop

## Creating the Foundry Project

- Go to ai.azure.com
- Create a new Foundry project
![Open Create Foundry Project](docs\images\foundry-create-project.png)
- When creating the Foundry project, if you click on *Advanced options*, you can attempt to create the Project, Foundry resource, and select the resource group all in one step.
  - If you haven't created a resource group for this yet, you can click on *Create new resource group* here and it will take you into the Azure portal to complete that step quickly.
  ![Create Foundry Project](docs\images\foundry-create-project-2.png)

|**Field** | **Value** |
|----------|----------|
|*Project name:*      | pizzabot |
|*Foundry resource:*  | pizzabot-foundry |
|*Region:*    | East US 2 |
|*Subscription:*    | (your subscription name here) |
|*Resource group:*    | (your resource group name here or click to create one now) |

## Deploy a base model
In the Foundry Portal:

- Click on Build in the menu in the upper right
- Click on Models in the left menu
- Click on the **Deploy a base model** button
- Select a model like *gpt-4o* or *gpt-4.1-mini*
    - Neither model will incur much cost for the lab. It also will incur no cost if you aren't using it.
- Click **Deploy**
    - If asked, using Default Settings is fine

## Create your first agent

### (Option 1) Sign into your Azure Subscription with the Azure CLI

Before you can use the Foundry Agent Service, you need to sign in to your Azure subscription.

Run the following command and follow the on-screen instructions. Use credentials that have access to your Microsoft Foundry resource:

```bash
az login --use-device-code
```

### (Option 2) Use API Keys for Authentication in your codebase
- Be certain not to share the keys, commit them to source control.  In an emergency you can regenerate the keys or delete the resource group for this lab.

### Create new console app
- Create a lab folder in the root of the cloned repository

```bash
dotnet new console -n Console.Agent
cd Console.Agent

dotnet add package Azure.Ai.Projects --version 2.0.0
```

# Philly.NET - April 15, 2026

## Build an AI Pizza Ordering Bot in C# with Microsoft Foundry and .NET Aspire

## Social Links
[X (Twitter)](https://x.com/phillydotnet)

[Facebook](https://www.facebook.com/groups/phillynet)

[GitHub](https://github.com/phillydotnet)

[YouTube](https://www.youtube.com/phillydotnet)

[Discord](https://discord.gg/j7mFC6H8jE)

[LinkedIn](https://www.linkedin.com/groups/137867/)

[Instagram](https://www.instagram.com/phillydotnet)

[Mastodon](https://jawns.club/@phillydotnet)

[Threads](https://www.threads.com/@phillydotnet)
