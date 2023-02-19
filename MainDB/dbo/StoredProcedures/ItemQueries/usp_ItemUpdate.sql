CREATE PROCEDURE [dbo].[usp_ItemUpdate]
    @Id UNIQUEIDENTIFIER, 
	@Name NVARCHAR(50), 
    @Price DECIMAL(30, 5),
    @Description NVARCHAR(300),
    @CreatedDate DATETIME, 
    @CreatedBy NVARCHAR(50), 
    @ItemAvailabilityStatus NVARCHAR(20),
    @ReservedBy NVARCHAR(50)
AS
BEGIN
  UPDATE dbo.[Item]
  set Name = @Name, Price = @Price, Description = @Description, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ItemAvailabilityStatus = @ItemAvailabilityStatus, ReservedBy = @ReservedBy
  where Id = @Id;
END
