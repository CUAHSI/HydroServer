ALTER TABLE [dbo].[Sources] ADD
CONSTRAINT [FK_Sources_ISOMetaData] FOREIGN KEY ([MetadataID]) REFERENCES [dbo].[ISOMetadata] ([MetadataID])


