ALTER TABLE [dbo].[ValueTypeCV] ADD CONSTRAINT [CK_ValueTypeCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


