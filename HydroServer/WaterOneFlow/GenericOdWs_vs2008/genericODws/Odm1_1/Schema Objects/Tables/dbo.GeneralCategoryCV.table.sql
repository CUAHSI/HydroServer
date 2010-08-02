CREATE TABLE [dbo].[GeneralCategoryCV]
(
[Term] [nvarchar] (255) NOT NULL,
[Definition] [nvarchar] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'6/14/2006 10:31:54 PM', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'6/15/2006 1:59:39 PM', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DefaultView', N'2', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderByOn', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Orientation', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'GeneralCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'GUID', N'鹰퓬⻃䤱⒑劶踏꫸', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Name', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceField', N'Term', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'SourceTable', N'GeneralCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Term'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'GUID', N'춤༑ᗍ䦳㖇綆᧏㍣', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'MS_IMESentMode', N'3', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Name', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceField', N'Definition', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'SourceTable', N'GeneralCategoryCV', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'SCHEMA', N'dbo', 'TABLE', N'GeneralCategoryCV', 'COLUMN', N'Definition'

