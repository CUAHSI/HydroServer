@echo This Assumes that the virtual directories are in virtualdirectories

set /p AppNameName= Name of VirtualDirectory in config file  

set VirtualDirectory=virtualdirectories

setacl -on  "%VirtualDirectory%\%AppNameName%" -ot file -actn ace -ace "n:everyone;p:read"  -ace "n:ASPNET;p:full"   -ace "n:administrators;p:full" 

set /p return= HIT RETURN TO EXIT