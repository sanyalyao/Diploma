# Salesforce
## _Instruction_

This is the solution with autotests for Salesforce website - salesforce.com.

## Tests list
##### API
- Task tests
- Account tests

##### UI
- Account tests
- Contact tests
- Group tests

##### Negative tests
- Contact tests
- Group tests

## Features

- Logging
- Allure
- Running UI and API tests in Visual Studio

## Tech

The solution uses a number of nuget packages:

- [Allure.NUnit](https://www.nuget.org/packages/Allure.NUnit/2.9.5-preview.1) - NUnit attributes extenstions for Allure
- [Faker.Net](https://www.nuget.org/packages/Faker.Net) - C# port of the Ruby Faker gem (http://faker.rubyforge.org/) and is used to easily generate fake data: names, addresses, phone numbers, etc.
- [NLog](https://www.nuget.org/packages/NLog) - NLog is a logging platform for .NET with rich log routing and management capabilities.
NLog supports traditional logging, structured logging and the combination of both.
- [NUnit](https://www.nuget.org/packages/NUnit) - NUnit features a fluent assert syntax, parameterized, generic and theory tests and is user-extensible.
- [RestSharp](https://www.nuget.org/packages/RestSharp/110.2.1-alpha.0.10) - Simple REST and HTTP API Client
- [Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver) - Selenium is a set of different software tools each with a different approach to supporting browser automation.
- [Selenium.WebDriver.GeckoDriver](https://www.nuget.org/packages/Selenium.WebDriver.GeckoDriver) - Install Gecko Driver (Win32, Win64, macOS, macOS arm64, and Linux64) for Selenium WebDriver into your Unit Test Project.

And different approaches to developing frameworks and tests:
- Driver Factory
- Browser
- Page Object
- Page Steps
- Wrappers
- Builder for model
- Chain of invocation
- Faker

## Installation

Download zip archive: click Button **Code** then **Download ZIP**. Exctract files and open **Diploma.sln** in Visual Studio

For running API tests you have to install [Salesforce CLI](https://developer.salesforce.com/docs/atlas.en-us.244.0.sfdx_setup.meta/sfdx_setup/sfdx_setup_install_cli.htm)

After installing Salesforce CLI, follow these steps:
- Open cmd (terminal console)
- Log in to your Developer org with Salesforce CLI
```sh
sfdx auth:web:login
```
A browser opens to https://login.salesforce.com.

- In the browser, log in to your Developer org with your user’s credentials.
- In the browser, click **Allow** to allow access.

- At the command line, get the access token by viewing authentication information about your org.

```sh
sfdx force:org:display --targetusername <username>
```

For example:
```sh
sfdx force:org:display --targetusername gopad74116@onlcool.com
```

Example command output:
```sh
 Access Token     00D8e000000RWWC!AQgAQPRRz8wy.Rlnzd5RywlRTDxvxF2vKx2A5MeD4jU1fldEICcoOoKacOzUqvg6lVUhDCZiET90zav1b4_7RcwQoXEaAHh9
 Api Version      58.0                                                                                                  
 Client Id        PlatformCLI                                                                                           
 Connected Status Connected                                                                                             
 Id               00D8e000000RWWCEA4                                                                                    
 Instance Url     https://ozatvn2-dev-ed.develop.my.salesforce.com                                                      
 Username         gopad74116@onlcool.com   
```

Now in the solution "Diploma" open **Core** => **RunSettings** => **settings.runsettings**

Replace **Authorization**, **Url**, **Username** and **Password** with your data

**Authorization** and **Url** - you got upper with command _sfdx force:org:display_

**Username** and **Password** - the credentials from your salesforce account

Now click **Build** => **Build solution**

### You are ready to run UI and API tests!


# Allure

### Instalation

You can use one of the following ways to get Allure:

- Grab it from [releases](https://github.com/allure-framework/allure2/releases) (see Assets section).

Using Homebrew:
```sh
$ brew install allure
```
For Windows, Allure is available from the [Scoop](https://scoop.sh/) commandline-installer. To install Allure, download and install Scoop and then execute in the Powershell:
```sh
scoop install allure
```

### Using

In cmd open directory _Diploma-main\TestCases\bin\Debug\net6.0_

Execute:
```sh
allure serve
```

After that a browser opens allure page with tests results


# Checklist

Checklist is a set of ideas [for test cases]. The last phrase is bracketed, for a reason, because in general a checklist is just a collection of ideas: ideas for
testing, ideas for development, ideas for planning and management — in other
words, a collection of any ideas.
#
TasksTests - Checking task creation, deleting and editing
|Test name|Description|
|---------|-----------|
|**CreateTask**|Creates one task and checks result via **taskServiceSteps.CreateNewTaskSteps**| 
|**DeleteTask**|Deletes the first task from the tasks list via **taskServiceSteps.DeleteTaskSteps**|
|**EditTask**|Edits the first task from the tasks list via **taskServiceSteps.EditTaskSteps**|

**taskServiceSteps.CreateNewTaskSteps** - checks task ID in tasks list and success response is or not

**taskServiceSteps.DeleteTaskSteps** - checks how many tasks there are and success response is or not

**taskServiceSteps.EditTaskSteps** - checks success response is or not
#
GroupTests - Checking group creation, deleting and editing
|Test name|Description|
|---------|-----------|
|**CreateGroup**|Creates one group and checks if groups list contains new group|
|**DeleteGroup**|Deletes the first group from groups list and checks if groups list does not contain that group|
|**EditGroup**|Edits the first group from groups list and checks if groups list contains the group with the new name and does not contain the group with the old name|

**EditCreationGroupPage** - contains methods for creation new group, editing a group, getting information about a group, checking if error exists

**GroupsPage** - contains methods for opening the page with groups, checking if groups table contains a group's name, opening a group's page by sequence number or by group's name, editing a group by sequence number or by group's name and getting groups' names

**GroupPage** - contains methods for deleting a group
#
Negative tests - Checking errors of creation new objects and editing an objects
|Test name|Description|
|---------|-----------|
|**CreateContactWithoutLastName**|Checkes a negative push message when the last name is not filled up. Checks if error exist by error's title|
|**EditContact**|Deletes last name of the contact and try to save changes. Checks if error exist by error's title|
|**CreateGroupWithoutName**|Checkes a negative push message when a name is not filled up and access type is chosen. Checks if error exist by error's text|
|**CreateGroupWithoutAccessType**|Checkes a negative push message when a name is filled up and access type is not chosen. Checks if error exist by error's text|
|**CreateGroupWithEmptyFields**|Checkes a negative push message when a name is not filled up and access type is not chosen. Checks if error exist by error's text|
