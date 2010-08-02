ALTER TABLE [dbo].[TopicCategoryCV] ADD CONSTRAINT [CK_TopicCategoryCV_Term] CHECK ((NOT [Term] like ((('%['+char((9)))+char((10)))+char((13)))+']%'))


