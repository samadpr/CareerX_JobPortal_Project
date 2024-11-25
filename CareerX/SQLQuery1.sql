create database careerxDB


use careerxDB


--CREATE COMMAND FOR sYSTEM uSER

CREATE TABLE systemUser (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generates GUID values
    UserName NVARCHAR(255) NULL,                            -- Nullable
    FirstName NVARCHAR(255) NOT NULL,                       -- Required
    LastName NVARCHAR(255) NULL,                            -- Nullable
    Phone NVARCHAR(20) NOT NULL,                            -- Required
    Email NVARCHAR(255) NOT NULL,                           -- Required
    Role INT NULL                                           -- Nullable, use INT for enums
);


CREATE TABLE SignUpRequests (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),  -- Auto-generated GUID
    UserName NVARCHAR(255) NULL,                               -- Nullable string
    FirstName NVARCHAR(255) NOT NULL,                          -- Non-nullable string
    LastName NVARCHAR(255) NULL,                               -- Nullable string
    Phone NVARCHAR(50) NOT NULL,                               -- Non-nullable string for phone
    Email NVARCHAR(255) NOT NULL,                              -- Non-nullable email
    Status INT NOT NULL
);

--Authuser Table
CREATE TABLE AuthUser (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generates GUID values
    [Password] NVARCHAR(255) NULL,                            -- Nullable
                             
    [Status] INT NULL                                           -- Nullable, use INT for enums
);

--Skill
CREATE TABLE Skill (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    Name NVARCHAR(255) NOT NULL,                              -- Required
    Description NVARCHAR(MAX) NOT NULL                        -- Required
);

--Location

CREATE TABLE Location (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    Name NVARCHAR(255) NOT NULL,                              -- Required
    Description NVARCHAR(MAX) NOT NULL                        -- Required
);


CREATE TABLE Qualification (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    Name NVARCHAR(255) NOT NULL,                              -- Required
    Description NVARCHAR(MAX) NOT NULL                        -- Required
);


CREATE TABLE Industry (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    Name NVARCHAR(255) NOT NULL,                              -- Required
    Description NVARCHAR(MAX) NOT NULL                        -- Required
);


CREATE TABLE JobCategory (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    Name NVARCHAR(255) NOT NULL,                              -- Required
    Description NVARCHAR(MAX) NOT NULL                        -- Required
);


CREATE TABLE CompanyUser (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    LegalName NVARCHAR(255) NOT NULL,                        -- Required
    Summary NVARCHAR(MAX) NOT NULL,                          -- Required
    IndustryId UNIQUEIDENTIFIER NOT NULL,                    -- Foreign key for Industry
    Email NVARCHAR(255) NOT NULL,                            -- Required
    Phone BIGINT NOT NULL,                                   -- Phone number
    Address NVARCHAR(MAX) NOT NULL,                          -- Required
    Website NVARCHAR(255) NOT NULL,                          -- Required
    Location UNIQUEIDENTIFIER NOT NULL,                      -- Foreign key for Location
    CONSTRAINT FK_JobProviderCompany_Industry FOREIGN KEY (IndustryId) REFERENCES Industry(Id),
    CONSTRAINT FK_JobProviderCompany_Location FOREIGN KEY (Location) REFERENCES Location(Id)
);



CREATE TABLE JobPost (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    JobTitle NVARCHAR(255) NOT NULL,                          -- Required
    JobSummary NVARCHAR(MAX) NOT NULL,                        -- Required
    LocationId UNIQUEIDENTIFIER NOT NULL,                     -- Foreign key for Location
    CompanyId UNIQUEIDENTIFIER NOT NULL,                      -- Foreign key for Company
    CategoryId UNIQUEIDENTIFIER NOT NULL,                     -- Foreign key for JobCategory
    IndustryId UNIQUEIDENTIFIER NOT NULL,                     -- Foreign key for Industry
    PostedBy UNIQUEIDENTIFIER NOT NULL,                       -- Foreign key for PostedBy (SystemUser)
    PostedDate DATETIME NOT NULL DEFAULT GETDATE(),           -- Default to current date
    QualificationId UNIQUEIDENTIFIER NOT NULL,                -- Foreign key for Qualification
    SkillId UNIQUEIDENTIFIER NOT NULL,                        -- Foreign key for Skill
    CONSTRAINT FK_JobPost_Location FOREIGN KEY (LocationId) REFERENCES Location(Id),
    CONSTRAINT FK_JobPost_Company FOREIGN KEY (CompanyId) REFERENCES CompanyUser(Id),
    CONSTRAINT FK_JobPost_JobCategory FOREIGN KEY (CategoryId) REFERENCES JobCategory(Id),
    CONSTRAINT FK_JobPost_Industry FOREIGN KEY (IndustryId) REFERENCES Industry(Id),
    CONSTRAINT FK_JobPost_PostedBy FOREIGN KEY (PostedBy) REFERENCES SystemUser(Id),
    CONSTRAINT FK_JobPost_Qualification FOREIGN KEY (QualificationId) REFERENCES Qualification(Id),
    CONSTRAINT FK_JobPost_Skill FOREIGN KEY (SkillId) REFERENCES Skill(Id)
);

EXEC sp_rename 'CompanyUser', 'CompanyAdmin';
ALTER TABLE JobPost DROP CONSTRAINT FK_JobPost_Company;

-- Add a new foreign key constraint pointing to CompanyAdmin
ALTER TABLE JobPost
ADD CONSTRAINT FK_JobPost_Company FOREIGN KEY (CompanyId) REFERENCES CompanyAdmin(Id);


select * from CompanyAdmin
CREATE TABLE JobResponsibility (--ADDED WHEN POST A JOB
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    Name NVARCHAR(255) NULL,                                 -- Nullable Name
    Description NVARCHAR(MAX) NULL                           -- Nullable Description
);
 

CREATE TABLE AppliedJobs (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),  -- Auto-generated GUID
    JobPostId UNIQUEIDENTIFIER NOT NULL,                      -- Foreign key for JobPost
    UserId UNIQUEIDENTIFIER NOT NULL,                         -- Foreign key for SystemUser (Job Seeker)
    AppliedDate DATETIME NOT NULL DEFAULT GETDATE(),          -- Date when the job was applied for
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',           -- Application status (e.g., Pending, Accepted, Rejected)
    CONSTRAINT FK_AppliedJobs_JobPost FOREIGN KEY (JobPostId) REFERENCES JobPost(Id),
    CONSTRAINT FK_AppliedJobs_User FOREIGN KEY (UserId) REFERENCES SystemUser(Id)
);


CREATE TABLE SavedJobs (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),  -- Auto-generated GUID
    JobPostId UNIQUEIDENTIFIER NOT NULL,                      -- Foreign key for JobPost
    UserId UNIQUEIDENTIFIER NOT NULL,                         -- Foreign key for SystemUser (Job Seeker)
    SavedDate DATETIME NOT NULL DEFAULT GETDATE(),            -- Date when the job was saved
    CONSTRAINT FK_SavedJobs_JobPost FOREIGN KEY (JobPostId) REFERENCES JobPost(Id),
    CONSTRAINT FK_SavedJobs_User FOREIGN KEY (UserId) REFERENCES SystemUser(Id)
);


EXEC sp_rename 'SavedJobs.JobPostId', 'Job', 'COLUMN';
EXEC sp_rename 'SavedJobs.UserId', 'SavedBy', 'COLUMN';
EXEC sp_rename 'SavedJobs.SavedDate', 'DateSaved', 'COLUMN';

-- Step 2: Drop the old foreign key constraints
ALTER TABLE SavedJobs DROP CONSTRAINT FK_SavedJobs_JobPost;
ALTER TABLE SavedJobs DROP CONSTRAINT FK_SavedJobs_User;

-- Step 3: Add new foreign key constraints with the updated column names
ALTER TABLE SavedJobs
ADD CONSTRAINT FK_SavedJobs_Job FOREIGN KEY (Job) REFERENCES JobPost(Id);

ALTER TABLE SavedJobs
ADD CONSTRAINT FK_SavedJobs_JobSeeker FOREIGN KEY (SavedBy) REFERENCES JobSeeker(Id);

select  * from SavedJobs



SELECT TABLE_SCHEMA, TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_SCHEMA, TABLE_NAME;

CREATE TABLE HIRINGMANAGER(
	ID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	Email	varchar(max) not null,
	[Name] varchar(max) ,
	


)
drop table JobSeekerProfile

CREATE TABLE JobSeeker (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    UserName NVARCHAR(255) NULL,                             -- Nullable
    FirstName NVARCHAR(255) NOT NULL,                        -- Required
    LastName NVARCHAR(255) NULL,                             -- Nullable
    Phone NVARCHAR(20) NOT NULL,                             -- Required
    Email NVARCHAR(255) NOT NULL,                            -- Required
    Image VARBINARY(MAX) NULL,                               -- Optional Image as byte array
    Role INT NOT NULL,                                       -- Role field (use for enums)
    CONSTRAINT UC_Email UNIQUE (Email)                      -- Ensure unique email
);
CREATE TABLE JobSeekerProfile (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), -- Auto-generated GUID
    JobSeekerId UNIQUEIDENTIFIER NOT NULL,                    -- Foreign Key to JobSeeker
    ProfileName NVARCHAR(255) NULL,                           -- Optional Profile Name
    ProfileSummary NVARCHAR(MAX) NULL,                        -- Optional Profile Summary
    CONSTRAINT FK_JobSeekerProfile_JobSeeker FOREIGN KEY (JobSeekerId) REFERENCES JobSeeker(Id)
);
CREATE TABLE JobSeekerProfileSkill (
    JobSeekerProfileId UNIQUEIDENTIFIER NOT NULL,             -- Foreign Key to JobSeekerProfile
    SkillId UNIQUEIDENTIFIER NOT NULL,                        -- Foreign Key to Skill
    PRIMARY KEY (JobSeekerProfileId, SkillId),                -- Composite primary key
    CONSTRAINT FK_JobSeekerProfileSkill_JobSeekerProfile FOREIGN KEY (JobSeekerProfileId) REFERENCES JobSeekerProfile(Id),
    CONSTRAINT FK_JobSeekerProfileSkill_Skill FOREIGN KEY (SkillId) REFERENCES Skill(Id)
);


CREATE TABLE Resume (--- if we need  to upadate resume then better way to store resume in seperete table

    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    JobSeekerProfileId UNIQUEIDENTIFIER NOT NULL,           -- Foreign Key to JobSeekerProfile
    ResumeFile VARBINARY(MAX) NOT NULL,                     -- Storing the resume file (e.g., PDF or DOCX)
    FileName NVARCHAR(255) NOT NULL,                        -- Name of the file
    FileType NVARCHAR(50) NOT NULL,                         -- File type (e.g., PDF, DOCX)
    DateUploaded DATETIME NOT NULL DEFAULT GETDATE(),      -- When the resume was uploaded
    CONSTRAINT FK_Resume_JobSeekerProfile FOREIGN KEY (JobSeekerProfileId) REFERENCES JobSeekerProfile(Id)
);

CREATE TABLE WorkExperiences (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),  -- Auto-generated GUID
    JobSeekerProfileId UNIQUEIDENTIFIER NOT NULL,              -- Foreign key for JobSeekerProfile
    JobTitle NVARCHAR(255) NOT NULL,                            -- Job title (non-nullable)
    CompanyName NVARCHAR(255) NOT NULL,                         -- Company name (non-nullable)
    Summary NVARCHAR(MAX) NOT NULL,                             -- Summary (non-nullable)
    ServiceStart DATETIME NOT NULL,                             -- Service start date (non-nullable)
    ServiceEnd DATETIME NOT NULL,                               -- Service end date (non-nullable)
    CONSTRAINT FK_WorkExperience_JobSeekerProfile FOREIGN KEY (JobSeekerProfileId) REFERENCES JobSeekerProfile(Id)  -- Foreign key reference to JobSeekerProfile
);
CREATE TABLE JobApplication (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    JobPost_id UNIQUEIDENTIFIER NOT NULL,
    Applicant UNIQUEIDENTIFIER NOT NULL,
    ResumeId UNIQUEIDENTIFIER NOT NULL,                      -- Foreign Key to Resume
    CoverLetter NVARCHAR(MAX) NULL,
    Datesubmitted DATETIME NOT NULL DEFAULT GETDATE(),
    Status INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_JobApplication_JobPost FOREIGN KEY (JobPost_id) REFERENCES JobPost(Id),
    CONSTRAINT FK_JobApplication_Applicant FOREIGN KEY (Applicant) REFERENCES SystemUser(Id),
    CONSTRAINT FK_JobApplication_Resume FOREIGN KEY (ResumeId) REFERENCES Resume(Id)
);