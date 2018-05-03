select * from [aspnet-LmsWhinker-20180416055335].dbo.AspNetUsers
INSERT INTO [LmsWhinker].[dbo].[typeCourse]
           ([idTypeCourse]
           ,[Name]
           ,[dateCreation]
           ,[userCreation]
           ,[dateChange]
           ,[userChange])
     VALUES
           (5
           ,'Whinker Program'
           ,GETDATE()
           ,'ADMIN1'
           ,GETDATE()
           ,'ADMIN2')
GO

UPDATE [LmsWhinker].[dbo].[typeCourse] SET Name = 'Whinker Course'  where idTypeCourse = 2

ALTER TABLE [typeCourse] add CONSTRAINT TypeCourse_Name_UNIQUE  UNIQUE (Name)