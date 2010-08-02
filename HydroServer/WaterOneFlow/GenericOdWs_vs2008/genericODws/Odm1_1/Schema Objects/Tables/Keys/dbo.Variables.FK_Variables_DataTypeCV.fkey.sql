ALTER TABLE [dbo].[Variables] ADD
CONSTRAINT [FK_Variables_DataTypeCV] FOREIGN KEY ([DataType]) REFERENCES [dbo].[DataTypeCV] ([Term])


