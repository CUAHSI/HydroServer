ALTER TABLE [dbo].[DataValues] WITH NOCHECK ADD
CONSTRAINT [FK_DataValues_OffsetTypes] FOREIGN KEY ([OffsetTypeID]) REFERENCES [dbo].[OffsetTypes] ([OffsetTypeID])


