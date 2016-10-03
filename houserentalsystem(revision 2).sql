-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: houserentalsystem
-- ------------------------------------------------------
-- Server version	5.7.10-log

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
-- Temporary view structure for view `billinginformation_v`
--

DROP TABLE IF EXISTS `billinginformation_v`;
/*!50001 DROP VIEW IF EXISTS `billinginformation_v`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `billinginformation_v` AS SELECT 
 1 AS `Billing ID`,
 1 AS `House ID`,
 1 AS `House Address`,
 1 AS `Rent Amount`,
 1 AS `Rent Due date`,
 1 AS `Electric bill amount`,
 1 AS `Electric bill date`,
 1 AS `Electric bill due date`,
 1 AS `Total(kwh)`,
 1 AS `Water bill amount`,
 1 AS `Water bill date`,
 1 AS `Water bill due date`,
 1 AS `Water bill consumption`,
 1 AS `Total`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `rental_v`
--

DROP TABLE IF EXISTS `rental_v`;
/*!50001 DROP VIEW IF EXISTS `rental_v`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `rental_v` AS SELECT 
 1 AS `Tenant ID`,
 1 AS `Name`,
 1 AS `House ID`,
 1 AS `Address`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `tbl_billinginfo`
--

DROP TABLE IF EXISTS `tbl_billinginfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_billinginfo` (
  `id` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `electricbill` int(10) unsigned zerofill DEFAULT NULL,
  `waterbill` int(10) unsigned zerofill DEFAULT NULL,
  `rentalbill` int(10) unsigned zerofill NOT NULL,
  `houseid` int(10) unsigned zerofill NOT NULL,
  PRIMARY KEY (`id`),
  KEY `electricbill_fk_idx` (`electricbill`),
  KEY `waterbill_fk_idx` (`waterbill`),
  KEY `rentbill_fk_idx` (`rentalbill`),
  KEY `house_fk_idx` (`id`),
  KEY `house_fk_idx1` (`houseid`),
  CONSTRAINT `electricbill_fk` FOREIGN KEY (`electricbill`) REFERENCES `tbl_electricbillinfo` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `house_fk` FOREIGN KEY (`houseid`) REFERENCES `tbl_rent` (`house_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `rentbill_fk` FOREIGN KEY (`rentalbill`) REFERENCES `tbl_rentalbillinfo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `waterbill_fk` FOREIGN KEY (`waterbill`) REFERENCES `tbl_waterbillinfo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_billinginfo`
--

LOCK TABLES `tbl_billinginfo` WRITE;
/*!40000 ALTER TABLE `tbl_billinginfo` DISABLE KEYS */;
INSERT INTO `tbl_billinginfo` VALUES (0000000001,0000000001,0000000001,0000000001,0000000001),(0000000002,0000000002,0000000002,0000000002,0000000001);
/*!40000 ALTER TABLE `tbl_billinginfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_electricbillinfo`
--

DROP TABLE IF EXISTS `tbl_electricbillinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_electricbillinfo` (
  `id` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `billdate` datetime DEFAULT NULL,
  `duedate` datetime DEFAULT NULL,
  `total_kwh` varchar(45) DEFAULT NULL,
  `amount` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_electricbillinfo`
--

LOCK TABLES `tbl_electricbillinfo` WRITE;
/*!40000 ALTER TABLE `tbl_electricbillinfo` DISABLE KEYS */;
INSERT INTO `tbl_electricbillinfo` VALUES (0000000001,'2016-10-03 00:00:00','2016-10-03 00:00:00','200',5000),(0000000002,'2016-10-03 00:00:00','2016-10-03 00:00:00','200',5000);
/*!40000 ALTER TABLE `tbl_electricbillinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_housedesc`
--

DROP TABLE IF EXISTS `tbl_housedesc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_housedesc` (
  `id` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `bedroomno` int(11) NOT NULL,
  `kitchenno` int(11) NOT NULL,
  `bathroomno` int(11) NOT NULL,
  `livingroomno` int(11) NOT NULL,
  `toiletno` int(11) NOT NULL,
  `terraceno` int(11) NOT NULL,
  `address` varchar(200) NOT NULL,
  `image` varchar(200) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL COMMENT 'UNDERMAINTENANCE,FREE,RENTED',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_housedesc`
--

LOCK TABLES `tbl_housedesc` WRITE;
/*!40000 ALTER TABLE `tbl_housedesc` DISABLE KEYS */;
INSERT INTO `tbl_housedesc` VALUES (0000000001,0,0,0,0,0,0,'St. Peter street','C:/Users/Zero/Pictures/Room/download (6).jpg','F');
/*!40000 ALTER TABLE `tbl_housedesc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_personalinfo`
--

DROP TABLE IF EXISTS `tbl_personalinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_personalinfo` (
  `id` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `lname` varchar(30) NOT NULL,
  `fname` varchar(30) NOT NULL,
  `mname` varchar(30) NOT NULL,
  `birthdate` date NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `cellno` varchar(11) DEFAULT NULL,
  `gender` varchar(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_personalinfo`
--

LOCK TABLES `tbl_personalinfo` WRITE;
/*!40000 ALTER TABLE `tbl_personalinfo` DISABLE KEYS */;
INSERT INTO `tbl_personalinfo` VALUES (0000000001,'Huerte','Gabriel Jay','Badiang','2016-10-03','gjhuerte@gmail.com','09429481398','M');
/*!40000 ALTER TABLE `tbl_personalinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_rent`
--

DROP TABLE IF EXISTS `tbl_rent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_rent` (
  `tenant_id` int(10) unsigned zerofill NOT NULL,
  `house_id` int(10) unsigned zerofill NOT NULL,
  `rent_day` datetime NOT NULL,
  `paymenttype` varchar(45) NOT NULL COMMENT 'MONTHLY,WEEKLY',
  `advancepayment` int(11) DEFAULT NULL,
  PRIMARY KEY (`tenant_id`,`house_id`),
  KEY `tenant_fk_idx` (`tenant_id`),
  KEY `houserent_fk_idx` (`house_id`),
  CONSTRAINT `houserent_fk` FOREIGN KEY (`house_id`) REFERENCES `tbl_housedesc` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `tenantrent_fk` FOREIGN KEY (`tenant_id`) REFERENCES `tbl_tenant` (`personid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rent`
--

LOCK TABLES `tbl_rent` WRITE;
/*!40000 ALTER TABLE `tbl_rent` DISABLE KEYS */;
INSERT INTO `tbl_rent` VALUES (0000000001,0000000001,'2016-10-03 00:51:02','Monthly',5000);
/*!40000 ALTER TABLE `tbl_rent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_rentalbillinfo`
--

DROP TABLE IF EXISTS `tbl_rentalbillinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_rentalbillinfo` (
  `id` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `amount` int(10) unsigned zerofill NOT NULL,
  `duedate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rentalbillinfo`
--

LOCK TABLES `tbl_rentalbillinfo` WRITE;
/*!40000 ALTER TABLE `tbl_rentalbillinfo` DISABLE KEYS */;
INSERT INTO `tbl_rentalbillinfo` VALUES (0000000001,0000002000,'2016-10-03 00:00:00'),(0000000002,0000005000,'2016-10-03 00:00:00');
/*!40000 ALTER TABLE `tbl_rentalbillinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_tenant`
--

DROP TABLE IF EXISTS `tbl_tenant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_tenant` (
  `personid` int(10) unsigned zerofill NOT NULL,
  PRIMARY KEY (`personid`),
  CONSTRAINT `tenant_fk` FOREIGN KEY (`personid`) REFERENCES `tbl_personalinfo` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_tenant`
--

LOCK TABLES `tbl_tenant` WRITE;
/*!40000 ALTER TABLE `tbl_tenant` DISABLE KEYS */;
INSERT INTO `tbl_tenant` VALUES (0000000001);
/*!40000 ALTER TABLE `tbl_tenant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_transactionhistory`
--

DROP TABLE IF EXISTS `tbl_transactionhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_transactionhistory` (
  `id` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `payer` varchar(45) DEFAULT NULL,
  `billingid` int(10) unsigned zerofill NOT NULL,
  `date` datetime DEFAULT NULL,
  `amount` int(11) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL COMMENT 'FULL,PARTIAL',
  PRIMARY KEY (`id`),
  KEY `billingid_fk_idx` (`billingid`),
  CONSTRAINT `billingid_fk` FOREIGN KEY (`billingid`) REFERENCES `tbl_billinginfo` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_transactionhistory`
--

LOCK TABLES `tbl_transactionhistory` WRITE;
/*!40000 ALTER TABLE `tbl_transactionhistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_transactionhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_user`
--

DROP TABLE IF EXISTS `tbl_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_user` (
  `username` varchar(30) NOT NULL,
  `password` varchar(45) NOT NULL,
  `userinfo` int(10) unsigned zerofill NOT NULL,
  `type` varchar(10) NOT NULL,
  PRIMARY KEY (`username`),
  KEY `id_fk_idx` (`userinfo`),
  CONSTRAINT `personinfo_fk` FOREIGN KEY (`userinfo`) REFERENCES `tbl_personalinfo` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_user`
--

LOCK TABLES `tbl_user` WRITE;
/*!40000 ALTER TABLE `tbl_user` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_userlog`
--

DROP TABLE IF EXISTS `tbl_userlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_userlog` (
  `username` varchar(30) NOT NULL,
  `login` datetime NOT NULL,
  `logout` datetime NOT NULL,
  KEY `username_fk_idx` (`username`),
  CONSTRAINT `username_fk` FOREIGN KEY (`username`) REFERENCES `tbl_user` (`username`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_userlog`
--

LOCK TABLES `tbl_userlog` WRITE;
/*!40000 ALTER TABLE `tbl_userlog` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_userlog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_waterbillinfo`
--

DROP TABLE IF EXISTS `tbl_waterbillinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_waterbillinfo` (
  `id` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `billdate` datetime NOT NULL,
  `consumption` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `duedate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_waterbillinfo`
--

LOCK TABLES `tbl_waterbillinfo` WRITE;
/*!40000 ALTER TABLE `tbl_waterbillinfo` DISABLE KEYS */;
INSERT INTO `tbl_waterbillinfo` VALUES (0000000001,'2016-10-03 00:00:00',500,1000,'2016-10-03 00:00:00'),(0000000002,'2016-10-03 00:00:00',200,5000,'2016-10-03 00:00:00');
/*!40000 ALTER TABLE `tbl_waterbillinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `tenant_v`
--

DROP TABLE IF EXISTS `tenant_v`;
/*!50001 DROP VIEW IF EXISTS `tenant_v`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `tenant_v` AS SELECT 
 1 AS `id`,
 1 AS `lname`,
 1 AS `fname`,
 1 AS `mname`,
 1 AS `birthdate`,
 1 AS `email`,
 1 AS `cellno`,
 1 AS `gender`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'houserentalsystem'
--

--
-- Final view structure for view `billinginformation_v`
--

/*!50001 DROP VIEW IF EXISTS `billinginformation_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `billinginformation_v` AS select `tbl_billinginfo`.`id` AS `Billing ID`,`tbl_housedesc`.`id` AS `House ID`,`tbl_housedesc`.`address` AS `House Address`,`tbl_rentalbillinfo`.`amount` AS `Rent Amount`,`tbl_rentalbillinfo`.`duedate` AS `Rent Due date`,`tbl_electricbillinfo`.`amount` AS `Electric bill amount`,`tbl_electricbillinfo`.`billdate` AS `Electric bill date`,`tbl_electricbillinfo`.`duedate` AS `Electric bill due date`,`tbl_electricbillinfo`.`total_kwh` AS `Total(kwh)`,`tbl_waterbillinfo`.`amount` AS `Water bill amount`,`tbl_waterbillinfo`.`billdate` AS `Water bill date`,`tbl_waterbillinfo`.`duedate` AS `Water bill due date`,`tbl_waterbillinfo`.`consumption` AS `Water bill consumption`,sum(((`tbl_rentalbillinfo`.`amount` + `tbl_electricbillinfo`.`amount`) + `tbl_waterbillinfo`.`amount`)) AS `Total` from ((((`tbl_billinginfo` join `tbl_rentalbillinfo` on((`tbl_billinginfo`.`rentalbill` = `tbl_rentalbillinfo`.`id`))) join `tbl_electricbillinfo` on((`tbl_billinginfo`.`electricbill` = `tbl_electricbillinfo`.`id`))) join `tbl_waterbillinfo` on((`tbl_billinginfo`.`waterbill` = `tbl_waterbillinfo`.`id`))) join `tbl_housedesc` on((`tbl_billinginfo`.`houseid` = `tbl_housedesc`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `rental_v`
--

/*!50001 DROP VIEW IF EXISTS `rental_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `rental_v` AS select `tbl_rent`.`tenant_id` AS `Tenant ID`,concat(`tbl_personalinfo`.`lname`,', ',`tbl_personalinfo`.`fname`,' ',`tbl_personalinfo`.`mname`) AS `Name`,`tbl_rent`.`house_id` AS `House ID`,`tbl_housedesc`.`address` AS `Address` from (((`tbl_rent` join `tbl_tenant` on((`tbl_rent`.`tenant_id` = `tbl_tenant`.`personid`))) join `tbl_personalinfo` on((`tbl_tenant`.`personid` = `tbl_personalinfo`.`id`))) join `tbl_housedesc` on((`tbl_rent`.`house_id` = `tbl_housedesc`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `tenant_v`
--

/*!50001 DROP VIEW IF EXISTS `tenant_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `tenant_v` AS select `tbl_personalinfo`.`id` AS `id`,`tbl_personalinfo`.`lname` AS `lname`,`tbl_personalinfo`.`fname` AS `fname`,`tbl_personalinfo`.`mname` AS `mname`,date_format(`tbl_personalinfo`.`birthdate`,'%M %d %Y') AS `birthdate`,`tbl_personalinfo`.`email` AS `email`,`tbl_personalinfo`.`cellno` AS `cellno`,`tbl_personalinfo`.`gender` AS `gender` from (`tbl_tenant` join `tbl_personalinfo` on((`tbl_tenant`.`personid` = `tbl_personalinfo`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-10-03 15:33:22
