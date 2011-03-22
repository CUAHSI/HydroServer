ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_Organization] CHECK ((NOT [Organization] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


