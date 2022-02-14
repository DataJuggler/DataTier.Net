Update Version 6.0.0: This project has been updated to version 6.0.0, 
howerver it is still for .NET Framework 4.8. Use DataJuggler.Net5 or DataJuggler.Net6
for newer projects.

Note to self: Output of this folder needs to be copied to the lib folder. I am just doing it
manually since I do not update this project often.

Update for version 5.3.0:

Oops! I accidently published and older version yesterday. This is the correct version. Anyone with a 
5.2.2 installation is urged to update to 5.3.0. I frequently work on my own projects late at night 
and sometimes after a couple of beers. Sorry if this caused anyone any problems.

Update for version 5.2.2:

This version better handles tables that do not have an identity incremented integer primary key. 

Update for version 5.1.6: 
The class Function was left out; it is part of DB Compare and used to compare SQL Server Functions.

This file was part of RAD Studio Code Generation Toolkit
https://radstudio.codeplex.com/

This project was formerly known as DataClassBuilder.Net which was the Predecessor to RAD Studio Code Generation Toolkit.

SQLDatabase Connector
This is a wrapper to the SQL Connection and also contains many methods used to read the database schema.
Example Open Source Projects That Use The SQL Database Connector:
RAD Studio Code Generation Toolkit
https://radstudio.codeplex.com/
The SQL Database Connector is used to read the database schema so it can create C# class objects based upon
each table and view and to create the Stored Procedures that implement all the CRUD methods.

DB Compare
https://dbcompare.codeplex.com/
DB Compare reads the database schema and compares two SQL Server databases.
CSharpClassWriter
This class is useful in building applications that code generate C# source code or DTE packages that extend Visual Studio. It contains many helper methods that make code generation with C# much simpler than the default
Microsoft DTE objects. 

Example Open Source Projects for the CSharpClassWriter:
RAD Studio Code Generation Toolkit
https://radstudio.codeplex.com/
RAD Studio Code Generation Toolkit uses this class to code generate the C# object classes and the CRUD methods in the data tier.
Also the project StoredProcedureGenerator uses this class to create the C# class objects that represents Stored Procedures.
Regionizer
https://regionizer.codeplex.com/
This class is used to format C# Documents into regions for Methods, Private Variables, Properties, Constructors and Events.
Regionizer also includes a C# Auto Commenting System that uses regular expressions and can be extended so you can create your own auto comments.



