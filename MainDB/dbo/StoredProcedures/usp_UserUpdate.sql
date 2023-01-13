CREATE PROCEDURE [dbo].[usp_UserUpdate]
  @Id int,
  @Name NVARCHAR(50),
  @Email NVARCHAR(50),
  @Password NVARCHAR(50)
AS
BEGIN
  UPDATE dbo.[User]
  set Name = @Name, Email = @Email, Password = @Password
  where Id = @Id;
END
