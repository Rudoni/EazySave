EazySave v3.0

Copyright � 2024 FISA-I 23-26

Auteurs-Contributeurs : RUDONI Antonin, SIMON Thomas, ALI-BEY Oussama, HENQUEZ Enzo.

EazySave est une application permettant de cr�er la sauvegarde d'�l�ments de mani�re totale ou diff�rentielle.

T�l�chargement de l'application :
https://github.com/Rudoni/EazySave

Documentation UML :  Doc -> Diagrammes -> Diagrammes UML

----------------------------------------------------------------

Guide d'utilisation :



1. Cr�ation d'une sauvegarde


A la cr�ation d'une nouvelle sauvegarde, il est n�cessaire de renseigner le nom de la sauvegarde, le chemin source du dossier � sauvegarder et le chemin d'emplacement de la future sauvegarde.

Il est possible de choisir entre une sauvegarde totale, qui g�n�rera la sauvegarde en �crasant les fichiers ayant le m�me nom, ou une sauvegarde partielle qui g�n�rera la sauvegarde en �crasant seulement les fichiers plus anciens.

Il est �galement possible de choisir de chiffrer les fichiers. Il est alors n�cessaire de renseigner les extensions de fichier � chiffrer, ainsi qu'une cl� de chiffrement utilis�e pour ce dernier.

Chaque sauvegarde cr��e est enregistr�e dans un fichier afin de pouvoir �tre conserv�e au red�marrage d'EasySave.



2. Lancement d'une sauvegarde


Une liste des sauvegardes cr��e peut �tre visualis�e et permet de lancer une ou plusieurs sauvegardes � la fois. Chaque sauvegarde peut �tre d�marr�e, mise en pause durant son ex�cution ou annul�e.

Chaque sauvegarde ex�cut�e g�n�rera ou remplira un fichier log journalier ainsi qu'un fichier log en temps r�el, enregistr�s dans le dossier EasySave se trouvant dans le dossier Roaming de votre machine locale.



3. Param�tres de de l'application


Il est possible de modifier la langue de l'application entre le fran�ais et l'anglais, sans avoir � la red�marrer.

Les fichiers logs sont par d�faut �crits en format Json, mais il peuvent �galement �tre �crits en format Xml en s�lectionnant ce format dans les param�tres de l'application.

Il est �galement possible de renseigner une liste d'extensions de fichiers prioritaires, afin de permettre aux fichiers de ce type d'�tre sauvegard�s en premier lors de chaque sauvegarde.

Afin de ne pas surcharger la m�moire et potentiellement le r�seau, une limite de taille de fichiers sauvegard�s simultan�ment peut �tre mise en place. Cette limite peut �tre d�finie dans les param�tres de l'application et met en attente la sauvegarde d'un fichier exc�dant cette taille si une autre sauvegarde d'un fichier exc�dant �galement cette taille est d�j� en cours.


----------------------------------------------------------------

Mentions l�gales 

EasySave Copyright � 2024 FISA-I 23-26
Licence GNU GLP

Aucune donn�e personnelle n�est collect�e via EazySave.
Les contributeurs d�clinent toute responsabilit� concernant d'�ventuels dommages d�coulant de l'utilisation de ce logiciel.