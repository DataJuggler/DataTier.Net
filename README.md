## Welcome To DataTier.Net Home

<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/DataTier.Net%20Ad.png>

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
  
You can install the project Template into Visual Studio 2017 and / or 2019 (recommended).<br/>

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Install%20Data%20Tier.Net%20Templates.png><br/>

<b>Step 3: Build Your Connection String and Setup App.config<br/>
  
<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Build%20Connection%20String.png><br/>

Build your connection string, and once enabled click the Install Conn String & Setup App.config button.<br/>

You will be shown a message box you must restart Visual Studio to complete the setup.<br/>

Open the project again in Visual Studio and run DataTier.Net. You should see Test Database Connection Passed.

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Setup%20Complete.png>

Now you are ready to create your own DataTier.Net projects.

<b>Anatomy of a DataTier.Net Projecgt</b>

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Data%20Model.jpg>

There are four projects that make up a DataTier.Net project:

<img src=https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/Anatomy%20of%20a%20DataTier.Net%20Project.png>

<b>1. Application Logic Component</b>Contains the Controller Manager and Managers for each table and Data Operations (stored procedure calls).
<b>2. Data Access Component</b>Contains the Data Manager and Managers for each table which contain Data Readers and Data Writers.
<b>3. Gateway</b>Contains methods for Find, Load, Save and Delete plus any Custom Methods you create.
<b>4. Object Library</b>The object library uses partial classes and one is created for each table or view in your database.

For more information read the DataTier.Net User's Guide located in the Class Room folder if you clone or online here:
https://github.com/DataJuggler/DataTier.Net/blob/master/DataTier.Net/Class%20Room/Documents/DataTier.Net%20Users%20Guide.pdf

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



