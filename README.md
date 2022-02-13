# Eclipse Engine
Author - [@jwrmg](https://www.github.com/jwrmg) | [GitHub](https://www.github.com/jwrmg) | [Discord]() 
* Started on 09.02.2022.
* Last Update on 14.02.2022.   

Table of Contents
====================

* [Introduction](#introduction)
* [Installation](#installation)
  * [Getting Started](#getting-started)
  * [Installing](#installing)
* [Usage](#usage)
    * [Creating a new application](#creating-a-new-application)
    * [Running the application](#running-the-application)
    * [Testing the application](#testing-the-application)
* [Features](#features)
  * [Completed](#completed)
  * [In Development](#in-development)
  * [Planned](#planned)
* [Deployment](#deployment)
    * [Deploying the application](#deploying-the-application)
    * [Deploying the application to Google Cloud](#deploying-the-application-to-google-cloud)
    * [Deploying the application to Heroku](#deploying-the-application-to-heroku)
    * [Deploying the application to Azure](#deploying-the-application-to-azure)
    * [Deploying the application to AWS](#deploying-the-application-to-aws)
    * [Deploying the application to Digital Ocean](#deploying-the-application-to-digital-ocean)
    * [Deploying the application to Netlify](#deploying-the-application-to-netlify)
* [Libraries](#libraries)
* [Licenses](#licenses)
    * [Main License](#main-license)
    * [Library Licenses](#library-licenses)
* [Contributing](#contributing)

* [Extra Stuff](#extra-stuff)
  * [Future Plans](#future-plans)
  * [FAQ](#faq)
  * [Support](#support)
  * [Acknowledgements](#acknowledgements)
  * [Credits](#credits)
  * [Contact](#contact)

---

Introduction
============
    To be written.

Installation
===
* ### Getting Started
      To be written.
* ### Installing
      To be written.

Usage
=====
* ### Creating a new application
  * #### From Console Application 
    ```C#
    class ExampleApplication : ConsoleApplication
    {
        protected override void OnApplicationInitialize()
        {
            // Code here will be executed before the application starts.
            // Should be used in replacement for a constructor for classes that
            // Inherit from BaseModel.
        }
        protected override void OnApplicationStart()
        {
            // Code here will be executed when the application starts.
        }

        protected override void OnApplicationTick()
        {
            // Code here will be executed at the beginning of each frame.
        }

        protected override void OnApplicationLateTick()
        {
            // Code here will be executed at the end of each frame.
        }

        protected override void OnApplicationEnd()
        {
            // Code here will be executed when the application ends.
        }
    }
    ```
  * #### From Windowed Application
    ```C#
    class ExampleApplication : WindowApplication
    {
        protected override void OnApplicationInitialize()
        {
            // Code here will be executed before the application starts.
            // Should be used in replacement for a constructor for classes that
            // Inherit from BaseModel. 
        }
    
        protected override void OnApplicationStart()
        {
            // Code here will be executed when the application starts.
        }
    
        protected override void OnApplicationTick()
        {
            // Code here will be executed at the beginning of each frame.
        }
       
        protected override void OnApplicationLateTick()
        {
            // Code here will be executed at the end of each frame.
        }
    
        protected override void OnApplicationDraw()
        {
            // Code here will be executed when the application draws.
        }
    
        protected override void OnApplicationEnd()
        {
            // Code here will be executed when the application ends.
        }
    }
    ```
* ### Running the application
```C#
static void Main()
{
    // Create a new application.
    ApplicationEngine.Systems.ApplicationEngine.Create<ExampleApplication>();
    // Initialize the Graphics Driver (only for windowed applications).
    ApplicationEngine.Systems.ApplicationEngine.InitializeGraphics<ExampleDriver>();
    // Run the application. (this will run until ApplicationDriver.Stop() is called)
    ApplicationEngine.Systems.ApplicationEngine.Run();
}
  ```
Features
========
* ### Completed
  * #### Frozen Data Structure (dynamic readonly) (13.02.2022)
  * #### Graphics Driver Base Class (13.02.2022)
    * <B>Raylib Graphics Driver. (13.02.2022)</B>
  * #### ImGui Implementation (10.02.2022)
  * #### Time Driver (10.02.2022)
  * #### Integrated Singleton Pattern (10.02.2022)
  * #### Abstract Base Model (10.02.2022)
* ### In Development
  * #### Window Application Framework (10.02.2022)
  * #### Console Application Framework (10.02.2022)
  * #### Entity Framework (10.02.2022)
  * #### Core Engine Framework (09.02.2022)
* ### Planned
  * #### Authentication & Authorization Microservice
    * <B>Web Tokens</B>
  * #### Notification Microservice
    * <B>Email</B>
    * <B>SMS</B>
    * <B>Push Notifications</B>
  * #### Request & Response Logging
  * #### Throttling
  * #### Asynchronous Operations
  * #### Error Logging Microservice
  * #### Caching
  * #### Localization
  * #### Logging
  * #### Data Analytics
  * #### Queueing
  * #### and more...

Deployment
==========
* ### Deploying the application
        To be written.
* ### Deploying the application to Google Cloud
        To be written.
* ### Deploying the application to Heroku
        To be written.
* ### Deploying the application to Azure
        To be written.
* ### Deploying the application to AWS
        To be written.
* ### Deploying the application to Digital Ocean
        To be written.
* ### Deploying the application to Netlify
        To be written.


Libraries
=========
* [ImGui C# Binding - Eric Mellino](https://github.com/mellinoe/ImGui.NET).
* [Raylib C# Binding - Chris Dill](https://github.com/ChrisDill/Raylib-cs). (Until in house rendering engine is implemented) 

Licenses
=======
* ### Main License
      To be written.

* ### Library Licenses
  * [ImGui License](https://github.com/mellinoe/ImGui.NET/blob/master/LICENSE).
  * [Raylib License](https://github.com/ChrisDill/Raylib-cs/blob/master/LICENSE).

Contributing
============
      To be written.

Extra Stuff
==========
* ## Future Plans
      To be written.

* ## FAQ
      To be written.  

* ## Support
      To be written.

* ## Acknowledgements
      To be written.

* ## Credits
      To be written.

* ## Contact
      To be written.

---

#### Please contact me for removal if you or your resources are in this section.
<details>
<summary>Resources of Study.</summary>

* [Raylib CheatSheet - Raylib.com](https://www.raylib.com/cheatsheet/cheatsheet.html)
* [Yeet Engine - Michael Kirsch](https://github.com/MichaelKirsch/YEET-Engine)
</details>




