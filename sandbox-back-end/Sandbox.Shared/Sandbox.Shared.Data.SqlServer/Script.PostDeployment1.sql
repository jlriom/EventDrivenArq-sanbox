
declare @script varchar(500)

BEGIN TRY
    BEGIN TRANSACTION

    :r .\scripts\01_users_create_roles.sql
    :r .\scripts\02_users_create_admin.sql
    :r .\scripts\021_users_create_users_sample.sql
    :r .\scripts\03_doc_doc_status.sql

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;

   ROLLBACK TRANSACTION
END CATCH;
