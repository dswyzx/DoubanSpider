/*
 Navicat Premium Data Transfer

 Source Server         : mysql127_01
 Source Server Type    : MySQL
 Source Server Version : 50632
 Source Host           : 127.0.0.1:3306
 Source Schema         : douban

 Target Server Type    : MySQL
 Target Server Version : 50632
 File Encoding         : 65001

 Date: 14/07/2020 19:21:48
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for fullpage
-- ----------------------------
DROP TABLE IF EXISTS `fullpage`;
CREATE TABLE `fullpage`  (
  `fullid` bigint(20) NOT NULL,
  `details` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
  `detailstext` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
  `imgs` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `dd` int(255) NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1780 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Compact;

SET FOREIGN_KEY_CHECKS = 1;
