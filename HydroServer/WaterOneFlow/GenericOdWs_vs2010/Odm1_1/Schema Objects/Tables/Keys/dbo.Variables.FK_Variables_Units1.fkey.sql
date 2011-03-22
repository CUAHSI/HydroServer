ALTER TABLE [dbo].[Variables] ADD
CONSTRAINT [FK_Variables_Units1] FOREIGN KEY ([TimeUnitsID]) REFERENCES [dbo].[Units] ([UnitsID])


