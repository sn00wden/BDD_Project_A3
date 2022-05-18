DROP DATABASE IF EXISTS VeloMax;
CREATE DATABASE IF NOT EXISTS VeloMax;
use VeloMax;

CREATE TABLE Bicyclette(
   ID_Bicyclette INT,
   Nom VARCHAR(50) NOT NULL,
   Grandeur VARCHAR(50),
   Prix_Unitaire DECIMAL(15,2) NOT NULL,
   Ligne_Produit VARCHAR(50),
   Stock INT,
   PRIMARY KEY(ID_Bicyclette)
);

INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('101', 'Kilimandjaro', 'Adultes', 569, 'VTT',0);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('102', 'NorthPole', 'Adultes', 329, 'VTT',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('103', 'MontBlanc', 'Jeunes', 399, 'VTT',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('104', 'Hooligan', 'Jeunes', 199, 'Vélo de course',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('105', 'Orléans', 'Hommes', 229, 'Vélo de course',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('106', 'Orléans', 'Dames', 229, 'Vélo de course',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('107', 'BlueJay', 'Hommes', 349, 'Vélo de course',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('108', 'BlueJay', 'Dames', 349, 'Vélo de course',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('109', 'TrailExplorer', 'Filles', 129, 'Classique',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('110', 'TrailExplorer', 'Garçons', 129, 'Classique',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('111', 'NightHawk', 'Jeunes', 189, 'Classique',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('112', 'TierraVerde', 'Hommes', 199, 'Classique',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('113', 'TierraVerde', 'Dames', 199, 'Classique',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('114', 'Mud Zinger I', 'Jeunes', 279, 'BMX',1);
INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`,`Stock`) VALUES ('115', 'Mud Zinger II', 'Adultes', 359, 'BMX',1);

CREATE TABLE Pieces(
   ID_Piece INT,
   Description VARCHAR(50),
   Prix_Unitaire DECIMAL(15,2) NOT NULL,
   Nom_Fournisseur VARCHAR(50),
   Num_Prod_Fournisseur INT NOT NULL,
   Date_Intro_Marche DATE NOT NULL,
   Date_Discontinuation DATE,
   Delai_Approvisionnement INT NOT NULL,
   Stock INT,
   PRIMARY KEY(ID_Piece)
);

INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (1, 'C32', 12.0, 'FournisseurA', 1,'2018-01-22',Null,15,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (2, 'G7', 8.0, 'FournisseurA', 2,'2018-01-22',Null,25,0);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (3, 'S88', 5.0, 'FournisseurC', 1,'2019-03-11',Null,45,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (4, 'R45', 18.0, 'FournisseurB', 1,'2020-07-07',Null,7,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (5, 'F3', 18.0, 'FournisseurB', 1,'2020-07-07',Null,7,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (6, 'DV133', 18.0, 'FournisseurB', 1,'2020-07-07',Null,7,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (7, 'DR56', 18.0, 'FournisseurB', 1,'2020-07-07',Null,7,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (8, 'R46', 18.0, 'FournisseurB', 1,'2020-07-07',Null,7,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (9, 'P12', 18.0, 'FournisseurB', 1,'2020-07-07',Null,7,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (10, 'O2', 18.0, 'FournisseurB', 1,'2020-07-07',Null,7,1);

INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (11, 'C34', 12.0, 'FournisseurA', 1,'2018-01-22',Null,15,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (12, 'DV17', 12.0, 'FournisseurA', 1,'2018-01-22',Null,15,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (13, 'DR87', 12.0, 'FournisseurA', 1,'2018-01-22',Null,15,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (14, 'R48', 12.0, 'FournisseurA', 1,'2018-01-22',Null,15,1);
INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (15, 'R47', 12.0, 'FournisseurA', 1,'2018-01-22',Null,15,1);

INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`, `Stock`) VALUES (16, 'C76', 12.0, 'FournisseurA', 1,'2018-01-22',Null,15,1);


CREATE TABLE Commande(
   ID_Commande INT,
   Date_Commande DATE NOT NULL,
   Adresse VARCHAR(100) NOT NULL,
   Date_Livraison DATE NOT NULL,
   Prix FLOAT,
   PRIMARY KEY(ID_Commande)
);

INSERT INTO `VeloMax`.`Commande` VALUES (1, '2022-05-13', '12 avenue de Verdun', '2022-05-20', 2734);
INSERT INTO `VeloMax`.`Commande` VALUES (2, '2022-05-13', '12 avenue de Verdun', '2022-05-20', 105);
INSERT INTO `VeloMax`.`Commande` VALUES (3, '2022-05-13', '12 avenue de Verdun', '2022-05-20', 601);
INSERT INTO `VeloMax`.`Commande` VALUES (4, '2022-05-13', '12 avenue de Verdun', '2022-05-20', 1071);
INSERT INTO `VeloMax`.`Commande` VALUES (5, '2022-05-13', '12 avenue de Verdun', '2022-05-20', 0);
INSERT INTO `VeloMax`.`Commande` VALUES (6, '2022-05-13', '12 avenue de Verdun', '2022-05-20', 0);
INSERT INTO `VeloMax`.`Commande` VALUES (7, '2022-05-13', '12 avenue de Verdun', '2022-05-20', 0);
INSERT INTO `VeloMax`.`Commande` VALUES (8, '2022-05-13', '12 avenue de Verdun', '2022-05-20', 0);

CREATE TABLE Fournisseur(
   SIRET INT,
   Nom_Entreprise VARCHAR(100) NOT NULL,
   Contact VARCHAR(50) NOT NULL,
   Adresse VARCHAR(100) NOT NULL,
   Libelle INT NOT NULL,
   PRIMARY KEY(SIRET)
);

INSERT INTO `VeloMax`.`Fournisseur` (`SIRET`, `Nom_Entreprise`, `Contact`, `Adresse`, `Libelle`) VALUES (11, 'FournisseurA', 'MonsieurA', 'OuiA', 1);
INSERT INTO `VeloMax`.`Fournisseur` (`SIRET`, `Nom_Entreprise`, `Contact`, `Adresse`, `Libelle`) VALUES (12, 'FournisseurB', 'MonsieurB', 'OuiB', 2);
INSERT INTO `VeloMax`.`Fournisseur` (`SIRET`, `Nom_Entreprise`, `Contact`, `Adresse`, `Libelle`) VALUES (13, 'FournisseurC', 'MonsieurC', 'OuiC', 3);

CREATE TABLE Client_PRO(
	ID_Client_Pro int,
   Nom_Client_Pro VARCHAR(100),
   Adresse VARCHAR(150) NOT NULL,
   Telephone VARCHAR(20) NOT NULL,
   Courriel VARCHAR(100) NOT NULL,
   Remise INT,
   PRIMARY KEY(ID_Client_Pro)
);

INSERT INTO `VeloMax`.`Client_PRO` (`ID_Client_Pro`,`Nom_Client_Pro`, `Adresse`, `Telephone`, `Courriel`, `Remise`) VALUES (1,'FNAC', 'LaDéf', '06 12', 'Oui ouiA', 0);
INSERT INTO `VeloMax`.`Client_PRO` (`ID_Client_Pro`,`Nom_Client_Pro`, `Adresse`, `Telephone`, `Courriel`, `Remise`) VALUES (2,'DVIC', 'Pôle', '06 40', 'Oui ouiB', 10);
INSERT INTO `VeloMax`.`Client_PRO` (`ID_Client_Pro`,`Nom_Client_Pro`, `Adresse`, `Telephone`, `Courriel`, `Remise`) VALUES (3,'DARTY', 'Boulogne', '06 39', 'Oui ouiC',Null);
INSERT INTO `VeloMax`.`Client_PRO` (`ID_Client_Pro`,`Nom_Client_Pro`, `Adresse`, `Telephone`, `Courriel`, `Remise`) VALUES (4,'DECATHLON', 'Montesson', '06 11', 'Oui ouiD', 5);


CREATE TABLE Client_Individuel(
	ID_Client_Individuel int NOT NULL,
   Nom_Client_Individuel VARCHAR(100),
   Prenom VARCHAR(100) NOT NULL,
   Adresse VARCHAR(150) NOT NULL,
   Telephone VARCHAR(20) NOT NULL,
   Courriel VARCHAR(100) NOT NULL,
   Numero_Programme INT,
   Date_Adhesion Date,
   PRIMARY KEY(ID_Client_Individuel)
);

INSERT INTO `VeloMax`.`Client_Individuel` (`ID_Client_Individuel`,`Nom_Client_Individuel`, `Prenom`,`Adresse`,`Telephone`, `Courriel`, `Numero_Programme`,`Date_Adhesion`) VALUES (1,'SEGUI', 'Matthieu','Boulogne', '06 11', 'Oui ouiAA', 2,'2018-05-05');
INSERT INTO `VeloMax`.`Client_Individuel` (`ID_Client_Individuel`,`Nom_Client_Individuel`, `Prenom`,`Adresse`,`Telephone`, `Courriel`, `Numero_Programme`,`Date_Adhesion`) VALUES (2,'RAULIN', 'Antoine','Carriere' ,'06 12', 'Oui ouiBB',1, '2018-05-05');
INSERT INTO `VeloMax`.`Client_Individuel` (`ID_Client_Individuel`,`Nom_Client_Individuel`, `Prenom`,`Adresse`,`Telephone`, `Courriel`, `Numero_Programme`,`Date_Adhesion`) VALUES (3,'SCHNEEGANS', 'Hugo','Croissy','06 13', 'Oui ouiCC',2,'2018-05-05');
INSERT INTO `VeloMax`.`Client_Individuel` (`ID_Client_Individuel`,`Nom_Client_Individuel`, `Prenom`,`Adresse`,`Telephone`, `Courriel`, `Numero_Programme`,`Date_Adhesion`) VALUES (4,'DVB', 'Hortense','Jen sais rien', '06 14', 'Oui ouiDD',1,'2018-05-05');
INSERT INTO `VeloMax`.`Client_Individuel` (`ID_Client_Individuel`,`Nom_Client_Individuel`, `Prenom`,`Adresse`,`Telephone`, `Courriel`, `Numero_Programme`,`Date_Adhesion`) VALUES (5,'KEV', 'Fabien','Boulogne', '06 11', 'Oui ouiAA', 2,'2018-05-05');
INSERT INTO `VeloMax`.`Client_Individuel` (`ID_Client_Individuel`,`Nom_Client_Individuel`, `Prenom`,`Adresse`,`Telephone`, `Courriel`, `Numero_Programme`,`Date_Adhesion`) VALUES (6,'RIME', 'Fabienne','Carriere' ,'06 12', 'Oui ouiBB', 3,'2018-05-05');
INSERT INTO `VeloMax`.`Client_Individuel` (`ID_Client_Individuel`,`Nom_Client_Individuel`, `Prenom`,`Adresse`,`Telephone`, `Courriel`, `Numero_Programme`,`Date_Adhesion`) VALUES (7,'PRUNEL', 'Lionel','Croissy','06 13', 'Oui ouiCC',1,'2018-05-05');
INSERT INTO `VeloMax`.`Client_Individuel` (`ID_Client_Individuel`,`Nom_Client_Individuel`, `Prenom`,`Adresse`,`Telephone`, `Courriel`, `Numero_Programme`,`Date_Adhesion`) VALUES (8,'SOLUTION', 'Ionelle','Jen sais rien', '06 14', 'Oui ouiDD',4,'2018-05-05');

CREATE TABLE Fidelio(
   No_Programme INT,
   Description VARCHAR(50),
   Cout INT,
   Duree INT,
   Rabais INT,
   PRIMARY KEY(No_Programme)
);

INSERT INTO `VeloMax`.`Fidelio` (`No_Programme`, `Description`, `Cout`, `Duree`, `Rabais`) VALUES ('1', 'Fidelio', 15, 1, 5);
INSERT INTO `VeloMax`.`Fidelio` (`No_Programme`, `Description`, `Cout`, `Duree`, `Rabais`) VALUES ('2', 'Fidelio Or', 25, 2, 8);
INSERT INTO `VeloMax`.`Fidelio` (`No_Programme`, `Description`, `Cout`, `Duree`, `Rabais`) VALUES ('3', 'Fidelio Platine', 60, 2, 8);
INSERT INTO `VeloMax`.`Fidelio` (`No_Programme`, `Description`, `Cout`, `Duree`, `Rabais`) VALUES ('4', 'Fidelio Max', 100, 3, 12);

CREATE TABLE Construire(
   ID_Bicyclette INT,
   ID_Piece INT,
   PRIMARY KEY(ID_Bicyclette, ID_Piece),
   FOREIGN KEY(ID_Bicyclette) REFERENCES Bicyclette(ID_Bicyclette),
   FOREIGN KEY(ID_Piece) REFERENCES Pieces(ID_Piece)
   on update cascade on delete cascade
);
CREATE TABLE Contenir_bicyclette(
   ID_Bicyclette INT,
   ID_Commande INT,
   Quantite INT,
   PRIMARY KEY(ID_Bicyclette, ID_Commande),
   FOREIGN KEY(ID_Bicyclette) REFERENCES Bicyclette(ID_Bicyclette),
   FOREIGN KEY(ID_Commande) REFERENCES Commande(ID_Commande)
   on update cascade on delete cascade
);

INSERT INTO `VeloMax`.`Contenir_bicyclette` VALUES (101,1,2);
INSERT INTO `VeloMax`.`Contenir_bicyclette` VALUES (103,1,4);
INSERT INTO `VeloMax`.`Contenir_bicyclette` VALUES (101,3,1);

INSERT INTO `VeloMax`.`Contenir_bicyclette` VALUES (105,4,1);
INSERT INTO `VeloMax`.`Contenir_bicyclette` VALUES (107,4,1);
INSERT INTO `VeloMax`.`Contenir_bicyclette` VALUES (108,4,1);

CREATE TABLE Contenir_pieces(
   ID_Piece INT,
   ID_Commande INT,
   Quantite INT,
   PRIMARY KEY(ID_Piece, ID_Commande),
	CONSTRAINT  FOREIGN KEY(ID_Piece) REFERENCES Pieces(ID_Piece)
    on update cascade on delete cascade,

   constraint  FOREIGN KEY(ID_Commande) REFERENCES Commande(ID_Commande)
   on update cascade on delete cascade
);

INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (1,2,4);
INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (2,2,2);
INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (3,2,1);
INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (4,2,2);

INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (2,3,1);
INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (1,3,2);

INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (8,4,1);
INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (14,4,2);
INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (7,4,3);
INSERT INTO `VeloMax`.`Contenir_pieces` VALUES (11,4,4);

CREATE TABLE Fournir(
   ID_Piece INT,
   SIRET INT,
   PRIMARY KEY(ID_Piece, SIRET),
   constraint FOREIGN KEY(ID_Piece) REFERENCES Pieces(ID_Piece)
   on update cascade on delete cascade,
   
   constraint foreign key(SIRET) REFERENCES Fournisseur(SIRET)
	on update cascade on delete cascade
);

INSERT INTO `VeloMax`.`Fournir` VALUES (1,11);
INSERT INTO `VeloMax`.`Fournir` VALUES (2,12);
INSERT INTO `VeloMax`.`Fournir` VALUES (3,13);

CREATE TABLE Commander_PRO(
   ID_Commande INT,
   ID_Client_Pro int,
   PRIMARY KEY(ID_Commande, ID_Client_Pro),
   constraint foreign key(ID_Commande) REFERENCES Commande(ID_Commande)
   on update cascade on delete cascade,
   Constraint FOREIGN KEY(ID_Client_Pro) REFERENCES Client_PRO(ID_Client_Pro)
   on update cascade on delete cascade
   
);

INSERT INTO `VeloMax`.`Commander_PRO` VALUES (5,1);
INSERT INTO `VeloMax`.`Commander_PRO` VALUES (6,2);
INSERT INTO `VeloMax`.`Commander_PRO` VALUES (3,3);
INSERT INTO `VeloMax`.`Commander_PRO` VALUES (4,4);

CREATE TABLE Commander_INDIVIDUEL(
   ID_Commande INT,
   ID_Client_Individuel int,
   PRIMARY KEY(ID_Commande, ID_Client_Individuel),
   constraint FOREIGN KEY(ID_Commande) REFERENCES Commande(ID_Commande)
   on update cascade on delete cascade,
   
   constraint FOREIGN KEY(ID_Client_Individuel) REFERENCES Client_Individuel(ID_Client_Individuel)
   on update cascade on delete cascade
);

INSERT INTO `VeloMax`.`Commander_INDIVIDUEL` VALUES (1,1);
INSERT INTO `VeloMax`.`Commander_INDIVIDUEL` VALUES (2,2);
INSERT INTO `VeloMax`.`Commander_INDIVIDUEL` VALUES (7,3);
INSERT INTO `VeloMax`.`Commander_INDIVIDUEL` VALUES (8,4);

CREATE TABLE Souscrit(
   ID_Client_Individuel int,
   No_Programme INT,
   PRIMARY KEY(ID_Client_Individuel, No_Programme),
   constraint FOREIGN KEY(ID_Client_Individuel) REFERENCES Client_Individuel(ID_Client_Individuel)
   on update cascade on delete cascade,
   constraint FOREIGN KEY(No_Programme) REFERENCES Fidelio(No_Programme)
   on update cascade on delete cascade
);  

INSERT INTO `VeloMax`.`Souscrit` VALUES (1,2);
INSERT INTO `VeloMax`.`Souscrit` VALUES (2,1);
INSERT INTO `VeloMax`.`Souscrit` VALUES (3,2);
INSERT INTO `VeloMax`.`Souscrit` VALUES (8,4);
INSERT INTO `VeloMax`.`Souscrit` VALUES (4,1);
INSERT INTO `VeloMax`.`Souscrit` VALUES (5,2);
INSERT INTO `VeloMax`.`Souscrit` VALUES (6,3);
INSERT INTO `VeloMax`.`Souscrit` VALUES (7,1);

INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,1);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,2);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,3);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,4);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,5);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,6);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,7);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,8);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,9);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (101,10);

INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,11);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,12);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,13);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,14);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,15);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,2);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,3);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,5);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (102,9);

INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,12);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,13);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,14);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,15);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,16);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,3);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,5);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,9);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,10);
INSERT INTO `VeloMax`.`Construire` (`ID_Bicyclette`,`ID_Piece`) VALUES (103,2);