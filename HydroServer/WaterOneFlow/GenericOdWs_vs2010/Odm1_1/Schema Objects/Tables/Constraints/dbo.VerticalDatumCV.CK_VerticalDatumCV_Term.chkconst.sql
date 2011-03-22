ALTER TABLE [dbo].[VerticalDatumCV] ADD CONSTRAINT [CK_VerticalDatumCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


