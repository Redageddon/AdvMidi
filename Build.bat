dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
copy bin\Release\netcoreapp3.1\win-x64\publish\AdvMidi.exe Executable\AdvMidi.exe
RD /S /Q bin\Release\netcoreapp3.1\win-x64