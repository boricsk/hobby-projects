
--select your database
use master
go

EXEC sp_configure 'clr enabled', 1;
RECONFIGURE;

--Do not use in production. Will turn off CLR security settings.
EXEC sp_configure 'clr strict security', 0;
RECONFIGURE;

-- Register your DLL
CREATE ASSEMBLY MyFunctionsAssembly
FROM 'C:\Users\chris\source\repos\MyFunc\bin\Debug\MyFunc.dll'
WITH PERMISSION_SET = SAFE;
go
-- Create CLR function on SQL server
CREATE FUNCTION sp_Multiply(@a INT, @b INT)
RETURNS INT
AS EXTERNAL NAME MyFunctionsAssembly.MyClass.sp_Multiply;
go

--Use your new function
select dbo.sp_Multiply(10,10)

