Azure Container Apps

[Azure Container Apps overview](https://learn.microsoft.com/en-us/azure/container-apps/overview) - Overview from the documentation

Example scenarios from the documentation:
[![Azure Container Apps Example Scenarios](https://learn.microsoft.com/en-us/azure/container-apps/media/overview/azure-container-apps-example-scenarios.png)](https://learn.microsoft.com/en-us/azure/container-apps/media/overview/azure-container-apps-example-scenarios.png)

## Your first container app

### Install the Azure Container Apps Extension for Azure CLI

To use the Azure Container Apps extension for the Azure CLI, follow the instructions here:

[Quickstart: Deploy your first container app with containerapp up](https://learn.microsoft.com/en-us/azure/container-apps/get-started?tabs=bash)


```powershell
az extension add --name containerapp --upgrade

az provider register --namespace Microsoft.App

az provider register --namespace Microsoft.OperationalInsights
```
### Creating your first app from a container with the Azure CLI

``` powershell
az containerapp up --name my-container-app --resource-group my-container-apps --location centralus --environment 'my-container-apps' --image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest --target-port 80 --ingress external --query properties.configuration.ingress.fqdn
``````

Delete later with the object id
``` powershell
az ad sp delete --id <object id here>
```

Create a new Minimal API
- File > New Project
- ASP.NET Core Web API (C#)
- After naming to project/solution
    - .NET 7 (earlier should be fine)
    - Enable Docker (checked)
    - Uncheck for Minimal APIs
    - Leave everything else default

Make sure you can build the app, then push to DockerHub

```
docker commit -m "commit message" -a "name" <container id> <username/image name:version>

# Example
# docker commit -m "first version" -a "theapi" 23ddsfa45f spaceshot/theapi:1.0

docker push <username/image name:version>
```

Now you should see the image in docker hub.


# Creating a job
https://learn.microsoft.com/en-us/azure/container-apps/jobs-get-started-cli?pivots=container-apps-job-manual


# az containerapp up

```
az containerapp up \
  --name my-container-app \
  --resource-group my-container-apps \
  --location centralus \
  --environment 'my-container-apps' \
  --image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest \
  --target-port 80 \
  --ingress external \
  --query properties.configuration.ingress.fqdn
```
