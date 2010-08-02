ALTER TABLE [dbo].[QualityControlLevels] ADD CONSTRAINT [CK_QualityControlLevels_QualityControlLevelCode] CHECK ((NOT [QualityControlLevelCode] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


