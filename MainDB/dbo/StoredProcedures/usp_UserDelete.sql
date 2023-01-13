CREATE PROCEDURE [dbo].[usp_Get]
  @id int
AS
BEGIN
  delete
  from dbo.[USER]
  where Id = @id
END
