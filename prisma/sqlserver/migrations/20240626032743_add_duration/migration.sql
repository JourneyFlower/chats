BEGIN TRY

BEGIN TRAN;

-- AlterTable
ALTER TABLE [dbo].[ChatMessages] ADD [duration] INT NOT NULL CONSTRAINT [ChatMessages_duration_df] DEFAULT 0;

COMMIT TRAN;

END TRY
BEGIN CATCH

IF @@TRANCOUNT > 0
BEGIN
    ROLLBACK TRAN;
END;
THROW

END CATCH
