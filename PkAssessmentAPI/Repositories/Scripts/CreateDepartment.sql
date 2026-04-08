IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Department')
    DROP TABLE [dbo].[Department];
 
-- =====================================================
-- CREATE DEPARTMENT TABLE
-- =====================================================
CREATE TABLE [dbo].[Department]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    
    [DepartmentCode] NVARCHAR(50) NOT NULL UNIQUE,
    [DepartmentName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    
    INDEX [IX_DepartmentCode] NONCLUSTERED ([DepartmentCode])
);
 