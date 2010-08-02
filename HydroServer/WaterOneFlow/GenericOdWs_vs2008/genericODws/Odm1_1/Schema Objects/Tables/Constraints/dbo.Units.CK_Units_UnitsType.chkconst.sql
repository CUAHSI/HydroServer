ALTER TABLE [dbo].[Units] ADD CONSTRAINT [CK_Units_UnitsType] CHECK ((NOT [UnitsType] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


