ALTER TABLE [dbo].[Categories] WITH NOCHECK ADD
CONSTRAINT [FK_Categories_Variables] FOREIGN KEY ([VariableID]) REFERENCES [dbo].[Variables] ([VariableID])


