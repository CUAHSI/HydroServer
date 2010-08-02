ALTER TABLE [dbo].[Variables] ADD
CONSTRAINT [FK_Variables_VariableNameCV] FOREIGN KEY ([VariableName]) REFERENCES [dbo].[VariableNameCV] ([Term])


