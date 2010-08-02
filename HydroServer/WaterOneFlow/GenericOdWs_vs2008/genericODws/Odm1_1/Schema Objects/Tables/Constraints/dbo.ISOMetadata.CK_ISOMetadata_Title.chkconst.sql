ALTER TABLE [dbo].[ISOMetadata] ADD CONSTRAINT [CK_ISOMetadata_Title] CHECK ((NOT [Title] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


