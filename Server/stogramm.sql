CREATE DATABASE  IF NOT EXISTS `stogramm` /*!40100 DEFAULT CHARACTER SET utf8mb3 COLLATE utf8mb3_czech_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `stogramm`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: stogramm
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `comments`
--

DROP TABLE IF EXISTS `comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comments` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `postID` int unsigned NOT NULL,
  `text` varchar(500) COLLATE utf8mb3_czech_ci DEFAULT NULL,
  `userID` int unsigned NOT NULL,
  `datetime` datetime(6) DEFAULT NULL,
  `name` varchar(100) COLLATE utf8mb3_czech_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `commentID_UNIQUE` (`Id`),
  KEY `userID_idx` (`userID`),
  KEY `postID_idx` (`postID`),
  CONSTRAINT `post_comID` FOREIGN KEY (`postID`) REFERENCES `posts` (`Id`),
  CONSTRAINT `user_comID` FOREIGN KEY (`userID`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_czech_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comments`
--

LOCK TABLES `comments` WRITE;
/*!40000 ALTER TABLE `comments` DISABLE KEYS */;
INSERT INTO `comments` VALUES (17,79,'Это реально ты?',16,'2022-12-25 09:24:55.206335','KereK DereK'),(18,80,'В личку не писать. Её тут нет',17,'2022-12-25 09:34:31.803984','Анфиса Петрова'),(19,84,'Добавь в ответ плииииииз =3',20,'2022-12-25 09:46:53.572214','=ВанилькА='),(20,81,'Ну можно попробовать... ;)',20,'2022-12-25 09:47:50.714493','=ВанилькА='),(21,80,'Зато в комментарии можно xdd',18,'2022-12-25 09:50:30.538009','ЗаЯц В кЕдАх'),(22,82,'Шило какой же ты крутой в этой шапке',17,'2022-12-25 09:52:15.533472','Анфиса Петрова'),(23,82,'Это ростовая фигура',19,'2022-12-25 09:53:26.016961','Шило'),(24,82,'Блин на фото как будто нет объема',18,'2022-12-25 09:54:32.093499','ЗаЯц В кЕдАх'),(25,82,'Это ростовая фигура',19,'2022-12-25 09:54:48.286016','Шило'),(26,82,'Нереально выглядите',20,'2022-12-25 09:55:19.512214','=ВанилькА='),(27,82,'ЭТО РОСТОВАЯ ФИГУРА',19,'2022-12-25 09:55:38.889970','Шило'),(28,85,'Продам ростовую фигуру Шила кликай профиль!!',18,'2022-12-25 10:01:37.120236','ЗаЯц В кЕдАх');
/*!40000 ALTER TABLE `comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `images`
--

DROP TABLE IF EXISTS `images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `images` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `postID` int unsigned NOT NULL,
  `order` int unsigned DEFAULT NULL,
  `imageURL` varchar(100) COLLATE utf8mb3_czech_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `imageID_UNIQUE` (`Id`),
  KEY `postID_idx` (`postID`),
  CONSTRAINT `post_imID` FOREIGN KEY (`postID`) REFERENCES `posts` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_czech_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `images`
--

LOCK TABLES `images` WRITE;
/*!40000 ALTER TABLE `images` DISABLE KEYS */;
INSERT INTO `images` VALUES (19,77,1,'16_12252022091957.jpg'),(20,78,1,'16_12252022092115.jpg'),(21,79,1,'1_12252022092330.jpg'),(22,80,1,'17_12252022093347.jpg'),(23,81,1,'18_12252022093605.jpg'),(24,82,1,'19_12252022094019.jpg'),(25,83,1,'20_12252022094207.jpg'),(26,84,1,'21_12252022094516.jpg'),(27,85,1,'19_12252022100046.jpg'),(28,86,1,'shilo.jpg');
/*!40000 ALTER TABLE `images` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `likes`
--

DROP TABLE IF EXISTS `likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `likes` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `postID` int unsigned NOT NULL,
  `userID` int unsigned NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `likeID_UNIQUE` (`Id`),
  KEY `userID_idx` (`userID`),
  KEY `post_likesID_idx` (`postID`),
  CONSTRAINT `post_likesID` FOREIGN KEY (`postID`) REFERENCES `posts` (`Id`),
  CONSTRAINT `user_likesID` FOREIGN KEY (`userID`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_czech_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `likes`
--

LOCK TABLES `likes` WRITE;
/*!40000 ALTER TABLE `likes` DISABLE KEYS */;
INSERT INTO `likes` VALUES (30,79,16),(31,84,20),(32,81,20),(33,77,19),(34,78,19),(35,83,18),(36,80,18),(37,84,17),(38,82,17);
/*!40000 ALTER TABLE `likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `posts`
--

DROP TABLE IF EXISTS `posts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `posts` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `text` varchar(1000) COLLATE utf8mb3_czech_ci DEFAULT NULL,
  `datetime` datetime(6) DEFAULT NULL,
  `userID` int unsigned NOT NULL,
  `name` varchar(100) COLLATE utf8mb3_czech_ci NOT NULL,
  `likes_count` int unsigned DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `postID_UNIQUE` (`Id`),
  KEY `userID_idx` (`userID`),
  CONSTRAINT `user_postID` FOREIGN KEY (`userID`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=87 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_czech_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `posts`
--

LOCK TABLES `posts` WRITE;
/*!40000 ALTER TABLE `posts` DISABLE KEYS */;
INSERT INTO `posts` VALUES (73,'Я первый пользователь! Жаль что медаль принял только одну. \nЯ выгляжу так:','2022-11-20 16:36:56.542000',16,'KereK DereK',1),(74,'Не та фотка...','2022-11-20 16:36:56.542000',16,'KereK DereK',1),(75,'Это не смешно','2021-11-23 14:38:40.340000',16,'KereK DereK',1),(76,'Эй','2021-11-23 14:38:34.767000',16,'KereK DereK',1),(77,'Пора добавить файл','2021-11-23 14:38:40.340000',16,'KereK DereK',2),(78,'Алгем..','2021-11-23 14:38:34.767000',16,'KereK DereK',2),(79,'Я админ. Бойся','2022-11-20 16:36:56.542000',1,'Admin',2),(80,'Это мой запасной аккаунт на случай блокировки телехлама. На фото я','2022-12-25 05:32:55.519000',17,'Анфиса Петрова',2),(81,'Йоооооу))) Есть тут кто в кс играет? Зарубимся в 1.6 по старинке.','2022-12-25 05:35:58.243000',18,'ЗаЯц В кЕдАх',2),(82,'Я родился в Москве, в семидесятом.\nНа краю города, моя ростовая фигура\nценится дороже золота. ','2022-12-25 05:40:10.711000',19,'Шило',2),(83,'Я люблю кофе, Нью-Ёрк, и его...','2022-12-25 05:41:45.385000',20,'=ВанилькА=',2),(84,'Как же круто для создателей, что я освещаю своим присутствием эту дыру))','2022-12-25 05:44:31.620000',21,'СтоГраммка',3),(85,'Всем хейтерам моей ростовой фигуры посвящается:\n\nДам по башке-улетишь на горшке.\nВозьму за ручки-закину за тучки.\n\nМораль думайте сами','2022-12-25 06:00:33.867000',19,'Шило',1),(86,'Продам! За подробностями по номеру: 89270052375 ;)','2022-12-25 06:03:04.444000',18,'ЗаЯц В кЕдАх',1);
/*!40000 ALTER TABLE `posts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscriptions`
--

DROP TABLE IF EXISTS `subscriptions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subscriptions` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `UserId` int unsigned NOT NULL,
  `SecondUserID` int unsigned NOT NULL,
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `otheruser_subID_idx` (`SecondUserID`),
  KEY `user_subID_idx` (`UserId`),
  CONSTRAINT `otheruser_subID` FOREIGN KEY (`SecondUserID`) REFERENCES `users` (`Id`),
  CONSTRAINT `user_subID` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_czech_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscriptions`
--

LOCK TABLES `subscriptions` WRITE;
/*!40000 ALTER TABLE `subscriptions` DISABLE KEYS */;
INSERT INTO `subscriptions` VALUES (30,16,1),(32,20,21),(33,20,18),(34,19,16),(35,18,20),(36,18,17),(37,17,21),(38,17,19),(39,18,19);
/*!40000 ALTER TABLE `subscriptions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(45) COLLATE utf8mb3_czech_ci DEFAULT NULL,
  `registrationType` varchar(45) COLLATE utf8mb3_czech_ci DEFAULT NULL,
  `email` varchar(45) COLLATE utf8mb3_czech_ci DEFAULT NULL,
  `passwordHash` varchar(200) COLLATE utf8mb3_czech_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `userID_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_czech_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Admin','1','admin@stogramm','77953994753d89f3h9f98h37v55nc7xm38nc9v34'),(16,'KereK DereK','1','kerekderek1@gmail.com','D65Azk5N3R6SkkmPJGvkpA=='),(17,'Анфиса Петрова','1','anf.petr@yandex.ru','7575738ggsy3k4ggf8dkkd3k43l'),(18,'ЗаЯц В кЕдАх','1','kryt@mail.ru','jh67h54jbh7j3j4b6j37jb6j4b7jnj'),(19,'Шило','1','krvstk@gmail.com','7457yhhvgh38834hf99435h9h3'),(20,'=ВанилькА=','1','vanilla.ice@jojo.su','sdlgykurt8345nx34b623n8x249'),(21,'СтоГраммка','1','zabiv.official@mail.ru','fdgfd230396548xj3k93v4kb3cm');
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

-- Dump completed on 2022-12-25 10:08:42
