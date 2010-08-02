ALTER TABLE [dbo].[DataValues] WITH NOCHECK ADD
CONSTRAINT [FK_DataValues_Methods] FOREIGN KEY ([MethodID]) REFERENCES [dbo].[Methods] ([MethodID])


