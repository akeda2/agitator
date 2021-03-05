echo on
mkdir .\bin\Debug

xcopy /K /Y /I .\files\*.txt .\bin\Debug

xcopy /K /Y /I .\scripts .\bin\Debug\scripts

