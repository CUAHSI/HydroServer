ALTER TABLE [dbo].[ISOMetadata] ADD
CONSTRAINT [FK_ISOMetadata_TopicCategoryCV] FOREIGN KEY ([TopicCategory]) REFERENCES [dbo].[TopicCategoryCV] ([Term])


