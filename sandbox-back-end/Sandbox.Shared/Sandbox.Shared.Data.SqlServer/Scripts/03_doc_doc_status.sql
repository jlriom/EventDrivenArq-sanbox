
SET  @script =  '03_doc_doc_status'
if not exists (select [name] from [system].[Scripts] where [Name] = @script)
BEGIN
	INSERT [doc].[DocumentStatus] ([Id], [Name]) VALUES (1, N'Draft')
	INSERT [doc].[DocumentStatus] ([Id], [Name]) VALUES (2, N'Published')

	INSERT INTO [system].[Scripts]([Name]) VALUES (@script);
END
