ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_SiteCode] CHECK ((NOT [SiteCode] like '%[^-.A-Z0-9/_]%' escape '/' ))


