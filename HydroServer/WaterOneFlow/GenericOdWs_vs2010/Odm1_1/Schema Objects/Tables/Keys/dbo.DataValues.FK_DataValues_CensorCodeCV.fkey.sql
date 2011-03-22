ALTER TABLE [dbo].[DataValues] ADD
CONSTRAINT [FK_DataValues_CensorCodeCV] FOREIGN KEY ([CensorCode]) REFERENCES [dbo].[CensorCodeCV] ([Term])


