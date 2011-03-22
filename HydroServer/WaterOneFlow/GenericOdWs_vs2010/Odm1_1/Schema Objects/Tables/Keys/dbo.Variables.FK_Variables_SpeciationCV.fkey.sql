ALTER TABLE [dbo].[Variables] ADD
CONSTRAINT [FK_Variables_SpeciationCV] FOREIGN KEY ([Speciation]) REFERENCES [dbo].[SpeciationCV] ([Term])


