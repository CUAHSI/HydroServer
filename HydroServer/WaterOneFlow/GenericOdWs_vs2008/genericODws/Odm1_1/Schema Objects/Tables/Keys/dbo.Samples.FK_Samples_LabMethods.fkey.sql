ALTER TABLE [dbo].[Samples] WITH NOCHECK ADD
CONSTRAINT [FK_Samples_LabMethods] FOREIGN KEY ([LabMethodID]) REFERENCES [dbo].[LabMethods] ([LabMethodID])


