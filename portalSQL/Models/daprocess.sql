-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 15, 2021 at 04:11 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 7.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pceruntime`
--

-- --------------------------------------------------------

--
-- Table structure for table `daprocess`
--

CREATE TABLE `daprocess` (
  `SeqNbr` int(11) NOT NULL,
  `ProductCode` text NOT NULL,
  `Product` text NOT NULL,
  `BizProcCode` text NOT NULL,
  `Process` text NOT NULL,
  `BizProcNbr` text NOT NULL,
  `Status` int(11) NOT NULL,
  `StatusDesc` text NOT NULL,
  `BranchCode` text NOT NULL,
  `StatusDate` text NOT NULL,
  `StatusTime` text NOT NULL,
  `User` text NOT NULL,
  `UserLock` text NOT NULL,
  `CreationDate` text NOT NULL,
  `CreationTime` text NOT NULL,
  `CreationUser` text NOT NULL,
  `CustomerName` text NOT NULL,
  `CustomerNbr` text NOT NULL,
  `ContractNbr` text NOT NULL,
  `Transit` text NOT NULL,
  `EntryChannel` text NOT NULL,
  `CentralStatus` text NOT NULL,
  `AssociatedDAProcessSeqNbr` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `daprocess`
--

INSERT INTO `daprocess` (`SeqNbr`, `ProductCode`, `Product`, `BizProcCode`, `Process`, `BizProcNbr`, `Status`, `StatusDesc`, `BranchCode`, `StatusDate`, `StatusTime`, `User`, `UserLock`, `CreationDate`, `CreationTime`, `CreationUser`, `CustomerName`, `CustomerNbr`, `ContractNbr`, `Transit`, `EntryChannel`, `CentralStatus`, `AssociatedDAProcessSeqNbr`) VALUES
(15, 'CE_0001', 'cARTAO QUALQUER COISA', '4234234234', 'campodoProcess', 'asdasd', 25, 'Campo_StatusDesc', 'Campo_BranchCode', '20-06-2000', '412233', 'Artur', 'campo_UserLock', 'campo_CreationDate', 'campo_CreationTime', 'campo_CreationUser', 'campo_CustomerName', 'campo_CustomerNbr', 'campo_ContractNbr', 'campo_Transit', 'campo_EntryChannel', 'campo_CentralStatus', 'campo_AssociatedDAProcessSeqNbr');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
