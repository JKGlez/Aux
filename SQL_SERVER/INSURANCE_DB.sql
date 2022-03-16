CREATE DATABASE INSURANCE_DB

USE INSURANCE_DB

--TABLE FOR USERS--
CREATE TABLE tbl_users (
UserId BIGINT IDENTITY(0,1) PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
)

SELECT * FROM tbl_users
--DROP TABLE tbl_users


--TABLE FOR TERMS--
CREATE TABLE tbl_refterms (
TermId BIGINT IDENTITY(0,1) PRIMARY KEY,
TermDescription VARCHAR(MAX) DEFAULT '',
TermName VARCHAR(100) DEFAULT '',
)
SELECT * FROM tbl_refterms
--DROP TABLE tbl_refterms


--TABLE FOR PLANS--
CREATE TABLE tbl_plans (
--Main Data--	
PlanId BIGINT IDENTITY(0,1) PRIMARY KEY,
PlanCode VARCHAR(50) DEFAULT '',
PlanName VARCHAR(200) DEFAULT '',
EffectiveFromDate DATETIME NOT NULL,
EffectiveTillDate DATETIME NOT NULL,
-- Control Data --
CreatedDate DATETIME NOT NULL, --Predefined fileds
ModifiedDate DATETIME NOT NULL,--Predefined fileds
CreatedUser BIGINT NOT NULL, --FK
ModifiedUser BIGINT NOT NULL, --FK
--DEFINING FOREIGN KEYS
CONSTRAINT FK_tbl_plans_tbl_users_Created FOREIGN KEY (CreatedUser) REFERENCES tbl_users(UserId),
CONSTRAINT FK_tbl_plans_tbl_users_Modified FOREIGN KEY (ModifiedUser) REFERENCES tbl_users(UserId),
)
SELECT * FROM tbl_plans
--DROP TABLE tbl_plans


--TABLE FOR PLANSDETAILS--
CREATE TABLE tbl_planDetails (
--Main Data--	
PlanDetailsId BIGINT IDENTITY(0,1) PRIMARY KEY,
	--FK tbl_plaDetails_tbl_plans
PlanId BIGINT NOT NULL, 
CONSTRAINT FK_tbl_planDetails_tbl_plans FOREIGN KEY (PlanId) REFERENCES tbl_plans(PlanId),
	--FK tbl_plaDetails_tbl_terms
TermId BIGINT NOT NULL,
CONSTRAINT FK_tbl_planDetails_tbl_terms FOREIGN KEY (TermId) REFERENCES tbl_refterms(TermId),
TermValue VARCHAR(MAX) DEFAULT '',
-- Control Data --
CreatedDate DATETIME NOT NULL, --Predefined fileds
ModifiedDate DATETIME NOT NULL,--Predefined fileds
CreatedUser BIGINT NOT NULL, --FK
ModifiedUser BIGINT NOT NULL, --FK
-- DEFINING FOREIGN KEYS --
CONSTRAINT FK_tbl_planDetails_tbl_users_Created FOREIGN KEY (CreatedUser) REFERENCES tbl_users(UserId),
CONSTRAINT FK_tbl_planDetails_tbl_users_Modified FOREIGN KEY (ModifiedUser) REFERENCES tbl_users(UserId),
)
SELECT * FROM tbl_planDetails	
--DROP TABLE tbl_planDetails

--DROP DATABASE INSURANCE_DB	


