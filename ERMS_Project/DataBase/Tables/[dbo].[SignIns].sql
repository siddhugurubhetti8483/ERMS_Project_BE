CREATE TABLE [dbo].[SignIns]
(
    SignInId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    SignInDate DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);
