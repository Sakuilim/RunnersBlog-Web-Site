CREATE PROCEDURE [dbo].[usp_ItemGet]
  @id uniqueidentifier
AS
BEGIN
  SELECT Id, Name, Price, Description, CreatedDate, CreatedBy, ItemAvailabilityStatus, ReservedBy
  from dbo.[Item]
  where Id = @id
END
