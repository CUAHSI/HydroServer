ALTER TABLE [dbo].[ODMVersion] ADD CONSTRAINT [CK_ODMVersion_VersionNumber] CHECK ((NOT [VersionNumber] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


