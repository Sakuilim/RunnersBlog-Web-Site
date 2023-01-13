CREATE PROCEDURE [dbo].[usp_UserInsert]
  @Name NVARCHAR(50),
  @Email NVARCHAR(50),
  @Password NVARCHAR(50)
AS
BEGIN
  INSERT into dbo.[User] (Name, Email, Password)
  values (@Name, @Email, @Password)
END
