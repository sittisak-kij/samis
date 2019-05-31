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
-- Table structure for table `bugets`
--

DROP TABLE IF EXISTS `bugets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `bugets` (
  `budgetId` int(11) NOT NULL AUTO_INCREMENT,
  `activityId` int(11) NOT NULL,
  `budgetStatusId` int(11) NOT NULL DEFAULT '0',
  `amount` double NOT NULL,
  `budgetDescriptionId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`budgetId`),
  KEY `IX_Bugets_activityId` (`activityId`),
  KEY `IX_Bugets_budgetStatusId` (`budgetStatusId`),
  KEY `IX_Bugets_budgetDescriptionId` (`budgetDescriptionId`),
  CONSTRAINT `FK_Bugets_ActivityInformations_activityId` FOREIGN KEY (`activityId`) REFERENCES `activityinformations` (`activityId`) ON DELETE CASCADE,
  CONSTRAINT `FK_Bugets_BudgetDescription_budgetDescriptionId` FOREIGN KEY (`budgetDescriptionId`) REFERENCES `budgetdescription` (`budgetDescriptionId`) ON DELETE CASCADE,
  CONSTRAINT `FK_Bugets_BudgetStatus_budgetStatusId` FOREIGN KEY (`budgetStatusId`) REFERENCES `budgetstatus` (`budgetStatusId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bugets`
--

LOCK TABLES `bugets` WRITE;
/*!40000 ALTER TABLE `bugets` DISABLE KEYS */;
INSERT INTO `bugets` VALUES (85,30,1,500,1),(86,30,1,500,8),(92,32,1,88000,1),(93,32,1,50000,7),(94,32,1,2000,8),(95,32,1,30000,10),(96,32,1,1000,12),(97,32,1,5000,14),(98,30,2,500,1),(99,30,2,500,8),(100,32,2,80000,1),(101,32,2,50000,7),(102,32,2,2000,8),(103,32,2,30000,10),(104,32,2,1000,12),(105,32,2,5000,14);
/*!40000 ALTER TABLE `bugets` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-31 22:34:23
