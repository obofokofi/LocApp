
USE master
go
CREATE DATABASE LocManDb
go
USE LocManDb
go
/* 
 * TABLE: District 
 */

CREATE TABLE District(
    DistrictID                int              IDENTITY(1,1),
    DistrictName              nvarchar(300)    NOT NULL,
    DistrictPopulation        int              NOT NULL,
    DistrictDigitalAddress    nvarchar(25)     NULL,
    DistrictIncorporatedOn    date             NOT NULL,
    DistrictCreatedOn         date             NOT NULL,
    DistrictUpdatedOn         date             NULL,
    DistrictIsActive          bit              NOT NULL,
    RegionID                  int              NULL,
    DistrictCreatedBy         int              NOT NULL,
    DistrictUpdatedBy         int              NULL,
    CONSTRAINT PK3 PRIMARY KEY NONCLUSTERED (DistrictID)
)
go

/* 
 * TABLE: Region 
 */

CREATE TABLE Region(
    RegionID                int              IDENTITY(1,1),
    RegionName              nvarchar(300)    NOT NULL,
    RegionPopulation        int              NULL,
    RegionDigitalAddress    nvarchar(25)     NULL,
    RegionIncorporatedOn    date             NOT NULL,
    RegionIsActive          bit              NOT NULL,
    RegionCreatedOn         date             NOT NULL,
    RegionUpdatedOn         date             NULL,
    RegionUpdatedBy         int              NULL,
    RegionCreatedBy         int              NOT NULL,
    CONSTRAINT PK2 PRIMARY KEY NONCLUSTERED (RegionID)
)
go


/* 
 * TABLE: UserInfo 
 */

CREATE TABLE UserInfo(
    UserInfoID    int             IDENTITY(1,1),
    FirstName     nvarchar(50)    NOT NULL,
    LastName      nvarchar(50)    NOT NULL,
    Username      nvarchar(20)    NOT NULL,
    IsActive      bit             NULL,
    UpdatedBy     int             NULL,
    UpdatedOn     date            NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (UserInfoID)
)
go


/* 
 * TABLE: District 
 */

ALTER TABLE District ADD CONSTRAINT RefRegion1 
    FOREIGN KEY (RegionID)
    REFERENCES Region(RegionID)
go

ALTER TABLE District ADD CONSTRAINT RefUserInfo4 
    FOREIGN KEY (DistrictCreatedBy)
    REFERENCES UserInfo(UserInfoID)
go

ALTER TABLE District ADD CONSTRAINT RefUserInfo6 
    FOREIGN KEY (DistrictUpdatedBy)
    REFERENCES UserInfo(UserInfoID)
go


/* 
 * TABLE: Region 
 */

ALTER TABLE Region ADD CONSTRAINT RefUserInfo5 
    FOREIGN KEY (RegionCreatedBy)
    REFERENCES UserInfo(UserInfoID)
go

ALTER TABLE Region ADD CONSTRAINT RefUserInfo7 
    FOREIGN KEY (RegionUpdatedBy)
    REFERENCES UserInfo(UserInfoID)
go


/* 
 * TABLE: UserInfo 
 */

ALTER TABLE UserInfo ADD CONSTRAINT RefUserInfo3 
    FOREIGN KEY (UpdatedBy)
    REFERENCES UserInfo(UserInfoID)
go


