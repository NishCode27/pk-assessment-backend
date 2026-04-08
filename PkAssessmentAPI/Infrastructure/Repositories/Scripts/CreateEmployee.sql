IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Department')
    DROP TABLE [dbo].[Employee];

    CREATE TABLE [dbo].[Employee]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(100) NOT NULL UNIQUE,
    [DateOfBirth] DATE NOT NULL,
    [Age] AS DATEDIFF(YEAR, [DateOfBirth], GETDATE()) - 
              CASE 
                  WHEN MONTH([DateOfBirth]) > MONTH(GETDATE()) 
                       OR (MONTH([DateOfBirth]) = MONTH(GETDATE()) 
                           AND DAY([DateOfBirth]) > DAY(GETDATE())) 
                  THEN 1 
                  ELSE 0 
              END,
    [Salary] DECIMAL(12,2) NOT NULL,
    [DepartmentId] INT NOT NULL,
    [PhoneNumber] NVARCHAR(20) NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    
    CONSTRAINT [FK_Employee_Department] 
        FOREIGN KEY ([DepartmentId]) 
        REFERENCES [dbo].[Department]([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    
    CONSTRAINT [CK_Employee_DOB] 
        CHECK ([DateOfBirth] <= CAST(GETDATE() AS DATE)),
    
    INDEX [IX_Employee_DepartmentId] NONCLUSTERED ([DepartmentId]),
    INDEX [IX_Employee_EmailAddress] NONCLUSTERED ([EmailAddress]),
    INDEX [IX_Employee_LastName] NONCLUSTERED ([LastName]),
    INDEX [IX_Employee_FirstName] NONCLUSTERED ([FirstName])
);