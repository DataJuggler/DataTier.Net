--Alter Table Project
--Add TargetFramework int null default (4)

-- To convert existing .NetFramework projects to new TargetFramework
--Update Project
--Set TargetFramework = 4
--Where
--DotNet5 = 0

-- To convert existing DotNet5Projects to new TargetFramework
--Update Project
--Set TargetFramework = 5
--Where
--DotNet5 = 1

