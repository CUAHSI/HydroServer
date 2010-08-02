ALTER TABLE [dbo].[DataValues] WITH NOCHECK ADD
CONSTRAINT [FK_DataValues_Samples] FOREIGN KEY ([SampleID]) REFERENCES [dbo].[Samples] ([SampleID])


