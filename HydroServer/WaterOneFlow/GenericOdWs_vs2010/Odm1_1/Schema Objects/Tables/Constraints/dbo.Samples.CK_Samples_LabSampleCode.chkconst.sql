ALTER TABLE [dbo].[Samples] ADD CONSTRAINT [CK_Samples_LabSampleCode] CHECK ((NOT [LabSampleCode] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


