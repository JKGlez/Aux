USE INSURANCE_DB


-- INSERT IN REF TERMS
INSERT INTO tbl_refterms (TermName,TermDescription) values('Actuary','An actuary is a business professional who deals with the financial impact of risk and uncertainty');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Annuity','An annuity is a series of payments made at fixed intervals of time. Annuities are primarily used as a means of securing a steady cash flow for an individual during their retirement years.');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Claim','An insurance claim is the actual application for benefits provided by an insurance company. It is a request for payment of the contractual benefits by the insurer that is made by the insured or the beneficiary.');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Coverage','It is the amount of liability covered for an individual by insurance services. Living and death benefits are listed in life insurance.');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Death Benefit','It is the amount on a life insurance policy that is payable to the beneficiary when the recipient passes away.');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Deductible','It is the amount that the insured pays before the insurance company begins to pay.');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Exclusion','It refers to conditions that are not covered by the general insurance contract.');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Lapse','It is the termination of a policy upon the policy owners failure to pay the premium within the grace period.');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Peril','It is a specific cause of loss covered by an insurance policy, such as a fire, windstorm, flood, or theft.');
INSERT INTO tbl_refterms (TermName,TermDescription) values('Renewal','It is a specific cause of loss covered by an insurance policy, such as a fire, windstorm, flood, or theft.');

-- INSERT IN USERS
INSERT INTO tbl_users ([Name]) values('Alan Barlandas');
INSERT INTO tbl_users ([Name]) values('Juan Gonzalez');
INSERT INTO tbl_users ([Name]) values('Luis Luna');
INSERT INTO tbl_users ([Name]) values('Kiran Chandra');
INSERT INTO tbl_users ([Name]) values('Vijay');

-- INSERT INTO PLAN TABLE
INSERT INTO tbl_plans (PlanCode,PlanName,EffectiveFromDate,EffectiveTillDate,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values('A01','Policy_Car','2022-03-10','2023-03-10','2022-02-24','2022-02-24',1,1);
INSERT INTO tbl_plans (PlanCode,PlanName,EffectiveFromDate,EffectiveTillDate,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values('A02','Policy_AllCounts','2022-03-10','2026-03-10','2022-01-10','2022-02-24',2,2);
INSERT INTO tbl_plans (PlanCode,PlanName,EffectiveFromDate,EffectiveTillDate,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values('A03','Policy_LifeInsurance','2022-03-10','2030-01-01','2021-02-02','2021-06-10',2,2);
INSERT INTO tbl_plans (PlanCode,PlanName,EffectiveFromDate,EffectiveTillDate,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values('A04','Policy_Hair','2022-03-10','2025-10-10','2022-01-01','2021-01-01',2,2);
INSERT INTO tbl_plans (PlanCode,PlanName,EffectiveFromDate,EffectiveTillDate,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values('A04','Policy_Hair','2022-03-10','2025-10-10','2022-01-01','2021-01-01',3,3);
INSERT INTO tbl_plans (PlanCode,PlanName,EffectiveFromDate,EffectiveTillDate,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values('A05','Policy_NaturalDisaster','2023-10-10','2025-10-10','2022-01-01','2021-01-01',3,3);
INSERT INTO tbl_plans (PlanCode,PlanName,EffectiveFromDate,EffectiveTillDate,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values('A06','Policy_Abduction','2022-05-05','2025-10-10','2022-02-02','2022-02-10',1,1);

-- INSERT INTO PLAN DETAILS
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(1,1,'This is my first term value','2022-02-24','2022-02-24',1,1);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(1,2,'This is my second term value','2022-02-20','2022-02-24',1,1);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(1,3,'This is my third term value','2022-01-04','2022-01-24',1,1);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(2,5,'This is my fourth term value','2021-01-01','2021-01-01',2,2);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(2,4,'This is my fifth term value','2021-01-01','2021-01-01',2,2);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(3,2,'This is my sixth term value','2022-10-02','2022-10-02',3,3);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(3,4,'This is my seventh term value','2020-10-02','2020-10-02',4,4);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(4,1,'This is my eighth term value','2021-05-06','2021-10-10',4,4);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(3,4,'This is my nineth term value','2022-01-01','2022-02-02',1,1);
INSERT INTO tbl_planDetails (PlanId,TermId,TermValue,CreatedDate,ModifiedDate,CreatedUser,ModifiedUser) values(6,6,'This is my tenth term value','2022-01-01','2022-02-02',2,2);























