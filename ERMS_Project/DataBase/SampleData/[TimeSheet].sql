USE [ERMS_Db]

INSERT INTO [dbo].[TimeSheet] 

([EmployeeId], [WeekStartingDate], [IsSubmitted], [SubmittedDate], [IsApproved], [ApprovedDate] )
VALUES
(1001, '2024-06-03', 1, '2024-06-08', 1, '2024-06-10'), -- Submitted and Approved
(1002, '2024-06-10', 1, '2024-06-14', 0, NULL),          -- Submitted, not approved
(1003, '2024-06-17', 0, NULL, 0, NULL),                  -- Not submitted
(1004, '2024-06-03', 1, '2024-06-09', 1, '2024-06-11'),  -- Approved late
(1005, '2024-06-10', 1, '2024-06-12', 1, '2024-06-13');  -- Quick approval

