ALTER TABLE [dbo].[SampleTypeCV] ADD CONSTRAINT [CK_SampleTypeCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


