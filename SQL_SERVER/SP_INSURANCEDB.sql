CREATE PROCEDURE sp_getPlansAndTerms
AS
BEGIN
SET NOCOUNT ON

SELECT tbl_plans.PlanCode,tbl_plans.PlanName, tbl_plans.EffectiveFromDate,tbl_plans.EffectiveTillDate,tbl_refterms.TermName,tbl_planDetails.TermValue
FROM tbl_planDetails
LEFT JOIN tbl_refterms
ON tbl_planDetails.TermId=tbl_refterms.TermId
LEFT JOIN tbl_plans
ON tbl_planDetails.PlanId = tbl_plans.PlanId

END



