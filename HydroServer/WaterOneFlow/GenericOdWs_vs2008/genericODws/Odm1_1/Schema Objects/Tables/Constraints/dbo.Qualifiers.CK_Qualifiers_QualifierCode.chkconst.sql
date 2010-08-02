ALTER TABLE [dbo].[Qualifiers] ADD CONSTRAINT [CK_Qualifiers_QualifierCode] CHECK ((NOT [QualifierCode] like (((('%['+char((9)))+char((10)))+char((13)))+char((32)))+']%'))


