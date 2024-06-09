using office360.Common.CommonHelper;
using office360.Extensions;
using office360.Models.EDMX;
using office360.Models.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static office360.Models.General.DocumentStatus;
using static office360.Models.General.HttpStatus;
using static office360.Models.General.ListConditionsForDB;

namespace office360.Common.DataBaseProcedures.ABranches
{
    public class InsertIntoDB
    {
        public static int? GeneralBranch_Insert(_SqlParameters PostedData)
        {
            using (var db = new SESEntities())
            {
                using (System.Data.Entity.DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        #region INPUT VARIABLE 
                        SqlParameter descriptionParam = new SqlParameter("@Description", PostedData.Description);
                        SqlParameter campusTypeIdParam = new SqlParameter("@CampusTypeId", PostedData.CampusTypeId);
                        SqlParameter organizationTypeIdParam = new SqlParameter("@OrganizationTypeId", PostedData.OrganizationTypeId);
                        SqlParameter countryIdParam = new SqlParameter("@CountryId", PostedData.CountryId);
                        SqlParameter cityIdParam = new SqlParameter("@CityId", PostedData.CityId);
                        SqlParameter addressParam = new SqlParameter("@Address", PostedData.Address);
                        SqlParameter contactNoParam = new SqlParameter("@ContactNo", PostedData.ContactNo);
                        SqlParameter emailAddressParam = new SqlParameter("@EmailAddress", PostedData.EmailAddress);
                        SqlParameter ntnNoParam = new SqlParameter("@NTNNo", PostedData.NTNNo);
                        SqlParameter remarksParam = new SqlParameter("@Remarks", PostedData.Remarks);
                        SqlParameter companyIdParam = new SqlParameter("@CompanyId", Session_Manager.CompanyId);
                        SqlParameter createdByParam = new SqlParameter("@CreatedBy", Session_Manager.UserId);
                        #endregion
                        #region OUTPUT VARAIBLE
                        SqlParameter codeParam = new SqlParameter("@Code", SqlDbType.NVarChar, -1);
                        codeParam.Direction = ParameterDirection.Output;
                        SqlParameter responseParam = new SqlParameter("@Response", SqlDbType.Int);
                        responseParam.Direction = ParameterDirection.Output;
                        #endregion
                        #region EXECUTE STORE PROCEDURE
                        db.Database.ExecuteSqlCommand(
                            "GeneralBranch_Insert @Description, @CampusTypeId, @OrganizationTypeId, @CountryId, @CityId, @Address, @ContactNo, @EmailAddress, @NTNNo, @Remarks, @CompanyId, @CreatedBy, @Code OUTPUT, @Response OUTPUT",
                            descriptionParam, campusTypeIdParam, organizationTypeIdParam, countryIdParam, cityIdParam, addressParam, contactNoParam, emailAddressParam, ntnNoParam, remarksParam, companyIdParam, createdByParam, codeParam, responseParam
                        );
                        #endregion
                        dbTran.Commit();
                        #region RESPONSE VALUES IN VARIABLE
                        string code = codeParam.Value.ToString();
                        int? Response = (int)responseParam.Value;
                        #endregion
                        return HttpStatus.HttpResponseByReturnValue(Response);

                    }
                    catch (Exception Ex)
                    {
                        dbTran.Rollback();
                        return HttpStatus.HttpResponses.CODE_INTERNAL_SERVER_ERROR.ToInt();
                    }
                }
            }
        }
        public static int? AppClass_Insert(_SqlParameters PostedData)
        {
            using (var db = new SESEntities())
            {
                using (System.Data.Entity.DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        #region OUTPUT VARIABLES
                        SqlParameter codeParam = new SqlParameter("@Code_", SqlDbType.NVarChar, -1);
                        codeParam.Direction = ParameterDirection.Output;

                        SqlParameter responseParam = new SqlParameter("@Response", SqlDbType.Int);
                        responseParam.Direction = ParameterDirection.Output;
                        #endregion
                        #region INPUT VARIABLES & STORE PROCEDURE EXECUTION
                        db.Database.ExecuteSqlCommand(
                            "AppClass_Insert @Description, @BranchId, @CompanyId, @CreatedBy, @StudyLevelId, @StudyGroupId, @Response OUTPUT, @Code_ OUTPUT",
                            new SqlParameter("@Description", PostedData.Description),
                            new SqlParameter("@BranchId", Session_Manager.BranchId),
                            new SqlParameter("@CompanyId", Session_Manager.CompanyId),
                            new SqlParameter("@CreatedBy", Session_Manager.UserId),
                            new SqlParameter("@StudyLevelId", PostedData.StudyLevelId),
                            new SqlParameter("@StudyGroupId", PostedData.StudyGroupId),
                            codeParam,
                            responseParam
                        );
                        dbTran.Commit();
                        #endregion
                        #region GET DATA IN RESPONSE
                        string code = codeParam.Value.ToString();
                        int? Response = (int)responseParam.Value;
                        return HttpStatus.HttpResponseByReturnValue(Response);
                        
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        return HttpStatus.HttpResponses.CODE_INTERNAL_SERVER_ERROR.ToInt();
                    }
                }
            }
        }
        public static int? AppSession_Insert(_SqlParameters PostedData)
        {
            using (var db = new SESEntities())
            {
                using (System.Data.Entity.DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        #region INPUT VARAIBLES
                        var ParamArray = new object[]
                        {
                            new SqlParameter("@Description", PostedData.Description),
                            new SqlParameter("@SessionStartOn", PostedData.SessionStartDate),
                            new SqlParameter("@SessionEndOn", PostedData.SessionEndDate),
                            new SqlParameter("@DocumentStatus", (int?)FileStatus.Open_ADMISSION),
                            new SqlParameter("@CompanyId", Session_Manager.CompanyId),
                            new SqlParameter("@BranchId", Session_Manager.BranchId),
                            new SqlParameter("@CreatedBy", Session_Manager.UserId),
                            new SqlParameter("@OpenClassIds", PostedData.OpenClassIds),
                            new SqlParameter("@EnrollmentTypeId", PostedData.EnrollmentTypeId),

                            #endregion
                        #region OUTPUT VARIABLES
                            new SqlParameter("@Response", SqlDbType.Int) { Direction = ParameterDirection.Output },
                            new SqlParameter("@Code_", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output }
                        };
                        #endregion
                        #region EXECUTION OF STORE PROCEDURE
                        db.Database.ExecuteSqlCommand("AppSession_Insert @Description, @SessionStartOn, @SessionEndOn, @DocumentStatus, @CompanyId, @BranchId, @CreatedBy, @OpenClassIds, @EnrollmentTypeId, @Response OUTPUT, @Code_ OUTPUT", ParamArray);
                        #endregion
                        dbTran.Commit();
                        #region GETTING RESPONSE DATA INTO VARIABLE
                        SqlParameter responseParameter = (SqlParameter)ParamArray[9];
                        int? Response = (int?)responseParameter.Value;
                        SqlParameter codeParameter = (SqlParameter)ParamArray[10];
                        string code = codeParameter.Value.ToString();
                        #endregion
                        return HttpStatus.HttpResponseByReturnValue(Response);
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        return HttpStatus.HttpResponses.CODE_INTERNAL_SERVER_ERROR.ToInt();
                    }
                }
            }
        }
        public static int? AppStudent_Insert(_SqlParameters PostedData)
        {
            using (var db = new SESEntities())
            {
                using (System.Data.Entity.DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        var Id = Uttility.GetHashGuid();

                        #region VARIABLE STUDENTS
                        var ParamArray = new object[]
                        {
                            new SqlParameter("@Id", Id),
                            new SqlParameter("@SessionId", PostedData.SessionId),
                            new SqlParameter("@FirstName", PostedData.FirstName),
                            new SqlParameter("@LastName", PostedData.LastName),
                            new SqlParameter("@CnicNo_FormBNo", PostedData.CnicNo_FormBNo),
                            new SqlParameter("@GenderId", PostedData.GenderId),
                            new SqlParameter("@DOB", PostedData.DateofBirth),
                            new SqlParameter("@MartialStatusId", PostedData.MartialStatusId),
                            new SqlParameter("@ReligionId", PostedData.ReligionId),
                            new SqlParameter("@NationalityId", PostedData.NationalityId),
                            new SqlParameter("@ResedenitalAddress", PostedData.ResedenitalAddress),
                            new SqlParameter("@MobileNumber", PostedData.MobileNumber),
                            new SqlParameter("@EmailAddress", PostedData.EmailAddress),
                            new SqlParameter("@ParentName", PostedData.ParentName),
                            new SqlParameter("@ParentCnic", PostedData.ParentNICNo),
                            new SqlParameter("@ParentStudyLevelId", PostedData.ParentStudyLevelId),
                            new SqlParameter("@OccupationId", PostedData.OccupationId),
                            new SqlParameter("@RelationshipId", PostedData.RelationshipId),
                            new SqlParameter("@MonthlyIncome", PostedData.MonthlyIncome),
                            new SqlParameter("@DocumentStatus", (int?)FileStatus.Active_STUDENT),
                            new SqlParameter("@CreatedBy", Session_Manager.UserId),
                            new SqlParameter("@BranchId", Session_Manager.BranchId),
                            new SqlParameter("@CompanyId", Session_Manager.CompanyId),
                            new SqlParameter("@DocType", (int?)Models.General.DocumentStatus.DocType.Students),
                            new SqlParameter("@Code_", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output },
                            new SqlParameter("@Response", SqlDbType.Int) { Direction = ParameterDirection.Output },

                        };
                        #endregion
                        #region EXECUTE STORE PROCEDURE AppStudent_Insert
                        db.Database.ExecuteSqlCommand("AppStudent_Insert " +
                                          "@Id, @SessionId, @FirstName, @LastName, @CnicNo_FormBNo, @GenderId, " +
                                          "@DOB, @MartialStatusId, @ReligionId, @NationalityId, @ResedenitalAddress, " +
                                          "@MobileNumber, @EmailAddress, @ParentName, @ParentCnic, @ParentStudyLevelId, " +
                                          "@OccupationId, @RelationshipId, @MonthlyIncome, @DocumentStatus, @CreatedBy, " +
                                          "@BranchId, @CompanyId, @DocType, @Code_ OUTPUT, @Response OUTPUT", ParamArray);
                        #endregion
                        #region VARIABLE ENROLLMENT
                        var _ParamArray = new object[]
                        {
                            new SqlParameter("@SessionId", PostedData.SessionId),
                            new SqlParameter("@StudentId", Id),
                            new SqlParameter("@ClassId", PostedData.ClassId),
                            new SqlParameter("@DocumentStatus", (int?)Models.General.DocumentStatus.FileStatus.NewEnrollment_CLASS_REGISTRATION),
                            new SqlParameter("@DocType", (int?)Models.General.DocumentStatus.DocType.ClassEnrollment),
                            new SqlParameter("@CreatedBy", Session_Manager.UserId),
                            new SqlParameter("@BranchId", Session_Manager.BranchId),
                            new SqlParameter("@CompanyId", Session_Manager.CompanyId),
                            new SqlParameter("@Response", SqlDbType.Int) { Direction = ParameterDirection.Output },
                            new SqlParameter("@RegistrationTypeId", (int?)EnrollmentType.New_Enrollment),
                        };
                        #endregion
                        #region EXECUTE STORE PROCEDURE AppClassRegistration_Insert
                        db.Database.ExecuteSqlCommand("AppClassRegistration_Insert " +
                            "@SessionId,@StudentId,@ClassId,@DocumentStatus,@DocType,@CreatedBy,@BranchId,@CompanyId," +
                            "@Response OUTPUT,@RegistrationTypeId", _ParamArray);
                        #endregion
                        dbTran.Commit();

                        SqlParameter responseParameter = (SqlParameter)ParamArray[25];
                        int? Response = (int?)responseParameter.Value;
                        SqlParameter codeParameter = (SqlParameter)ParamArray[24];
                        string code = codeParameter.Value.ToString();

                        return HttpStatus.HttpResponseByReturnValue(Response);
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        return HttpStatus.HttpResponses.CODE_INTERNAL_SERVER_ERROR.ToInt();
                    }
                }
            }
        }
    }
}