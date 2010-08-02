ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_State] CHECK ((NOT [State] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


