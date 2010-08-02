ALTER TABLE [dbo].[DerivedFrom] WITH NOCHECK ADD
CONSTRAINT [FK_DerivedFrom_DataValues] FOREIGN KEY ([ValueID]) REFERENCES [dbo].[DataValues] ([ValueID])


