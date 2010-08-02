ALTER TABLE [dbo].[Groups] ADD
CONSTRAINT [FK_Groups_GroupDescriptions] FOREIGN KEY ([GroupID]) REFERENCES [dbo].[GroupDescriptions] ([GroupID])


