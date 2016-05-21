@echo off
REM setting parameters
SET SERVER=localhost\sqlexpress
SET ACCOUNT=%COMPUTERNAME%\ASPNET

ver | find "6.0" > nul
if %ERRORLEVEL% == 0 SET ACCOUNT=NT AUTHORITY\Network Service

ver | find "6.1" > nul
if %ERRORLEVEL% == 0 SET ACCOUNT=IIS APPPOOL\ASP.NET v4.0

echo %1 IIS ���s���[�U�[�� %ACCOUNT% �ɐݒ肵�܂����B
echo %1 %SERVER% �̃f�[�^�x�[�X���쐬���܂��B
PAUSE

REM Web KN_BManage�p�f�[�^�x�[�X�̍쐬
sqlcmd -S %SERVER% -E -i KN_BManage.sql

REM Web KN_BManage�p�f�[�^�x�[�X�ւ̌����̒ǉ�
sqlcmd -S %SERVER% -E -Q "exec sp_grantlogin '%ACCOUNT%'"
sqlcmd -S %SERVER% -E -d KN_BManage -Q "exec sp_grantdbaccess '%ACCOUNT%'"
sqlcmd -S %SERVER% -E -d KN_BManage -Q "create role db_executor"
sqlcmd -S %SERVER% -E -d KN_BManage -Q "grant execute to db_executor"
sqlcmd -S %SERVER% -E -d KN_BManage -Q "exec sp_addrolemember 'db_datareader', '%ACCOUNT%'"
sqlcmd -S %SERVER% -E -d KN_BManage -Q "exec sp_addrolemember 'db_datawriter', '%ACCOUNT%'"
sqlcmd -S %SERVER% -E -d KN_BManage -Q "exec sp_addrolemember 'db_executor', '%ACCOUNT%'"

REM ASP.NET �����o�V�b�v�̍\��
%WinDir%\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql -S %SERVER% -E -A all -d KN_BManage

PAUSE


