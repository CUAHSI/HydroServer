ALTER TABLE [dbo].[DataValues] WITH NOCHECK ADD
CONSTRAINT [FK_DataValues_Sources] FOREIGN KEY ([SourceID]) REFERENCES [dbo].[Sources] ([SourceID])


