BACKUP DATABASE [RecApp] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\RecApp.bak',  DISK = N'@dest' WITH  RETAINDAYS = 1, NOFORMAT, NOINIT,  NAME = N'RecApp-Full_Database_Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO
declare @backupSetId as int
DECLARE @dest nvarchar(255)
SET @dest = 'C:\BackUp_' + CAST(DATEPART(weekday, GETDATE()) AS nvarchar(1)) + '.bak'

select @backupSetId = position from msdb..backupset where database_name=N'RecApp' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N'RecApp' )
if @backupSetId is null begin raiserror(N'Error de comprobación. No se encuentra la información de copia de seguridad para la base de datos ''RecApp''.', 16, 1) end
RESTORE VERIFYONLY FROM  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\RecApp.bak',  DISK = N'@dest' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO