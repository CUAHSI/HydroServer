ALTER TABLE [dbo].[CensorCodeCV] ADD CONSTRAINT [CK_CensorCodeCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


