ALTER TABLE [dbo].[Variables] WITH NOCHECK ADD
CONSTRAINT [FK_Variables_Units] FOREIGN KEY ([VariableUnitsID]) REFERENCES [dbo].[Units] ([UnitsID]) ON UPDATE CASCADE


