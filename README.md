
# 🗂️ Gestionnaire de Tâches API

Une API RESTful développée en **C# / ASP.NET Core** permettant de gérer des projets, leurs tâches associées et les dates d’échéance.

## 🚀 Fonctionnalités

- 📁 Création de projets
- ✅ Ajout de tâches avec date d’échéance
- 🔄 Mise à jour de l’état d’une tâche (terminée ou non)
- 🗑️ Suppression de tâches ou de projets
- 📦 Architecture RESTful
- 🔗 Base de données relationnelle (MySQL ou SQLite selon configuration)

## 🛠️ Technologies

- ASP.NET Core Web API
- Entity Framework Core (EF Core)
- MySQL (ou SQLite)
- Swagger (OpenAPI) pour la documentation

## 📦 Installation

### Prérequis

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Un éditeur (comme Visual Studio ou VS Code)
- MySQL Server (ou SQLite pour une base légère)

### Étapes

1. Cloner le dépôt :
   ```bash
   git clone https://github.com/ton-utilisateur/nom-du-depot.git
   cd nom-du-depot
   ```

2. Restaurer les packages NuGet :
   ```bash
   dotnet restore
   ```

3. Mettre à jour la chaîne de connexion dans `appsettings.json` :
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "server=localhost;database=GestionnaireTaches;user=root;password=ton_mot_de_passe"
   }
   ```

4. Appliquer les migrations :
   ```bash
   dotnet ef database update
   ```

5. Lancer l’API :
   ```bash
   dotnet run
   ```

6. Accéder à la documentation Swagger :
   ```
   http://localhost:5000/swagger
   ```

## 🔄 Points de terminaison (API)

### Projets

- `GET /api/projets` : liste tous les projets
- `POST /api/projets` : crée un nouveau projet

### Tâches

- `GET /api/taches` : liste toutes les tâches
- `POST /api/taches` : ajoute une tâche à un projet
- `PUT /api/taches/{id}` : met à jour une tâche
- `DELETE /api/taches/{id}` : supprime une tâche

## 📁 Structure du projet

```
GestionnaireTachesApi/
├── Controllers/
│   ├── ProjetsController.cs
│   └── TachesController.cs
├── Models/
│   ├── Projet.cs
│   └── Tache.cs
├── Data/
│   └── TachesDbContext.cs
├── appsettings.json
└── Program.cs
```

## ✍️ Auteur

**AJAVON [LokiCrimson](https://github.com/LokiCrimson)**

## 📄 Licence

Ce projet est sous licence MIT – voir le fichier [LICENSE](LICENSE) pour plus d'informations.
