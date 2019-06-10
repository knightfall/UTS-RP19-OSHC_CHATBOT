-- MySQL dump 10.13  Distrib 5.7.14, for Linux (x86_64)
--
-- Host: localhost    Database: mysql
-- ------------------------------------------------------
-- Server version	5.7.14-google-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `mbs`
--
CREATE DATABASE IF NOT EXISTS `mbs` ;

USE `mbs`;

DROP TABLE IF EXISTS `OshcQuote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `OshcQuote` (
  `id` varchar(60) NOT NULL,
  `Date` datetime NOT NULL,
  `Duration` int(11) NOT NULL,
  `Allianz` decimal(16,2) DEFAULT NULL,
  `Nib` decimal(16,2) DEFAULT NULL,
  `Medibank` decimal(16,2) DEFAULT NULL,
  `Ahm` decimal(16,2) DEFAULT NULL,
  `cbhs` decimal(16,2) DEFAULT NULL,
  `Bupa` decimal(16,2) DEFAULT NULL,
  `covertype` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `schedule` (
  `ItemNum` varchar(5) NOT NULL,
  `SubItemNum` varchar(15) DEFAULT NULL,
  `ItemStartDate` date DEFAULT NULL,
  `ItemEndDate` date DEFAULT NULL,
  `Category` varchar(5) DEFAULT NULL,
  `Group` varchar(5) DEFAULT NULL,
  `SubGroup` varchar(5) DEFAULT NULL,
  `SubHeading` varchar(5) DEFAULT NULL,
  `ItemType` varchar(4) DEFAULT NULL,
  `FeeType` varchar(4) DEFAULT NULL,
  `ProviderType` varchar(4) DEFAULT NULL,
  `NewItem` varchar(5) DEFAULT NULL,
  `ItemChange` varchar(5) DEFAULT NULL,
  `AnaesChange` varchar(5) DEFAULT NULL,
  `DescriptorChange` varchar(100) DEFAULT NULL,
  `FeeChange` varchar(5) DEFAULT NULL,
  `EMSNChange` varchar(5) DEFAULT NULL,
  `EMSNCap` varchar(5) DEFAULT NULL,
  `BenefitType` varchar(5) DEFAULT NULL,
  `BenefitStartDate` date DEFAULT NULL,
  `FeeStartDate` date DEFAULT NULL,
  `ScheduleFee` decimal(6,2) DEFAULT NULL,
  `Benefit75` decimal(6,2) DEFAULT NULL,
  `Benefit85` decimal(6,2) DEFAULT NULL,
  `Benefit100` decimal(6,2) DEFAULT NULL,
  `Basic Units` decimal(6,2) DEFAULT NULL,
  `EMSNStartDate` date DEFAULT NULL,
  `EMSNEndDate` date DEFAULT NULL,
  `EMSNFixedCapAmount` decimal(7,2) DEFAULT NULL,
  `EMSNPercentageCap` decimal(7,2) DEFAULT NULL,
  `EMSNMaximumCap` decimal(7,2) DEFAULT NULL,
  `EMSNDescription` longtext,
  `EMSNChangeDate` date DEFAULT NULL,
  `DerivedFeeStartDate` date DEFAULT NULL,
  `DerivedFee` longtext,
  `Anaes` varchar(45) DEFAULT NULL,
  `DescriptionStartDate` date DEFAULT NULL,
  `Description` longtext,
  `QFEStartDate` date DEFAULT NULL,
  `QFEEndDate` date DEFAULT NULL,
  PRIMARY KEY (`ItemNum`),
  UNIQUE KEY `ItemNum_UNIQUE` (`ItemNum`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
