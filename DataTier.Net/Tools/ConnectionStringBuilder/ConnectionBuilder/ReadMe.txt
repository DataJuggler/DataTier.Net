The Connection String Builder now handles Encrypt=False (or Encrypt=True if your database is encrypted).

For .NET Core projects, meaning .NET Core, .NET5, .NET6, .NET7 or onward you should leave the
IncludeEncryptCheckBox as checked and the value as False unless your database is encrypted.

Tip: If you would like your server name to be populated, set your Server Name in the app.config file
and build your project, or in the Exe.config modify the entry for ServerName.