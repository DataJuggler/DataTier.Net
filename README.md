# DataTier.NET Now Supports .NET 11!

11.13.2026 Version 7.0.0: DataTier.NET now supports .NET 11, and .NET 11 is the default for new projects.
The new .NET 11 project templates (DataJuggler.DataTier.Net11.ProjectTemplatesV2) are installed for you
when you click Create DataTier in the Project Wizard. .NET 10 projects are still supported.

Also fixed in this release: creating a new project could fail with a duplicate key error on ProjectReference
(ObjectLibrary.Enumerations), because the default object references were being added twice.

# Major Fix! You Can Now Use Visual Studio 2022 or Visual Studio 2026 For Development! Thanks ChatGPT!

<b>Setup Instructions</b>

# What You Will Need

1. You will need SQL Server Management Studio and SQL Server or SQL Server Express.
2. Visual Studio 2022 or Visual Studio 2026 *<br/>

* New - If you target .NET 10 or .NET 11 you will need Visual Studio 2026 for your client project,
and for .NET 11 the .NET 11 SDK. Technically Visual Studio 2019 still works for older frameworks (.NET 5 - .NET 7),
but .NET 11 is recommended for new projects.<br/>
