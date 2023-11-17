set p=Simego.DataSync.Providers.MySQL
dotnet build -c Release
rmdir ..\dist\ /S /Q
mkdir ..\dist\files\%p%
xcopy ..\src\%p%\bin\Release\net8.0-windows7.0\*.* ..\dist\files\%p%\*.* /y /s
cd ..\dist\files\
del .\%p%\Simego.DataSync.Core.dll
del .\%p%\Simego.DataSync.Providers.Ado.dll
del .\%p%\Simego.DataSync.Security.dll
del .\%p%\Simego.DataSync.SqlSchemaNavigator.dll
tar.exe -acf ..\%p%.zip *.*
cd ..\..\src


