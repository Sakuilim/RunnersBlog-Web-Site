CREATE PROCEDURE [dbo].[usp_ItemGetAll]

AS
  SELECT Id, Name, Price, Description, CreatedDate, CreatedBy, ItemAvailabilityStatus, ReservedBy
  FROM dbo.[Item]
RETURN 0
