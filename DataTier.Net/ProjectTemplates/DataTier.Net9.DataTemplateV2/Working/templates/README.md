DataTier.Net9.ClassLibrary Version2 is a set of project templates for creating a DataTier.Net project targeting .Net9.

Version 2 combines the four projects into 2 projects. I moved the DataGateway and ApplicationLogicComponents classes into
the DataAccessComponent. The ultimate goal is to get the project down to just the Object Library, and move the DataAccessComponent logic into a Data File that 
can be processed. I am first combining down to two projects as this seems simpler. Then from their I will work on a 1 project version for the templates.

More info about DataTier.Net is available here:
https://github.com/DataJuggler/DataTier.Net

Update 1.3.2024: Moved to a two project data tier template. I am now modifying DataTier .Net to handle both the 4 project version and the two.
Once finished with this update, I may see if I can write a converter to convert the four project templates to a two project structure.

Update 11.18.2023: This template is for creating a DataTier.Net project targeting .NET 8.

Previous Release Notes From .NET 7 Release

Update 8.20.2023: I added some compiler warnings to ignore to the templates, and added the word static
to a method the ControllerCreator creates Create (Object Name) Parameter)
		
Update 8.14.2023: I changed the icon to the DataTier.NET Icon for this template.
		
Update 8.13.2023: DataJuggler..NET7 was updated because DataJuggler.UltimateHelper was updated.

Update 8.6.2023: I removed an used variabled called exception in the AuthenticationManager.ConnectToDatabase method.

Update 7.29.2023: I updated this project to the latest Nuget packages for
DataJuggler.Net7 and DataJuggler.UltimateHelper.

Update 4.3.2023: I updated this project to the latest Nuget packages, which solves the bug of EnvironmentVariableHelper
now requires a parameter for Target (User, System or Process).

Update 11.14.2022: I am testing the .NET 7 version now.