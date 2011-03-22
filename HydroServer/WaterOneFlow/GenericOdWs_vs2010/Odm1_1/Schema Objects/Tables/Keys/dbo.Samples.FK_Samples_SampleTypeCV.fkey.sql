ALTER TABLE [dbo].[Samples] ADD
CONSTRAINT [FK_Samples_SampleTypeCV] FOREIGN KEY ([SampleType]) REFERENCES [dbo].[SampleTypeCV] ([Term])


