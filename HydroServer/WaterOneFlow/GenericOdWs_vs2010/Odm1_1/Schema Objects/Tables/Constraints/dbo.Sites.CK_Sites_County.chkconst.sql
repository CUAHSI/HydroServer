ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_County] CHECK ((NOT [County] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


