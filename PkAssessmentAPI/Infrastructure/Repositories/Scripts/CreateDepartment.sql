IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Department')
    DROP TABLE [dbo].[Department];
 
CREATE TABLE [dbo].[Department]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    
    [Code] NVARCHAR(50) NOT NULL UNIQUE,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    
    INDEX [IX_Code] NONCLUSTERED ([Code])
);
 