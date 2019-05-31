-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: samis
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `budgetdescription`
--

DROP TABLE IF EXISTS `budgetdescription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `budgetdescription` (
  `budgetDescriptionId` int(11) NOT NULL AUTO_INCREMENT,
  `name` longtext,
  `budgetTypeId` int(11) NOT NULL,
  PRIMARY KEY (`budgetDescriptionId`),
  KEY `IX_BudgetDescription_budgetTypeId` (`budgetTypeId`),
  CONSTRAINT `FK_BudgetDescription_BudgetTypes_budgetTypeId` FOREIGN KEY (`budgetTypeId`) REFERENCES `budgettypes` (`budgetTypeId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `budgetdescription`
--

LOCK TABLES `budgetdescription` WRITE;
/*!40000 ALTER TABLE `budgetdescription` DISABLE KEYS */;
INSERT INTO `budgetdescription` VALUES (1,'AUSO Support',1),(2,'Other Income',1),(3,'Participant Support',1),(4,'Receive from Member',1),(5,'Sales Income',1),(6,'Sponsor Support',1),(7,'Accommodation, Seminar Room & Fee(s)',2),(8,'Document',2),(9,'Equipment',2),(10,'Food and beverage',2),(11,'Medicine',2),(12,'Miscellaneous',2),(13,'Promotion',2),(14,'Remuneration',2),(15,'Supply',2),(16,'Survey',2),(17,'Transportation',2);
/*!40000 ALTER TABLE `budgetdescription` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-31 22:34:22
