namespace ERMS_Project.Constants
{
    public static class APIConstants
    {
        //PARM = PARAMETER, VAL = VALUE, EMP = EMPLOYEE

        public const string PARM_NAME_MODE = "@mode";
        public const string PARM_VAL_GET = "GET";
        public const string PARM_VAL_GET_BYID = "GET_BYID";
        public const string EMP_SEQ = "EMPSEQ";
        public const string EMP_SP_NAME = "usp_GetEmployees";//done
        public const string MANAGERS_SP_NAME = "usp_GetManagers";//done
        public const string EMPSEQ_SP_NAME = "usp_GetSequenceNumber";//pending*
        public const string EMP_COUNT_SP_NAME = "usp_GetEmployeeCount";//done 
        public const string DESIGNATION_SP = "usp_Get_Designation";//done
        public const string PARM_VAL_CREATE = "CREATE";
        public const string PARM_NAME_MODIFYTBY = "ModifiedBy ";
        public const string PARM_VAL_UPDATE = "UPDATE";
        public const string PARM_VAL_DELETE = "DELETE";
        public const string USP_LOCATION_NAME = "USP_Location";
        public const string ACCOUNT_COUNT_SP_NAME = "usp_GetAccountCount";
        public const string PARM_NAME_GET_BYNAME = "GET_BYNAME";






        //test comment
        public const string ACCOUNT_ADD_EDIT_SP_NAME = "usp_Accounts";
        public const string PARAM_NAME_ACCOUNTID = "AccountId";
        public const string PARAM_NAME_NAME = "Name";
        public const string PARAM_NAME_DESCRIPTION = "Description";
        public const string PARAM_NAME_ACCOUNTLOCATION = "AccountLocation";
        public const string PARAM_NAME_POCNAME = "POCName";
        public const string PARAM_NAME_POCEMAIL = "POCEmail";
        public const string PARAM_NAME_POCMOBILENUMBER = "PocMobileNumber";
        public const string PARAM_NAME_COUNTRYID = "CountryId";
        public const string PARAM_NAME_GSTNUMBER = "GstNumber";
        public const string PARAM_NAME_PAYMENTTERMDURATION = "PaymentTermsDuration";
        public const string PARAM_NAME_CREATEDBY = "CreatedBy ";
        public const string PARAM_NAME_MODIFYTBY = "ModifiedBy ";
        public const string ACCOUNT_SP_NAME = "usp_Get_Delete_Accounts";
        public const string SP_NAME_USP_CountryMaster = "USP_CountryMaster";
        public const string PARAM_NAME_COUNTRYNAME = "CountryName";
        public const string PARAM_VALUE_CREATE = "CREATE";
        public const string PARAM_NAME_REGION = "Region";
        public const string PROJECT_SP_NAME = "usp_Project";








        //Employee
        public const string PARAM_NAME_ALLOCATIONID = "AllocationId";
        public const string PARAM_NAME_PROJECTID = "ProjectId";
        public const string PARAM_VALUE_SUBPRACTICES_SUBPRACTICEID = "SubPracticeId";
        public const string PARAM_NAME_STARTDATE = "StartDate";
        public const string PARAM_NAME_ENDDATE = "EndDate";
        public const string PARAM_NAME_ALLOCATION_STATUS = "AllocationStatus";
        public const string PARAM_NAME_ISBILLABLE = "IsBillable";
        public const string PARAM_NAME_ISUTILIZED = "IsUtilized";
        public const string PARAM_NAME_ALLOCATION_PERCENTAGE = "AllocationPercentage";
        public const string PARAM_NAME_BILLABLE_PERCENTAGE = "BillablePercentage";
        public const string PARAM_NAME_REMARKS = "Remarks";
        public const string PARAM_NAME_MODIFIEDBY = "ModifiedBy";

        public const string PARAM_MODE_ALLOCATE_EMPLOYEE = "ALLOCATE_EMPLOYEES";





        public const string EMPLOYEEALLOCATION_SP_NAME = "usp_GetEmployeeAllocation";//done
        public const string PARAM_MODE_GET_EMPLOYEE_ALLOCATION_BY_ALLOCATION_ID = "GET_BY_ALLOCATIO_ID";//pending*
        public const string EMPLOYEE_ALLOCATION_SP_NAME = "usp_Add_Edit_EmployeeAllocations";//done
        public const string EMPLOYEE_COUNTALLOCATIONS_SP_NAME = "usp_GetEmployeesCountAllocations";//done*







        //Employee
        public const string PARM_NAME_EMPID = "EmployeeId";
        public const string PARM_NAME_EMP_NAME = "EmployeeName";
        public const string PARM_NAME_FNAME = "FirstName";
        public const string PARM_NAME_MNAME = "MiddleName";
        public const string PARM_NAME_LNAME = "LastName";
        public const string PARM_NAME_DATEOFJOINING = "DateofJoining";
        public const string PARM_NAME_EMPCODE = "EmployeeCode";
        public const string PARM_NAME_OFFICIALMALE = "OfficeEmailAddress";
        public const string PARM_NAME_EMPTYPEID = "EmployeeTypeId";
        public const string PARM_NAME_REVISEDLOCATIONID = "RevisedLocationId";
        public const string PARM_NAME_DESIGNATION = "Designation";
        public const string PARM_NAME_OVERALLEXPERIENCE = "TotalExperience";
        public const string PARM_NAME_REPORTINGMANAGERID = "L1ManagerId";
        public const string PARM_NAME_EMPMENTSATUS = "EmploymentStatus";
        public const string PARM_NAME_ISENGINEERING = "IsEngineering";
        public const string PARM_NAME_IsNextAssignmentIdentified = "IsNextAssignmentIdentified";
        public const string PARM_NAME_SUBPRACTICEID = "SubPracticeId";
        public const string PARM_NAME_NEXTASSIGNMENTNAME = "NextAssignmentName";
        public const string PARM_NAME_NEXTASSIGNMENTSTARTDATE = "NextAssignmentStartDate";
        public const string PARM_NAME_CREATEDBY = "CreatedBy";
        public const string PARM_NAME_LASTWORKINGDATE = "LastWorkingDate";
        public const string PARM_NAME_ReportingMANAGERNAME = "L1ManagerName";
        public const string PARM_NAME_DELETE_EMP_ID = "EmployeeId";


        public const string EMP_ADDEDIT_SP_NAME = "usp_ADD_EDIT_EMP";//done
        //public const string EMP_SP_Filter_NAME = "usp_Get_Delete_Employee";//pending
        public const string EMP_SP_DELETE_NAME = "usp_Get_Delete_Employee";//Done
        public const string EMP_SP_DELETE_NAMES = "usp_Get_Delete_Employee";//done








    }
}
