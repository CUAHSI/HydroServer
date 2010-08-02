ALTER TABLE [dbo].[OffsetTypes] ADD
CONSTRAINT [FK_OffsetTypes_Units] FOREIGN KEY ([OffsetUnitsID]) REFERENCES [dbo].[Units] ([UnitsID])


