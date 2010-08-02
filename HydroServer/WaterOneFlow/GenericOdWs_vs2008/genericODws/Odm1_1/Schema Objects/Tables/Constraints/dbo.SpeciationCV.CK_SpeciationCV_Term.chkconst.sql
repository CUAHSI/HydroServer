ALTER TABLE [dbo].[SpeciationCV] ADD CONSTRAINT [CK_SpeciationCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


