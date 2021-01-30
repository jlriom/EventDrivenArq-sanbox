
SET  @script  = '021_users_create_users_sample'
if not exists (select [name] from [system].[Scripts] where [Name] = @script)
BEGIN

	INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'4403C8C7-BE0E-415B-876F-476249C2B987', N'user02', N'USER01', N'user02@sandbox.com', N'USER02@SANDBOX.COM', 1, N'AQAAAAEAACcQAAAAEH/6oUkVomBizP9LXbLKI7lUX78dfxm62IYOkFnUXSoJmhKx2sFv7ynrwwSlQlvOqw==', N'bb20475d-8242-4967-9aeb-eaf8a61f729c', N'7c083dda-f40c-4074-b222-3edcbccd523a', NULL, 0, 0, NULL, 0, 0, N'First Name 01', N'Last Name 01', N'b33735fd-55e5-49aa-9dc2-e92f379f3a7e', CAST(N'2020-10-11T17:40:53.933' AS DateTime), N'b33735fd-55e5-49aa-9dc2-e92f379f3a7e', CAST(N'2020-10-11T17:40:53.933' AS DateTime))
	INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'663753CC-5492-4856-80D9-EB41B3BEE8AB', N'user01', N'USER01', N'user01@sandbox.com', N'USER01@SANDBOX.COM', 1, N'AQAAAAEAACcQAAAAEH/6oUkVomBizP9LXbLKI7lUX78dfxm62IYOkFnUXSoJmhKx2sFv7ynrwwSlQlvOqw==', N'bb20475d-8242-4967-9aeb-eaf8a61f729c', N'7c083dda-f40c-4074-b222-3edcbccd523a', NULL, 0, 0, NULL, 0, 0, N'First Name 02', N'Last Name 02', N'b33735fd-55e5-49aa-9dc2-e92f379f3a7e', CAST(N'2020-10-11T17:40:53.933' AS DateTime), N'b33735fd-55e5-49aa-9dc2-e92f379f3a7e', CAST(N'2020-10-11T17:40:53.933' AS DateTime))

	SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 
	INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, N'663753CC-5492-4856-80D9-EB41B3BEE8AB', N'role', N'user')
	INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (3, N'4403C8C7-BE0E-415B-876F-476249C2B987', N'role', N'user')
	SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF

	INSERT INTO [system].[Scripts]([Name]) VALUES (@script);
END
