ALTER TABLE [dbo].[Variables] ADD CONSTRAINT [CK_Variables_VariableCode] CHECK ((NOT [VariableCode] like '%[^-.A-Z0-9/_]%' escape '/' ))


