ALTER TABLE [dbo].[Groups] WITH NOCHECK ADD
CONSTRAINT [FK_Groups_DataValues] FOREIGN KEY ([ValueID]) REFERENCES [dbo].[DataValues] ([ValueID])


