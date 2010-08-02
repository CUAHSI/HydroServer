ALTER TABLE [dbo].[QualityControlLevels] ADD CONSTRAINT [CK_QualityControlLevels_Definition] CHECK ((NOT [Definition] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


