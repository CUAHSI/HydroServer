ALTER TABLE [dbo].[DataValues] WITH NOCHECK ADD
CONSTRAINT [FK_DataValues_QualityControlLevels] FOREIGN KEY ([QualityControlLevelID]) REFERENCES [dbo].[QualityControlLevels] ([QualityControlLevelID])


