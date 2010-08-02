ALTER TABLE [dbo].[SampleMediumCV] ADD CONSTRAINT [CK_SampleMediumCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


