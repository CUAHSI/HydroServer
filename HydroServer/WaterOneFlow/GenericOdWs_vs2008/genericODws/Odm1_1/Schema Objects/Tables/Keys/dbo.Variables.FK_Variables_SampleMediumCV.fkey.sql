ALTER TABLE [dbo].[Variables] ADD
CONSTRAINT [FK_Variables_SampleMediumCV] FOREIGN KEY ([SampleMedium]) REFERENCES [dbo].[SampleMediumCV] ([Term])


