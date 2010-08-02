ALTER TABLE [dbo].[DataValues] WITH NOCHECK ADD
CONSTRAINT [FK_DataValues_Qualifiers] FOREIGN KEY ([QualifierID]) REFERENCES [dbo].[Qualifiers] ([QualifierID])


