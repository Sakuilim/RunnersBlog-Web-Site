CREATE PROCEDURE [dbo].[usp_UserDelete]
  @id int
AS
BEGIN
  delete
  from dbo.[User]
  where Id = @id
END
