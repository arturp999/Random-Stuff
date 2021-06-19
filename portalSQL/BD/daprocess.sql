USE pceruntimeDB
--

CREATE TABLE daprocess (
  "id" int NOT NULL,
  "SeqNbr" int NOT NULL,
  "ProductCode" text NOT NULL,
  "Product" text NOT NULL,
  "BizProcCode" text NOT NULL,
  "Process" text NOT NULL,
  "BizProcNbr" text NOT NULL,
  "Status" int NOT NULL,
  "StatusDesc" text NOT NULL,
  "BranchCode" text NOT NULL,
  "StatusDate" text NOT NULL,
  "StatusTime" text NOT NULL,
  "User" text NOT NULL,
 "UserLock" text NOT NULL,
  "CreationDate" text NOT NULL,
  "CreationTime" text NOT NULL,
  "CreationUser" text NOT NULL,
  "CustomerName" text NOT NULL,
  "CustomerNbr" text NOT NULL,
  "ContractNbr" text NOT NULL,
  "Transit" text NOT NULL,
  "EntryChannel" text NOT NULL,
  "CentralStatus" text NOT NULL,
  "AssociatedDAProcessSeqNbr" text NOT NULL,
  PRIMARY KEY (id)
)

--
-- Dumping data for table `daprocess`
--

INSERT INTO "daprocess" ("SeqNbr", "ProductCode", "Product", "BizProcCode", "Process", "BizProcNbr", "Status", "StatusDesc", "BranchCode", "StatusDate", "StatusTime", "User", "UserLock", "CreationDate", "CreationTime", "CreationUser", "CustomerName", "CustomerNbr", "ContractNbr", "Transit", "EntryChannel", "CentralStatus", "AssociatedDAProcessSeqNbr") VALUES
(15, 'CE_0001', 'cARTAO QUALQUER COISA', '4234234234', 'campodoProcess', 'asdasd', 25, 'Campo_StatusDesc', 'Campo_BranchCode', '20-06-2000', '412233', 'Artur', 'campo_UserLock', 'campo_CreationDate', 'campo_CreationTime', 'campo_CreationUser', 'campo_CustomerName', 'campo_CustomerNbr', 'campo_ContractNbr', 'campo_Transit', 'campo_EntryChannel', 'campo_CentralStatus', 'campo_AssociatedDAProcessSeqNbr');

