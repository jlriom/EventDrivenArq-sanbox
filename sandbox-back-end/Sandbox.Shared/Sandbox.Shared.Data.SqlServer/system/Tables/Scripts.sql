﻿CREATE TABLE [system].[Scripts]
(
	[Name] NVARCHAR(400) NOT NULL PRIMARY KEY, 
    [Date] DATETIME NOT NULL DEFAULT GetDate()
)