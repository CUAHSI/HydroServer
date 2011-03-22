ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_City] CHECK ((NOT [City] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


