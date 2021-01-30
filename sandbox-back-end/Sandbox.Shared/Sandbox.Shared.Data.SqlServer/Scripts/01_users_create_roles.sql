
SET  @script = '01_users_create_roles'
if not exists (select [name] from [system].[Scripts] where [Name] = @script)
BEGIN

	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'admin', N'admin', N'ADMIN', N'4a00afd9-ad6a-4ab4-8b4f-d6c1330e2f6e')
	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'user', N'user', N'USER', N'6b3bfe5e-e6a2-448d-99d7-5e93057ced20')

	INSERT INTO [system].[Scripts]([Name]) VALUES (@script);
END
