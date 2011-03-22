ALTER TABLE [dbo].[VariableNameCV] ADD CONSTRAINT [CK_VariableNameCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


