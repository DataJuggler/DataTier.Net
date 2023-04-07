Update 4.7.2021: New video for DataTier.Net: https://youtu.be/mQRN6SYxL-s

New sample project that goes with the above video: https://github.com/DataJuggler/IdeaBank


Update 4.3.2023: I fixed the Project Templates for .NET7. I am Working on a new release version now.

Update 3.12.2023: I fixed the install version path not opening the SQL Scripts required to install DataTier.Net.

Update 1.18.2023: DataTier.Net now allows you to target .NET Framework, .NET5, .NET6 or .NET7 (Default).
There is also a release version now in case you do not want to installed Visual Studio 2019, which is required to use the source code version.

Update 3.30.2022: DataJuggler.Net 6.0.4 fixes bugs related to Creating Blazor Data Services for .NEt6. The Blazor Data Services Control was only showing .NET5.
Also, DataJuggler.Net was updated because the writing of references was writing for .NET5.

Update 12.30.2021: DataTier.Net 3.0 was just released. The new version allows you to target .NET Framework, .NET5 or .NET6.

I just published a new video last night that shows you how to clone DataTier.Net and install the DataTier.Net.Database.

Why I Use DataTier.Net instead of Entity Framework
https://youtu.be/2cnDuax3amE

In this little over an hour video I clone DataTier.Net and create the DataTier.Net.Database and then create a one table SQL Server database named Runner.

Update 7.13.2021: .Net Framework Templates have a bug I caused when I moved CryptographyHelper to its own projects. The easy fix is just remove any of the code for CryptographyHelper, and get rid of any calls that have a useEncryption. I was planning on only making updates to .Net 5, but I will see if I can fix this when I get some time.

For .Net 5 projects, this is not an issue.

## Welcome To DataTier.Net Home

<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/DataTier.Net%20Ad.png height=320 width=320>

<b>Setup Instructions - 3 Easy Steps</b>

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/3%20Easy%20Steps.png>
(screen shot of DataTier.Net setup screen).

<br/>
<b>Step 1: Create DataTier.Net Database</b><br/>
1. Create a new database in SQL Server Management Studio named DataTier.Net.Database<br/>
2. Check the box 'DataTier.Net Database Has Been Created:<br/>

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Step%201%20-%20Part%202.png />

As the instructions indicate, this will launch SQL Server Management Studio. You may be prompted to login.<br/>

Execute the SQL script to install DataTier.Net tables and stored procedures.<br/>

<b>Geeky Note:</b> DataTier.Net was built using DataTier.Net.

<b> Step 2: Install DataTier.Net Project Templates Installer VSIX

<b>.Net Framework Only. the Dot Net Core templates are installed via a link on the Setup Scren</b>
You can install the project Template into Visual Studio 2017 and / or 2019 (recommended).<br/>

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Install%20Data%20Tier.Net%20Templates.png><br/>

Dot Net Core instructions

Open a command prompt or PowerShell window and execute:

dotnet new -i DataJuggler.DataTier.Net.Core.ProjectTemplates

<b>Step 3: Build Your Connection String and Setup App.config<br/>
  
<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Build%20Connection%20String.png><br/>

Build your connection string, and once enabled click the Install Conn String & Setup App.config button.<br/>

You will be shown a message box you must restart Visual Studio to complete the setup.<br/>

Open the project again in Visual Studio and run DataTier.Net. You should see Test Database Connection Passed.

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Setup%20Complete.png>

Now you are ready to create your own DataTier.Net projects.

<b>Anatomy of a DataTier.Net Project</b>

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Data%20Model.jpg>

There are four projects that make up a DataTier.Net project:<br/>

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Anatomy%20of%20a%20DataTier.Net%20Project.png>

<b>1. Application Logic Component</b> Contains the Controller Manager and Managers for each table and Data Operations (stored procedure calls).<br/>
<b>2. Data Access Component</b> Contains the Data Manager and Managers for each table which contain Data Readers and Data Writers.<br/>
<b>3. Gateway</b> Contains methods for Find, Load, Save and Delete plus any Custom Methods you create.<br/>
<b>4. Object Library</b> The object library uses partial classes and two files are created for each table or view in your database:<br/>

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Partial%20Classes.png>

<b>Do not add any code to the data class or it will be overwritten next time you build with DataTier.Net.</b>
The file .data.cs is code generated every time you build with DataTier.Net. 

The .business.cs is only created if it does not already exist, so you are free to add any custom methods or properties to the business class.

For more information read the DataTier.Net User's Guide located in the Class Room folder if you clone or online here:
https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/DataTier.Net%20Users%20Guide.pdf

--
Update 10.20.2019: I add a new feature that allows you to create a Custom Where Clause https://youtu.be/59CyqxS9JVI 

-- 

Update 10.4.2019: I added a few new features regarding Order By in descending order, and I fixed a couple of bugs regarding Delete by procedures and what can be enabled (changed) on a Delete By procedure.

--

Update 9.26.2017: I just published a new video demonstrating DataTier.Net 2.1 For Dot Net Core 3.0 and Blazor Projects.

https://youtu.be/sowTLLeAfm8

--
Update 9.23.2019: Version 2.1.0 has been released.

Many of the Blazor features have only been tested in a couple of projects so far. I am sure this code will evolve as Blazor matures.
--
Update 9.15.2019: 
Major Milestone

DataTier.Net 2.0.3 has been released.

DataTier.Net now works with Dot Net Core!

When you get started with DataTier.Net, if you are creating projects for both .Net Framework and Dot Net Core then you will need to still complete Step 2 of the setup screen. If you only want to create Dot Net Core projects, you may skip installing the .Net Framework project templates.

Note: As of today you must use Visual Studio 16.3 Preview 4 is recommended to use DataTier.Net with DotNetCore.

Install DataTier.Net.Core.ProjectTemplates

Open a command promt or PowerShell window and execute:

dotnet new -i DataJuggler.DataTier.Net.Core.ProjectTemplates

You should see a message the project templates have been installed:

DataJuggler.DataTier.Net.Core.ProjectTemplates      DataTier.Net.Core.ProjectTemplates      

Then to create a new data library project, navigate to the folder in your command prompt:

cd (full path to project directory)

Example:

cd c:\Projects\DotNetCoreTest

c:\Projects\DotNetCoreTest>

Create DataTier.Net Dot Net Core DataTier:

dotnet new DataTier.Net.Core.ProjectTemplates

This will create the four projects that make up a DataTier.Net data tier in the current folder.

Updated documentation and videos are coming soon.

Update 9.11.2019: I now have a new website: https://www.datajuggler.com 

I built this site using C#, SQL Server, Blazor and DataTier.Net.

Blazor is my new favorite web development platform.
--
Update 9.4.2019: Data Juggler joined Twitter today! Ask your DataTier.Net questions @Data_Juggler.

Update 8.29.2019: I created two short videos today:

DataTier.Net 101 - Class #2 - How To Create Enumerations
https://youtu.be/vzVAiiulyUs

DataTier.Net 101 - Class #3 - How To Delete A Table
https://youtu.be/uJ30y6JHYKs

Update 8.23.2019: I am excited to announce the release of DataTier.Net version 1.3.0.

This version works with either .Net Framework or .Net Core. I have only tested with Blazor Preview 8, and you must use tthe pre release preview of System.Data.SQLClient 4.7.0+ for it to work with Blazor.

For .Net Framework projects, 4.6.1 of System.Data.SqlClient is installed when you add the Nuget package DataJuggler.Net.

If you have previously installed the project templates, you will need to uninstall and reinstall the templates as they have been updated.

When you create a DataTier.Net.ClassLibrary project, you now must add two Nuget packages.

1. DataJuggler.Core.UltimateHelper to Application Logic Component
2. DataJuggler.Net to Data Access Component.

I did try to make the project templates install the Nuget packages automatically and never could get it to work.

Instructions for .Net Core / Blazor, or if you prefer to use Environment Variables over Connection Strings in an app.config or web.confg:

Create an Environment Variable and give it a name for your project.

Example: DataJugglerWebConnection

In Windows 10 Search Box type: Edit Environment Variables For Your Account

Create an Environment Variable and set the value to the connection string you want to use.

Then when you create an instance of the Gateway, pass in the connection name:

    // set the connectionName
    string connectionName = "DataJugglerWebConnection";

    // Create a new instance of a 'Gateway' object, and set the connectionName
    Gateway gateway = new Gateway(connectionName);

Note: you must use Nuget Package DataJuggler.Core.UltimateHelper version 1.3.5 or greater, as this includes a new class EnvironmentVariableHelper.cs.

9.23.2019:
I created a new sample project using Blazor & DataTier.Net: 
https://github.com/DataJuggler/BlazorToDoList 

More Blazor tutorials and videos are coming soon, I just wanted to publish a release with DataTier.Net working for .Net Framework and .Net Core.
--
Update 8.31.2019: I released version 1.3.2 today. I fixed a bug where new tables or views would not change the selected table in the Data Editor (Manage Data Button Click) unless the project had been saved and opened.

Update 8.19.2019: I am learning Blazor Preview 8 and Dot Net Core, and quickly found out all of my connection strings stopped working due to the lack of an app.config or web.config.

My first thought was to add this Microsoft.Extensions.Configuration & Microsoft.Extensions.Configuration.JSon, but this added about a dozen depenency Nuget packages, so instead I am making a breaking change for the Version 2 of the project templates.

The breaking change is going to be when you create a Gateway object, you must pass an enivonment variable name for the Connection String.

I learned how to create Environment variables today, and I have to admit I felt kind of stupid all the years I commented out connection strings for Dev, Test & Production machines.

It is 2019, and like or not Dot Net Core is the future (mostly not for me so far, but I still like 8 tracks).

I am going to finish my project in Blazor for my website before I make the new change.

So far Blazor is pretty cool, but Dot Net Core takes some getting used to.

Update 8.11.2019: I just published a new video on YouTube: 'How To Create Custom Methods With DataTier.Net':
https://www.youtube.com/watch?v=655uS4wU_aU 

Update 8.7.2019: 
I just created a new video 'Build A Complete C# / SQL Server Application In 15 Minutes With DataTier.Net' (thanks to NuGet magic).
https://www.youtube.com/watch?v=nS7pKZvOaSM

DataTier.Net is an all stored procedure alternative to Entity Framework. 

After cloning, right click the solution and select 'Manage Nuget Packages for Solution'. Then click the 'Restore' button.

Rebuild the solution. You may need to set DataTier.Net.Client project as the Startup Project:
DataTier.Net\DataTier.Net\Client

I also included a new Connection String Builder form.

Please visit my YouTube channel to see the latest videos on DataTier.Net.

<a href='https://www.youtube.com/channel/UCaw0joqvisKr3lYJ9Pd2vHA'>Data Juggler on YouTube<a/>

This page will be updated as I just learned how to use Git Hub pages today.

Update 7.13.2019: I learned how to install Project Templates using VSIX installers, so now using DataTier.Net
is easier than ever before.

I updated the Quick Start Guide in both Word and PDF format, which is located in the DataTier.Net Class Room here:

https://github.com/DataJuggler/DataTier.Net/tree/master/DataTier.Net/Class%20Room/Documents



