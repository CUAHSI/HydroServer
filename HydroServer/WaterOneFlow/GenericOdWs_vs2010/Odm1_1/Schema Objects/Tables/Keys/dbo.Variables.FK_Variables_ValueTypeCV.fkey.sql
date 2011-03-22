ALTER TABLE [dbo].[Variables] ADD
CONSTRAINT [FK_Variables_ValueTypeCV] FOREIGN KEY ([ValueType]) REFERENCES [dbo].[ValueTypeCV] ([Term])


