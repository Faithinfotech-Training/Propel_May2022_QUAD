------------------------------CLINIC MANAGEMENT SYSTEM---------------------------------------------
-----------------------------------------QUAD-TEAM----------------------------------

--------------DATABASE----------------
CREATE DATABASE QuadClinic;

--------------USE DATABASE-------------
USE QuadClinic;

--------------TABLE SCRIPTS------------------------



---------------CLINIC TABLE----------------------------
CREATE TABLE ClinicInfo
(	
	ClinicId INT PRIMARY KEY IDENTITY,
	RegId AS 'RE220' + CAST(ClinicId AS VARCHAR(20)),
	ClinicName VARCHAR(100)
	);

--INSERT VALUES TO CLINIC TABLE-
INSERT INTO ClinicInfo VALUES('MULTISPECIALITY - CLINIC || QUAD - CLINIC');
SELECT * FROM ClinicInfo;



---------------ROLE TABLE------------------------
CREATE TABLE [Role]
(	
	RoleId INT PRIMARY KEY IDENTITY,
	RoleName VARCHAR(50)
	);

--INSERT VALUES TO CLINIC TABLE-
INSERT INTO [Role] VALUES('Admin'),('Receptionist'),('Doctor'),('Lab Technician'),('Pharmacist');
SELECT * FROM [Role];






------------------STAFF TABLE----------------------------
CREATE TABLE Staff
(	
	StaffId INT PRIMARY KEY IDENTITY,
	StaffFullname VARCHAR(80),
	StaffGender VARCHAR(50),
	StaffDOB DATE,
	StaffMobileNumber VARCHAR(10),
	StaffDesignation VARCHAR(80),
	StaffAddress VARCHAR(200),
	StaffCreatedDate DATE DEFAULT GETDATE(),
	StaffIsActive BIT,
	);

--INSERT VALUES TO STAFF TABLE-
INSERT INTO Staff VALUES
('Abish Dev A','Male','12/04/1995','9961808593','Administrator','Trivandrum',default,1),
('Hemojit H','Male','04/03/1997','8943873493','Receptionist','Manipur',default,1),
('Raji Ajith','Female','10/24/1996','7902958593','Doctor','Kollam',default,1),
('Nanaocha T','Male','12/06/1994','9745713512','Lab Technician','Manipur',default,1),
('Abish Dev','Male','04/21/1995','9562590203','Pharmacist','Trivandrum',default,1);
SELECT * FROM Staff;
SELECT * FROM [Role];


-----------------------USER TABLE-----------------
CREATE TABLE [User]
(	
	UserId INT PRIMARY KEY IDENTITY,
	RoleId INT,
	StaffId INT,
	FOREIGN KEY (RoleId) REFERENCES [ROLE] (RoleId),
	FOREIGN KEY (StaffId) REFERENCES Staff (StaffId),
	UserName VARCHAR(80),
	[Password] VARCHAR(25)
	);

--INSERT VALUES TO [User] TABLE-
INSERT INTO [User] VALUES
(1,1,'admin','admin123'),
(2,2,'reception','reception123'),
(3,3,'doctor','doctor123'),
(4,4,'labtech','labtech123'),
(5,5,'pharmacy','pharmacy123');

SELECT * FROM [User];

----------------------------SPECIALIZATION TABLE------------------
CREATE TABLE Specialization
(
	SpecializationId INT PRIMARY KEY IDENTITY,
	SpecializationName VARCHAR(100)
	);

-----------------------------DOCTOR-------------------------------
CREATE TABLE Doctor
(	
	DoctorId INT PRIMARY KEY IDENTITY,
	StaffId INT,
	SpecializationId INT,
	ConsultationFees VARCHAR(15),
	FOREIGN KEY (StaffId) REFERENCES Staff (StaffId),
	FOREIGN KEY (SpecializationId) REFERENCES Specialization (SpecializationId),
	);

-------------------------BLOOD GROUP--------------------------------------
CREATE TABLE BloodGroup
(
	BloodGroupId INT PRIMARY KEY IDENTITY,
	BloodGroup VARCHAR(5)
	);
--INSERT VALUES TO BloodGroup TABLE-
INSERT INTO BloodGroup VALUES
('A+'),('A-'),('B+'),('B-'),('AB+'),('AB-'),('O+'),('O-');

--------------------------PATIENT TABLE ---------------------------------
CREATE TABLE Patient
(
	PatientId INT PRIMARY KEY IDENTITY,
	PatientRegId AS 'QP220' + CAST(PatientId AS VARCHAR(20)),
	PatientName VARCHAR(100),
	StaffGender VARCHAR(50),
	PatientDOB DATE,
	PatientMobileNumber VARCHAR(10),
	BloodGroupId INT,
	FOREIGN KEY (BloodGroupId) REFERENCES BloodGroup (BloodGroupId),
	PatientAddress VARCHAR(200),
	PatientCreatedDate DATE DEFAULT GETDATE(),
	PatientIsActive BIT,
	);


--------------------------------APPOINTMENT TABLE------------------------------
CREATE TABLE Appointment
(	
	AppointmentId INT PRIMARY KEY IDENTITY,
	PatientId INT,
	DoctorId INT,
	AppointmentDate DATE DEFAULT GETDATE(),
	TokenNumber INT,
	SpecializationId INT,
	FOREIGN KEY (DoctorId) REFERENCES Doctor (DoctorId),
	FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	FOREIGN KEY (SpecializationId) REFERENCES Specialization (SpecializationId)
	)

-------------------------------MEDICINE TABLE-------------------------------------
CREATE TABLE Medicine
(
	MedicineId INT PRIMARY KEY IDENTITY,
	MedicineName VARCHAR(100),
	GenericName VARCHAR(100),
	CompanyName VARCHAR(100),
	MedicinePrice VARCHAR(10),
	MedicineIsActive BIT
	);

--------------------------------LAB TEST TABLE--------------------------------------
CREATE TABLE LabTest
(
	LabTestId INT PRIMARY KEY IDENTITY,
	LabTestCode VARCHAR(10),
	LabTestName VARCHAR(50),
	LabTestPrice VARCHAR(10),
	LabTestIsActive BIT
	);

----------------------------------MEDICINE PRESCRIPTION------------------------

CREATE TABLE MedicinePrescription
(	
	MedicinePrescId INT PRIMARY KEY IDENTITY,
	MedicineId INT,
	PatientId INT,
	AppointmentId INT,
	DoctorId INT,
	Dosage VARCHAR(50),
	NumberOfDays VARCHAR(50),
	FOREIGN KEY (MedicineId) REFERENCES Medicine (MedicineId),
	FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	FOREIGN KEY (AppointmentId) REFERENCES Appointment (AppointmentId),
	FOREIGN KEY (DoctorId) REFERENCES Doctor (DoctorId)
	);

-------------------------------LAB TEST PRESCRIPTION------------------------
CREATE TABLE LabTestPrescription
(	
	LabTestPrescId INT PRIMARY KEY IDENTITY,
	LabTestId INT,
	PatientId INT,
	AppointmentId INT,
	DoctorId INT,
	FOREIGN KEY (LabTestId) REFERENCES LabTest (LabTestId),
	FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	FOREIGN KEY (AppointmentId) REFERENCES Appointment (AppointmentId),
	FOREIGN KEY (DoctorId) REFERENCES Doctor (DoctorId)
	);

--------------------------LAB TEST REPORT----------------------------------
CREATE TABLE LabTestReport
(
	LabTestReport INT PRIMARY KEY IDENTITY,
	LabTestPrescId INT,
	PatientId INT,
	DoctorId INT,
	LowRange VARCHAR(50),
	HighRange VARCHAR(50),
	LabTestReportRemarks VARCHAR(150),
	LabTestReportPrice VARCHAR(50)
	FOREIGN KEY (LabTestPrescId) REFERENCES LabTestPrescription (LabTestPrescId),
	FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	FOREIGN KEY (DoctorId) REFERENCES Doctor (DoctorId)
	);

----------------------TREATMENT HISTORY-----------------------------
CREATE TABLE TreatmentHistory
(	
	TreatmentHistoryId INT PRIMARY KEY IDENTITY,
	PatientId INT,
	DoctorId INT,
	LabTestPrescId INT,
	MedicinePrescId INT,
	AppointmentId INT,
	Diagnosis VARCHAR(100),
	Note VARCHAR(100),
	TreatmentHistoryCreatedDate DATE DEFAULT GETDATE(),
	FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	FOREIGN KEY (DoctorId) REFERENCES Doctor (DoctorId),
	FOREIGN KEY (LabTestPrescId) REFERENCES LabTestPrescription (LabTestPrescId),
	FOREIGN KEY (MedicinePrescId) REFERENCES MedicinePrescription (MedicinePrescId),
	FOREIGN KEY (AppointmentId) REFERENCES Appointment (AppointmentId)
	);
	
------------------------------APPOINTMENT BILL-------------------------------
CREATE TABLE AppointmentBill
(	
	AppointmentBillId INT PRIMARY KEY IDENTITY,
	AppointmentId INT,
	PatientId INT,
	DoctorId INT,
	ClinicId INT,
	AppointmentBillAmount VARCHAR(15),
	AppointmentBillDate DATE DEFAULT GETDATE(),
	FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	FOREIGN KEY (DoctorId) REFERENCES Doctor (DoctorId),
	FOREIGN KEY (AppointmentId) REFERENCES Appointment (AppointmentId),
	FOREIGN KEY (ClinicId) REFERENCES ClinicInfo (ClinicId)
	);

------------------------------LAB TEST BILL-------------------------------
CREATE TABLE LabTestBill
(	
	LabTestBillId INT PRIMARY KEY IDENTITY,
	AppointmentId INT,
	PatientId INT,
	DoctorId INT,
	ClinicId INT,
	LabTestPrescId INT,
	LabTestBillAmount VARCHAR(15),
	LabTestBillDate DATE DEFAULT GETDATE(),
	FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	FOREIGN KEY (DoctorId) REFERENCES Doctor (DoctorId),
	FOREIGN KEY (AppointmentId) REFERENCES Appointment (AppointmentId),
	FOREIGN KEY (ClinicId) REFERENCES ClinicInfo (ClinicId),
	FOREIGN KEY (LabTestPrescId) REFERENCES LabTestPrescription (LabTestPrescId),
	);

----------------MEDICINE BILL TABLE-----------------
CREATE TABLE MedicineBill
(
	MedicineBillId INT PRIMARY KEY IDENTITY,
	AppointmentId INT,
	PatientId INT,
	DoctorId INT,
	MedicinePrescId INT,
	MedicineBillAmount VARCHAR(10),
	MedicineBillDate DATE DEFAULT GETDATE(),
	FOREIGN KEY(AppointmentId) REFERENCES Appointment(AppointmentId),
	FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
	FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId),
	FOREIGN KEY(MedicinePrescId) REFERENCES MedicinePrescription(MedicinePrescId)
	);



	
	
