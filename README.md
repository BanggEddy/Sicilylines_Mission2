# Sicilylines

Sicilylines est un projet en C# conçu pour gérer les traversées en ferry et les données associées. Il se compose de quatre composants principaux :

- **DAL (Couche d'Accès aux Données) :** Responsable de l'interaction avec la base de données.
- **Modèle :** Définit la structure des données utilisées dans l'application.
- **Vue :** Gère la couche de présentation, généralement associée aux composants d'interface utilisateur.
- **Contrôleur :** Gère la logique de l'application et agit comme un intermédiaire entre le modèle et la vue.

## Prérequis

Avant d'exécuter Sicilylines, assurez-vous de disposer des éléments suivants :

- **Base de données MySQL :** Assurez-vous d'avoir MySQL installé et en cours d'exécution.
- **Visual Studio :** Ce projet est développé en utilisant C# dans Visual Studio.

## Installation

1. Clonez le dépôt sur votre machine locale.
2. Ouvrez le projet dans Visual Studio.
3. Configurez la base de données MySQL avec les configurations appropriées.
4. Compilez et exécutez le projet.

## Utilisation

Le projet Sicilylines offre les fonctionnalités suivantes :

### Gestion des Liaisons (Ferry Connections)

- Ajout, suppression et modification des liaisons entre les ports.
- Affichage des liaisons existantes pour un secteur donné.

### Gestion des Ports

- Affichage de la liste des ports disponibles.

### Gestion des Secteurs

- Ajout, suppression et modification des secteurs géographiques.
- Affichage de la liste des secteurs disponibles.

### Gestion des Traversées (Crossings)

- Affichage des traversées associées à une liaison spécifique.

## Screenshot

![Capture d'écran 2023-07-06 231429](https://github.com/BanggEddy/Sicilylines_Mission2/assets/108392457/2a850189-9a76-4135-bbe4-e240fc100e0c)

## Licence

Ce projet est sous licence [MIT](LICENSE).


