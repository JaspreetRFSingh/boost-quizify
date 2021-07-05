USE [Quizzify]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DifficultyLevel](
	[DifficultyLevelId] [int] IDENTITY(101,1) NOT NULL,
	[LevelNumber] [int] NOT NULL,
	[LevelName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_DifficultyLevel] PRIMARY KEY CLUSTERED 
(
	[DifficultyLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [int] IDENTITY(1001,1) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Answer] [varchar](max) NOT NULL,
	[Options] [varchar](max) NULL,
	[DifficultyLevelId] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[QuizId] [int] IDENTITY(201,1) NOT NULL,
	[QuestionsCount] [int] NOT NULL,
	[MaxDifficulty] [int] NOT NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[QuizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Quiz] UNIQUE NONCLUSTERED 
(
	[MaxDifficulty] ASC,
	[QuestionsCount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz_Question](
	[QuizQuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuizId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
 CONSTRAINT [PK_Quiz_Question] PRIMARY KEY CLUSTERED 
(
	[QuizQuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Quiz_Question] UNIQUE NONCLUSTERED 
(
	[QuestionId] ASC,
	[QuizId] ASC,
	[QuizQuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_DifficultyLevel] FOREIGN KEY([DifficultyLevelId])
REFERENCES [dbo].[DifficultyLevel] ([DifficultyLevelId])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_DifficultyLevel]
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_DifficultyLevel] FOREIGN KEY([MaxDifficulty])
REFERENCES [dbo].[DifficultyLevel] ([DifficultyLevelId])
GO
ALTER TABLE [dbo].[Quiz] CHECK CONSTRAINT [FK_Quiz_DifficultyLevel]
GO
ALTER TABLE [dbo].[Quiz_Question]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Question_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[Quiz_Question] CHECK CONSTRAINT [FK_Quiz_Question_Question]
GO
ALTER TABLE [dbo].[Quiz_Question]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Question_Quiz] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quiz] ([QuizId])
GO
ALTER TABLE [dbo].[Quiz_Question] CHECK CONSTRAINT [FK_Quiz_Question_Quiz]
GO
