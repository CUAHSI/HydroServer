ALTER TABLE [dbo].[LabMethods] ADD CONSTRAINT [CK_LabMethods_LabMethodName] CHECK ((NOT [LabMethodName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


