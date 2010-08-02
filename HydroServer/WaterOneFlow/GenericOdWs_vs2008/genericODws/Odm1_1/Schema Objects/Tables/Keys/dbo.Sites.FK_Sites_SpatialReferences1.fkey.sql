ALTER TABLE [dbo].[Sites] ADD
CONSTRAINT [FK_Sites_SpatialReferences1] FOREIGN KEY ([LocalProjectionID]) REFERENCES [dbo].[SpatialReferences] ([SpatialReferenceID])


