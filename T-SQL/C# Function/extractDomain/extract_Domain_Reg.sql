use WebDoki
go

EXEC sp_configure 'clr enabled', 1;
RECONFIGURE;

EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;

--Do not use in production. Will turn off CLR security settings.
EXEC sp_configure 'clr strict security', 0;
RECONFIGURE;

-- Register your DLL
CREATE ASSEMBLY MyFunctionsAssembly
FROM 'D:\dev\hobby-projects\T-SQL\C# Function\extractDomain\extractDomain\bin\Debug\extractDomain.dll'
WITH PERMISSION_SET = SAFE;
go

-- Create CLR function on SQL server
CREATE FUNCTION extractDomain(@email nvarchar(max))
RETURNS nvarchar(max)
AS EXTERNAL NAME MyFunctionsAssembly.MySQLClass.extractDomain;
go

select dbo.extractDomain('frjfjrfrf')
select dbo.extractDomain('tesztemail@teszceg.hu')