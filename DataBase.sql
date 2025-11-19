-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: foodmemory
-- ------------------------------------------------------
-- Server version	8.0.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `chefs`
--

DROP TABLE IF EXISTS `chefs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chefs` (
  `chef_id` int NOT NULL AUTO_INCREMENT,
  `fullName` varchar(45) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(45) NOT NULL,
  `phoneNumber` varchar(45) NOT NULL,
  `experienceYears` int DEFAULT NULL,
  `bio` text,
  `rating` int DEFAULT NULL,
  PRIMARY KEY (`chef_id`),
  CONSTRAINT `IDchef` FOREIGN KEY (`chef_id`) REFERENCES `users` (`idUsers`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chefs`
--

LOCK TABLES `chefs` WRITE;
/*!40000 ALTER TABLE `chefs` DISABLE KEYS */;
/*!40000 ALTER TABLE `chefs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredients` (
  `idIngredients` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idIngredients`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meals`
--

DROP TABLE IF EXISTS `meals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `meals` (
  `idMeals` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`idMeals`),
  KEY `USERid_idx` (`user_id`),
  CONSTRAINT `USERid` FOREIGN KEY (`user_id`) REFERENCES `users` (`idUsers`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meals`
--

LOCK TABLES `meals` WRITE;
/*!40000 ALTER TABLE `meals` DISABLE KEYS */;
/*!40000 ALTER TABLE `meals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `idOrders` int NOT NULL AUTO_INCREMENT,
  `customer_id` int NOT NULL,
  `chef_id` int NOT NULL,
  `meal_id` int NOT NULL,
  `order_date` datetime NOT NULL,
  `address` varchar(100) NOT NULL,
  PRIMARY KEY (`idOrders`),
  KEY `customerID_idx` (`customer_id`),
  KEY `chefID_idx` (`chef_id`),
  KEY `mealID_idx` (`meal_id`),
  CONSTRAINT `chefID` FOREIGN KEY (`chef_id`) REFERENCES `users` (`idUsers`) ON DELETE CASCADE,
  CONSTRAINT `customerID` FOREIGN KEY (`customer_id`) REFERENCES `users` (`idUsers`) ON DELETE CASCADE,
  CONSTRAINT `mealID` FOREIGN KEY (`meal_id`) REFERENCES `meals` (`idMeals`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_ingredients`
--

DROP TABLE IF EXISTS `recipe_ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe_ingredients` (
  `recipe_id` int NOT NULL,
  `ingredient_id` int NOT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `Size` varchar(45) NOT NULL,
  PRIMARY KEY (`recipe_id`,`ingredient_id`),
  KEY `INGREDIENTid_idx` (`ingredient_id`),
  CONSTRAINT `INGREDIENTid` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`idIngredients`) ON DELETE CASCADE,
  CONSTRAINT `rECIPEiD` FOREIGN KEY (`recipe_id`) REFERENCES `recipes` (`idRecipes`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_ingredients`
--

LOCK TABLES `recipe_ingredients` WRITE;
/*!40000 ALTER TABLE `recipe_ingredients` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipe_ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipes`
--

DROP TABLE IF EXISTS `recipes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipes` (
  `idRecipes` int NOT NULL AUTO_INCREMENT,
  `user ID` int NOT NULL,
  `name` varchar(45) NOT NULL,
  `prep_time` int DEFAULT NULL,
  PRIMARY KEY (`idRecipes`),
  KEY `ID_idx` (`user ID`),
  CONSTRAINT `ID` FOREIGN KEY (`user ID`) REFERENCES `users` (`idUsers`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipes`
--

LOCK TABLES `recipes` WRITE;
/*!40000 ALTER TABLE `recipes` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `idUsers` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(45) NOT NULL,
  `lastname` varchar(45) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(45) NOT NULL,
  `IsAdmin` int DEFAULT '0',
  `profilepic` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idUsers`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Gadi','Herman','gadih@gmail.com','gadi1',0,'gadi.jpg'),(2,'Mishel','Dekin','misheld@gmail.com','mishel123',1,'mishel.png'),(3,'Dana','Levi','dana.levi@gmail.com','dana456',0,NULL),(4,'Eitan','Cohen','eitan.cohen@gmail.com','eitan789',0,'eitan.jpeg'),(5,'Noa','Ben Ami','noa.benami@gmail.com','noa321',0,'noa.jpg'),(6,'Tom','Shalev','tom.shalev@gmail.com','tom999',0,NULL),(7,'Lior','Mizrahi','lior.mizrahi@gmail.com','lior2025',0,'lior.png'),(8,'Roni','Katz','roni.katz@gmail.com','roni55',0,'roni.jpeg'),(9,'Neta','Bar','neta.bar@gmail.com','neta1234',0,'neta.jpg'),(10,'Amit','Peretz','amit.peretz@gmail.com','amit888',0,'amit.png'),(11,'Tali','Cohen','tali.cohen@gmail.com','tali123',0,'tali.jpg'),(12,'Sophia','Banks','bank@gmail.com','banks1',0,NULL),(13,'שחר','הרטשטיין','shahar12@icloud.com','shahar12345',0,NULL),(14,'josh','rog','joshrog17','joshrog17',0,NULL),(15,'Tal','Morer','TalM@icloud.com','TalM12345',0,NULL),(16,'Poo','Koo','PooKoopooo@gmail.com','12345mishkastemi',0,NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-29 11:52:08
