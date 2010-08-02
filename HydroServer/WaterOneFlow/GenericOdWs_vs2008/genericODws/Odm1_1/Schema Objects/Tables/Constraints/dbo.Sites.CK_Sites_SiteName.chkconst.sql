ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_SiteName] CHECK ((NOT [SiteName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


