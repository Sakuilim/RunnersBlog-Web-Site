CREATE TABLE [dbo].[Item]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
	[Name] NVARCHAR(50) NOT NULL,
    [Price] DECIMAL(30, 5) NOT NULL, 
    [Description] NVARCHAR(300) NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [ItemAvailabilityStatus] NVARCHAR(20) NOT NULL, 
    [ReservedBy] NVARCHAR(50) NOT NULL
)
