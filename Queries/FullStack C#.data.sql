Insert Into Companies(Name, BinarySign) Values('Company1', 0);
Insert Into Companies(Name, BinarySign) Values('Company2', 0);
Insert Into Companies(Name, BinarySign) Values('Company3', 1);
Insert Into Companies(Name, BinarySign) Values('Company4', 0);
Insert Into Companies(Name, BinarySign) Values('Company5', 1);

Insert Into CompaniesBranches(Name, CompanyId) Values('C1_B1', (SELECT Id FROM Companies WHERE Name = 'Company1'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C1_B2', (SELECT Id FROM Companies WHERE Name = 'Company1'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C2_B1', (SELECT Id FROM Companies WHERE Name = 'Company2'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C3_B1', (SELECT Id FROM Companies WHERE Name = 'Company3'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C3_B2', (SELECT Id FROM Companies WHERE Name = 'Company3'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C3_B3', (SELECT Id FROM Companies WHERE Name = 'Company3'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C3_B4', (SELECT Id FROM Companies WHERE Name = 'Company3'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C4_B1', (SELECT Id FROM Companies WHERE Name = 'Company4'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C4_B2', (SELECT Id FROM Companies WHERE Name = 'Company4'))
Insert Into CompaniesBranches(Name, CompanyId) Values('C5_B1', (SELECT Id FROM Companies WHERE Name = 'Company5'))