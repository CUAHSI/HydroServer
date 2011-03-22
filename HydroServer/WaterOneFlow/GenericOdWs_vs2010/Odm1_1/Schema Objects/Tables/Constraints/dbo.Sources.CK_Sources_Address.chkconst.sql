ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_Address] CHECK ((NOT [Address] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


