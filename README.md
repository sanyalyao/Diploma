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
