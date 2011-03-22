ALTER TABLE [dbo].[Sites] ADD CONSTRAINT [CK_Sites_Longitude] CHECK (([Longitude]>=(-180) AND [Longitude]<=(360)))


