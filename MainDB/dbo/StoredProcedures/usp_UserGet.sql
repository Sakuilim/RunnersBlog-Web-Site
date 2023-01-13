CREATE PROCEDURE [dbo].[usp_UserGet]
  @id int
AS
BEGIN
  SELECT Id, Name, Email
  from dbo.[USER]
  where Id = @id
END
