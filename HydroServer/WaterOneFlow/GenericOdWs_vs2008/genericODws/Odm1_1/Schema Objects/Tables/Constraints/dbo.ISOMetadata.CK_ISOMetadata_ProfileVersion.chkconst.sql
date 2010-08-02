ALTER TABLE [dbo].[ISOMetadata] ADD CONSTRAINT [CK_ISOMetadata_ProfileVersion] CHECK ((NOT [ProfileVersion] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


