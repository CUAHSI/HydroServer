ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_Latitude] CHECK (([Latitude]>=(-90) AND [Latitude]<=(90)))


