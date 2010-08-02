ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_Email] CHECK ((NOT [Email] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


