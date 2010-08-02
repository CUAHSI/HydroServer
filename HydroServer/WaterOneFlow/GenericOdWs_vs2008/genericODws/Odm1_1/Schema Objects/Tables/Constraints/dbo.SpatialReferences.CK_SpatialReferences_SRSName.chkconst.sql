ALTER TABLE [dbo].[SpatialReferences] ADD CONSTRAINT [CK_SpatialReferences_SRSName] CHECK ((NOT [SRSName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


