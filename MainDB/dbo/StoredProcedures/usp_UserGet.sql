CREATE PROCEDURE [dbo].[usp_UserGet]
  @id int
AS
BEGIN
  SELECT Id, Name, Email
  from dbo.[User]
  where Id = @id
END
