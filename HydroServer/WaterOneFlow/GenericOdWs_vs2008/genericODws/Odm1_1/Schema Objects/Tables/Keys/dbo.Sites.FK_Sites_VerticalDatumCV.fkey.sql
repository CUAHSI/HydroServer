ALTER TABLE [dbo].[Sites] ADD
CONSTRAINT [FK_Sites_VerticalDatumCV] FOREIGN KEY ([VerticalDatum]) REFERENCES [dbo].[VerticalDatumCV] ([Term])


