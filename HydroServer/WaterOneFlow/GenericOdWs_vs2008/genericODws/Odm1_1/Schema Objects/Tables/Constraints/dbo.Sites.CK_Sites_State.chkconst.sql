ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_State] CHECK ((NOT [State] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


