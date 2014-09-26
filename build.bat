@echo off

set msbuild=%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild
set cfg=%1%

if "%cfg%"=="" set cfg=Release

FOR /F %%a IN ('git describe --abbrev^=0 --tag') DO set version=%%a.0

if "%version%"=="" set version="0.0.0.1"

%msbuild% Maybe.build /t:Full /p:Configuration=%cfg% /p:Platform="Any CPU" /p:version=%version%

pause