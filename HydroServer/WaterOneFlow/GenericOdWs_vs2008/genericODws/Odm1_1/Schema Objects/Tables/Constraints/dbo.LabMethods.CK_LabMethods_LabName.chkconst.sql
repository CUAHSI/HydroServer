ALTER TABLE [dbo].[LabMethods] ADD CONSTRAINT [CK_LabMethods_LabName] CHECK ((NOT [LabName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


