ALTER TABLE [dbo].[DataValues] WITH NOCHECK ADD
CONSTRAINT [FK_DataValues_Variables] FOREIGN KEY ([VariableID]) REFERENCES [dbo].[Variables] ([VariableID])


