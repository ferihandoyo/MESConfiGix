# MESConfiGix
For use with MES Configurator tool to Logix 

Quick and dirty implementation of CIP to replace outdated OPC-DA for MES Excel config tool.
Use as is basis. Because I don't build the CIP driver, this is based on existing python based CIP library from https://github.com/dmroeder/pylogix.git.
Full credits goes to the person who built the driver. 
The referenced Library is licensed under apache license, obtain LICENSE.txt from their repository.


To register, run regasm (depending on Windows target):
32bit: regasm is in C:\Windows\Microsoft.NET\Framework\v4.0.30319\ 
64bit: regasm is in C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ 

run regasm /codebase and point to .dll
regasm /codebase "C:\Users\admin\source\repos\MESConfiGix\CIPWriter\bin\Debug\CIPWriter.dll"


To use in VBA, select the TLB file

