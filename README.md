EazySave v3.0

Copyright © 2024 FISA-I 23-26

Auteurs-Contributeurs : RUDONI Antonin, SIMON Thomas, ALI-BEY Oussama, HENQUEZ Enzo.

EazySave est une application permettant de créer la sauvegarde d'éléments de manière totale ou différentielle.

Téléchargement de l'application :
https://github.com/Rudoni/EazySave

Documentation UML :  Doc -> Diagrammes -> Diagrammes UML

----------------------------------------------------------------

Guide d'utilisation :



1. Création d'une sauvegarde


A la création d'une nouvelle sauvegarde, il est nécessaire de renseigner le nom de la sauvegarde, le chemin source du dossier à sauvegarder et le chemin d'emplacement de la future sauvegarde.

Il est possible de choisir entre une sauvegarde totale, qui génèrera la sauvegarde en écrasant les fichiers ayant le même nom, ou une sauvegarde partielle qui génèrera la sauvegarde en écrasant seulement les fichiers plus anciens.

Il est également possible de choisir de chiffrer les fichiers. Il est alors nécessaire de renseigner les extensions de fichier à chiffrer, ainsi qu'une clé de chiffrement utilisée pour ce dernier.

Chaque sauvegarde créée est enregistrée dans un fichier afin de pouvoir être conservée au redémarrage d'EasySave.



2. Lancement d'une sauvegarde


Une liste des sauvegardes créée peut être visualisée et permet de lancer une ou plusieurs sauvegardes à la fois. Chaque sauvegarde peut être démarrée, mise en pause durant son exécution ou annulée.

Chaque sauvegarde exécutée génèrera ou remplira un fichier log journalier ainsi qu'un fichier log en temps réel, enregistrés dans le dossier EasySave se trouvant dans le dossier Roaming de votre machine locale.



3. Paramètres de de l'application


Il est possible de modifier la langue de l'application entre le français et l'anglais, sans avoir à la redémarrer.

Les fichiers logs sont par défaut écrits en format Json, mais il peuvent également être écrits en format Xml en sélectionnant ce format dans les paramètres de l'application.

Il est également possible de renseigner une liste d'extensions de fichiers prioritaires, afin de permettre aux fichiers de ce type d'être sauvegardés en premier lors de chaque sauvegarde.

Afin de ne pas surcharger la mémoire et potentiellement le réseau, une limite de taille de fichiers sauvegardés simultanément peut être mise en place. Cette limite peut être définie dans les paramètres de l'application et met en attente la sauvegarde d'un fichier excédant cette taille si une autre sauvegarde d'un fichier excédant également cette taille est déjà en cours.


----------------------------------------------------------------

Mentions légales 

EasySave Copyright © 2024 FISA-I 23-26
Licence GNU GLP

Aucune donnée personnelle n’est collectée via EazySave.
Les contributeurs déclinent toute responsabilité concernant d'éventuels dommages découlant de l'utilisation de ce logiciel.