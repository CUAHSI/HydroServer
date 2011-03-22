ALTER TABLE [dbo].[Units] ADD CONSTRAINT [CK_Units_UnitsName] CHECK ((NOT [UnitsName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


