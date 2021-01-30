
SET  @script = 'init'
if not exists (select [name] from [system].[Scripts] where [Name] = @script)
BEGIN

	INSERT INTO [system].[Scripts]([Name]) VALUES (@script);
END
