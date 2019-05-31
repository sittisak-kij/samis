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
-- Table structure for table `activityinformations`
--

DROP TABLE IF EXISTS `activityinformations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `activityinformations` (
  `activityId` int(11) NOT NULL AUTO_INCREMENT,
  `activityUnitId` int(11) NOT NULL,
  `referenceNumber` longtext,
  `activityName` longtext,
  `projectLevelId` int(11) NOT NULL DEFAULT '0',
  `activityTypeId` int(11) NOT NULL,
  `startDate` datetime(6) DEFAULT NULL,
  `endDate` datetime(6) DEFAULT NULL,
  `venue` longtext,
  `semester` int(11) NOT NULL,
  `year` int(11) NOT NULL,
  `participant` int(11) NOT NULL,
  `statusTypeId` int(11) NOT NULL,
  `advisorId` int(11) NOT NULL,
  `timestamp` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  PRIMARY KEY (`activityId`),
  KEY `IX_ActivityInformations_activityTypeId` (`activityTypeId`),
  KEY `IX_ActivityInformations_activityUnitId` (`activityUnitId`),
  KEY `IX_ActivityInformations_advisorId` (`advisorId`),
  KEY `IX_ActivityInformations_statusTypeId` (`statusTypeId`),
  KEY `IX_ActivityInformations_projectLevelId` (`projectLevelId`),
  CONSTRAINT `FK_ActivityInformations_ActivityTypes_activityTypeId` FOREIGN KEY (`activityTypeId`) REFERENCES `activitytypes` (`activityTypeId`) ON DELETE CASCADE,
  CONSTRAINT `FK_ActivityInformations_ActivityUnits_activityUnitId` FOREIGN KEY (`activityUnitId`) REFERENCES `activityunits` (`activityUnitId`) ON DELETE CASCADE,
  CONSTRAINT `FK_ActivityInformations_Advisors_advisorId` FOREIGN KEY (`advisorId`) REFERENCES `advisors` (`advisorId`) ON DELETE CASCADE,
  CONSTRAINT `FK_ActivityInformations_ProjectLevels_projectLevelId` FOREIGN KEY (`projectLevelId`) REFERENCES `projectlevels` (`projectLevelId`) ON DELETE CASCADE,
  CONSTRAINT `FK_ActivityInformations_StatusTypes_statusTypeId` FOREIGN KEY (`statusTypeId`) REFERENCES `statustypes` (`statusTypeId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activityinformations`
--

LOCK TABLES `activityinformations` WRITE;
/*!40000 ALTER TABLE `activityinformations` DISABLE KEYS */;
INSERT INTO `activityinformations` VALUES (30,1,'S2019050001','Best Games',1,1,'2019-05-31 00:00:00.000000','2019-05-31 00:00:00.000000','CL Building',2,2018,100,1,1,'2019-05-31 22:01:29.536726'),(32,1,'S2019050001','Code Camp',1,1,'2019-08-05 00:00:00.000000','2019-05-08 00:00:00.000000','VMS Building',1,2019,50,1,1,'2019-05-31 22:09:29.122841');
/*!40000 ALTER TABLE `activityinformations` ENABLE KEYS */;
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
