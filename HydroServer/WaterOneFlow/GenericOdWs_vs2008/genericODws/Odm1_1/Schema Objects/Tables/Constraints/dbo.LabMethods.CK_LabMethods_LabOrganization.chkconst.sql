ALTER TABLE [dbo].[LabMethods] ADD CONSTRAINT [CK_LabMethods_LabOrganization] CHECK ((NOT [LabOrganization] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


