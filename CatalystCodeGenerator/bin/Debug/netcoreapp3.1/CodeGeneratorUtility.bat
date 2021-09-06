::
::
echo off
echo........................................
echo Generate solution code from added Entity classes
echo........................................
echo off
:PROMPT
SET /P AREYOUSURE=Are you sure you want to delete generated files(Y/[N])?
IF /I "%AREYOUSURE%" NEQ "Y" GOTO END

::Select the VS version
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\TextTransform.exe"
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\TextTransform.exe"
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\TextTransform.exe"
SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\TextTransform.exe"
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\TextTransform.exe"
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\TextTransform.exe"

echo off
echo Delete previously generated cs code files 
 DEL /F "1_t4EntityHelpersGenerate.cs"
 DEL /F "..\LosAngelesLakers.Domain\Domain\2_t4DomainViewModelsGenerate.cs"	
 DEL /F "..\LosAngelesLakers.Domain\Mapping\3_t4DomainMappingProfileGenerate.cs"	
 DEL /F "..\LosAngelesLakers.Domain\Service\4_t4DomainServicesGenerate.cs"	
 DEL /F "..\LosAngelesLakers.Api\Controllers\5_t4ApiControllerGenerate.cs"	
 DEL /F "..\LosAngelesLakers.Api\5_t4ApiStartupAdditionsGenerate.cs"	
 DEL /F "..\LosAngelesLakers.Test\6_t4IntegrationTestGenerate.cs"
echo .
echo Run all T4s...
echo -generate entity helpers
%tt% "1_t4EntityHelpersGenerate.tt" -out "1_t4EntityHelpersGenerate.cs"
echo -generate domain classes
%tt% "..\LosAngelesLakers.Domain\Domain\2_t4DomainViewModelsGenerate.tt" -out "..\LosAngelesLakers.Domain\Domain\2_t4DomainViewModelsGenerate.cs"
echo -generate mapper classes
%tt% "..\LosAngelesLakers.Domain\Mapping\3_t4DomainMappingProfileGenerate.tt" -out "..\LosAngelesLakers.Domain\Mapping\3_t4DomainMappingProfileGenerate.cs"	
echo -generate services classes
%tt% "..\LosAngelesLakers.Domain\Service\4_t4DomainServicesGenerate.tt" -out "..\LosAngelesLakers.Domain\Service\4_t4DomainServicesGenerate.cs"	
echo -generate controller classes
%tt% "..\LosAngelesLakers.Api\Controllers\5_t4ApiControllerGenerate.tt" -out "..\LosAngelesLakers.Api\Controllers\5_t4ApiControllerGenerate.cs"
echo -generate extended Startup code
%tt% "..\LosAngelesLakers.Api\5_t4ApiStartupAdditionsGenerate.tt" -out "..\LosAngelesLakers.Api\5_t4ApiStartupAdditionsGenerate.cs"
echo -generate Postman json tests
%tt% "..\LosAngelesLakers.Test\Postman\t4PostmanTestsGenerate.tt" -out "..\LosAngelesLakers.Test\Postman\RestApiN.Postman_tests_collection.json"		
echo -generate test classes
%tt% "..\LosAngelesLakers.Test\6_t4IntegrationTestGenerate.tt" -out "..\LosAngelesLakers.Test\6_t4IntegrationTestGenerate.cs"	
echo -add new db migration
%tt% "t4_AddMigration.tt" -out "t4_AddMigration.cs"
echo T4s completed.
pause
:END