ALTER TABLE [dbo].[Sources] ADD CONSTRAINT [CK_Sources_ContactName] CHECK ((NOT [ContactName] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


