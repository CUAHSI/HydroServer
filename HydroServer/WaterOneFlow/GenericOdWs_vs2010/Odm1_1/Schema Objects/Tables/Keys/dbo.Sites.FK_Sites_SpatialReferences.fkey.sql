ALTER TABLE [dbo].[Sites] ADD
CONSTRAINT [FK_Sites_SpatialReferences] FOREIGN KEY ([LatLongDatumID]) REFERENCES [dbo].[SpatialReferences] ([SpatialReferenceID])


