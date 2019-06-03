echo off

rem batch file to run a script to create a db
rem 8/27/2018

sqlcmd -s localhost -E -i slpDB.sql
rem sqlcmd -S localhost\sqlexpress -E -i slpDB.sql

ECHO .
ECHO if no error messages appear DBJ was created
PAUSE