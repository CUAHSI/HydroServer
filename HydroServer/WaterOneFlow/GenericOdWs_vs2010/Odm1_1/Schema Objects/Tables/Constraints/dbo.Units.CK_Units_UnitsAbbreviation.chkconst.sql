ALTER TABLE [dbo].[Units] ADD CONSTRAINT [CK_Units_UnitsAbbreviation] CHECK ((NOT [UnitsAbbreviation] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


