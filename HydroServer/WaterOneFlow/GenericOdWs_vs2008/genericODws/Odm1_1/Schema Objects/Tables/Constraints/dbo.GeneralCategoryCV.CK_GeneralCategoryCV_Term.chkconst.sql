ALTER TABLE [dbo].[GeneralCategoryCV] ADD CONSTRAINT [CK_GeneralCategoryCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


