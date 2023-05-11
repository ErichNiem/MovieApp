USE [master]
GO

/****** Object:  Database [MovieApp]    Script Date: 2023/05/11 16:35:00 ******/
CREATE DATABASE [MovieApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MovieApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MovieApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MovieApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MovieApp] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MovieApp] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MovieApp] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MovieApp] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MovieApp] SET ARITHABORT OFF 
GO

ALTER DATABASE [MovieApp] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MovieApp] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MovieApp] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MovieApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MovieApp] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MovieApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MovieApp] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MovieApp] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MovieApp] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MovieApp] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MovieApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MovieApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MovieApp] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MovieApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MovieApp] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MovieApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MovieApp] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MovieApp] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [MovieApp] SET  MULTI_USER 
GO

ALTER DATABASE [MovieApp] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MovieApp] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MovieApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MovieApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MovieApp] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MovieApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [MovieApp] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MovieApp] SET  READ_WRITE 
GO


