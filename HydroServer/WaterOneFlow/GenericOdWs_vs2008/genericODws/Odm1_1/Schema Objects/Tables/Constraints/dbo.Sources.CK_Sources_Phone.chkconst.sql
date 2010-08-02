ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_Phone] CHECK ((NOT [Phone] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


