## Welcome To DataTier.Net Home

Update 8.11.2019: I just published a new video on YouTube: 'How To Create Custom Methods With DataTier.Net':
https://www.youtube.com/watch?v=655uS4wU_aU 

Update 8.9.2019: I just learned how to use Benchmark.Net, and my first test DataTier.Net blew away Entity Framework.

|         Method |      Mean |     Error |    StdDev |
|--------------- |----------:|----------:|----------:|
| LoadDTNSetting |  14.24 us | 0.0181 us | 0.0169 us |
|  LoadEFSetting | 195.93 us | 0.5839 us | 0.5462 us |

This test was very simple and just loads 1 record out of a 1 record table (Setting).

I will post the BenchMark.Net project to Git Hub soon.

If I include the creation of the Gateway for DataTier.Net and the DBContext for Entity Framework, DataTier.Net jumps from 14 to 19 and EF jumps fromm 195 to over 700.

I will publish some more results after I get some sleep. I suspect EF might win when multiple records are saved since Save is one at a time in DataTier.Net and multiple records can be saved in 1 call with EF.

I lost my day job yesterday, but this makes me feel better. 

Update 8.7.2019: 
I just create a new video 'Build A Complete C# / SQL Server Application In 15 Minutes With DataTier.Net' (thanks to NuGet magic).
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



