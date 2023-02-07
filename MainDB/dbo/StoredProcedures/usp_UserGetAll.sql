CREATE PROCEDURE [dbo].[usp_UserGetAll]

AS
  SELECT Id, [Name], Email, Password, Role
  FROM dbo.[User]
RETURN 0
