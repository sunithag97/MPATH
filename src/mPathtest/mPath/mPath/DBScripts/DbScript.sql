

CREATE DATABASE PatientManagementDB;
GO

-- Table for Patient
CREATE TABLE Patient (
    Id INT PRIMARY KEY IDENTITY(1,1),    -- Auto-incrementing primary key
    Name NVARCHAR(255) NOT NULL,         -- Patient's name
    DateOfBirth NVARCHAR(50),            -- Date of birth (can later use DATE type if desired)
    Gender NVARCHAR(50)                  -- Patient's gender
);
GO


-- Table for Recommendation
CREATE TABLE Recommendation (
    Id INT PRIMARY KEY IDENTITY(1,1),    -- Auto-incrementing primary key
    PatientId INT NOT NULL,              -- Foreign key referencing Patient
    Type NVARCHAR(2000),    -- Text
	Description NVARCHAR(2000), -- Description
	Completed bit, -- Completed
    CreatedDate DATETIME DEFAULT GETDATE(), -- Timestamp for recommendation creation

    FOREIGN KEY (PatientId) REFERENCES Patient(Id) ON DELETE CASCADE
);
GO

--Table for RecommendationTypes
CREATE TABLE RecommendationTypes (
    Id INT PRIMARY KEY IDENTITY(1,1),    -- Auto-incrementing primary key
    Type NVARCHAR(2000),    -- Text
	Description NVARCHAR(2000), -- Description
    CreatedDate DATETIME DEFAULT GETDATE(), -- Timestamp for recommendation creation
);
GO

-- sample data
USE [PatientManagementDB]
GO

INSERT INTO [dbo].[RecommendationTypes]
           ([Type]
           ,[Description]
           ,[CreatedDate])
     VALUES
           ('Allery', 'Skin Allergy', CURRENT_TIMESTAMP),
           ('Screening', 'Drug screening', CURRENT_TIMESTAMP),
		   ('Flu Shot', 'This year flue', CURRENT_TIMESTAMP)
GO

CREATE TABLE AuditLog (
    Id INT PRIMARY KEY IDENTITY(1,1),    -- Auto-incrementing primary key
   PatientId INT NOT NULL,   
   Action NVARCHAR(2000),    -- Action
	Details NVARCHAR(2000), -- Details 
    CreatedDate DATETIME DEFAULT GETDATE(), -- Timestamp for recommendation creation
);
GO

-- Uncomment and run the following command to scaffold the database models

-- Scaffold-DbContext "Server=localhost;Database=PatientManagementDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModels -force


