CREATE PROCEDURE [dbo].[usp_ItemInsert]
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
  INSERT into dbo.[Item] (Id, Name, Price, Description, CreatedDate, CreatedBy, ItemAvailabilityStatus, ReservedBy)
  values (@Id, @Name, @Price, @Description, @CreatedDate, @CreatedBy, @ItemAvailabilityStatus, @ReservedBy)
END
