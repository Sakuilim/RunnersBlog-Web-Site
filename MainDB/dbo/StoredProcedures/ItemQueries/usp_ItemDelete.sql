CREATE PROCEDURE [dbo].[usp_ItemDelete]
  @id uniqueidentifier
AS
BEGIN
  delete
  from dbo.[Item]
  where Id = @id
END
