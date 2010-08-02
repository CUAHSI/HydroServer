ALTER TABLE [dbo].[Variables] ADD
CONSTRAINT [FK_Variables_GeneralCategoryCV] FOREIGN KEY ([GeneralCategory]) REFERENCES [dbo].[GeneralCategoryCV] ([Term])


