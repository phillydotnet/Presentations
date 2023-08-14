# Philly,NET - July 12, 2023

## [Meetup site](https://www.meetup.com/philly-net/events/294720539/) for this event

***

## 2 Hours with Azure Kubernetes

### Presented by: Jason van Brackel
Twitter: @JasonvanBrackel

#### Overview
In this hands-on Jason will walk you through provisioning and working with Kubernetes. Topics will include

- Deploying Kubernetes Locally and with Azure
- Kubernetes Basics
- Working with kubectl
- Some Kubernetes power tools
- .NET Application packaging and deployment models.

Those who want to work alongside the presenter should have a laptop with Docker installed. We'll keep this as OS-agnostic as possible.

### Notes

Jason starts off with "Get these tools"

- kubectl
- k9s
- helm
- draft

#### Lab

In the Azure Portal

Search for Kubernetes Services.  Click Create.
- Create a Kubernetes cluster
    - Give the resource group a name (or remember it) 
    so you can delete this group at the end of the night.
    - For Cluster preset configuration - select Production Standard 
    - What is Azure CNI vs Kubenet? Azure CNI is faster, but Kubenet is more of a standard.
    - Recommend disabling automatic upgrade.  You want to strive for declaratively built clusters and avoid long lived clusters (remember, cattle... not pets)

#### About Kubernetes Versioning
There is a release every few months.  In their versioning, the 1 doesn't mean a whole lot, even if there are breaking changes.  A kubernetes pro will refer to, for example, 1.25.5 as "25.5".




***

# Philly,NET - July 12, 2023

## 2 Hours with Azure Kubernetes - Jason van Brackel

## Short Link to This Content: https://bit.ly/pdn230712

## or Scan Here
<img src="images\pdn230712.png" alt="QR Code for direct link to this page" width="256"/>