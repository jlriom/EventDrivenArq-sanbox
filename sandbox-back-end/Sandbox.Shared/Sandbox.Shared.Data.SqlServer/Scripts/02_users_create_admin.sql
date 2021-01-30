
SET  @script =  '02_users_create_admin'
if not exists (select [name] from [system].[Scripts] where [Name] = @script)
BEGIN


	INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], 
		[EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], 
		[PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], 
		[FirstName], [LastName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) 
	VALUES (N'b33735fd-55e5-49aa-9dc2-e92f379f3a7e', N'admin', N'ADMIN', 
		N'admin@sandbox.com', N'ADMIN@SANDBOX.COM', 1, 
		N'AQAAAAEAACcQAAAAEH/6oUkVomBizP9LXbLKI7lUX78dfxm62IYOkFnUXSoJmhKx2sFv7ynrwwSlQlvOqw==', 
		N'bb20475d-8242-4967-9aeb-eaf8a61f729c', N'7c083dda-f40c-4074-b222-3edcbccd523a', 
		NULL, 0, 0, NULL, 0, 0, N'admin', N'admin', N'b33735fd-55e5-49aa-9dc2-e92f379f3a7e', 
		CAST(N'2020-10-11T17:40:53.933' AS DateTime), N'b33735fd-55e5-49aa-9dc2-e92f379f3a7e', CAST(N'2020-10-11T17:40:53.933' AS DateTime))

	SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 
	INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'b33735fd-55e5-49aa-9dc2-e92f379f3a7e', N'role', N'admin')
	SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF


	INSERT INTO [system].[Scripts]([Name]) VALUES (@script);
END
