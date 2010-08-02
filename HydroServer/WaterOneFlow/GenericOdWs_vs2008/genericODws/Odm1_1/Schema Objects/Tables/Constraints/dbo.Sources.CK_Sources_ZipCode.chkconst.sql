ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_ZipCode] CHECK ((NOT [ZipCode] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


