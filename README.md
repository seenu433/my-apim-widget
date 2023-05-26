# APIM Custom Widget Sample

## Overview

This project includes a sample widget for Azure API Management Developer Portal. The widget is a simple HTML page that invokes an external API on click of a button. The widget is configured using the following parameters:

- External API URL

The *api* folder contains the code for the external API. The API is a C# Azure function app that accepts the below parameters as headers:

- UserToken: The user token that is passed to the the widget
- UserId: The user id that is passed to the widget
- ApiManagementUrl: The URL of the APIM Management endpoint
- Apiversion: The version of the APIM Management API

These parameters are obtained by calling the [askForSecrets](https://learn.microsoft.com/en-us/azure/api-management/developer-portal-extend-custom-functionality#azureapi-management-custom-widgets-toolsaskforsecrets) function in the widget.

The function validates the user token and user id using the SASToken Custom Binding and injects the validated user object.

## Deployin the API

- Change the directory to *api*
- Create the [function app](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-csharp?tabs=azure-cli#create-supporting-azure-resources-for-your-function)
- [Publish](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-csharp?tabs=azure-cli#deploy-the-function-project-to-azure) the function app

## Deploying the widget

- Update the subscription, resource group and apim instance name in the resoureceId field of deploy.js
- Execute *npm run deploy*
- The widget is deployed to the APIM instance
- Add the widget to a page in the developer portal
- Configure the widget with the external API URL