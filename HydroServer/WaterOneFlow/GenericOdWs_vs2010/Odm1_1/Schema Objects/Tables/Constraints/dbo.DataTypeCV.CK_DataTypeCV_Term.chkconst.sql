ALTER TABLE [dbo].[DataTypeCV] ADD CONSTRAINT [CK_DataTypeCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


