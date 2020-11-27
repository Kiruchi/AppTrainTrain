# Exercice 5

## But de l'exercice

### Implémenter les adapteurs secondaires (infra)

Remplacer le bouchon du `IReservationRepository` par un vrai adapteur secondaire qui tape sur une base via EF



## Aide

### Ajouter les dépendances dans l'infra

Dans le `csproj` ajouter les références pour EF :

```xml    
<ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="3.1.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer.Design" Version="1.1.6" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="3.1.3" />
</ItemGroup>
```

### Partie obligatoire

1. Créer le(s) DbModel(s) nécessaires pour sauvegarder une réservation
2. Créer un `ReservationsContext` héritant de `DbContext`
```csharp
    public class ReservationsContext : DbContext
    {
        public ReservationsContext(DbContextOptions<ReservationsContext> options)
            : base(options)
        {
        }
    }
```

3. Implémenter `IReservationRepository` en s'injectant le `ReservationsContext`





### Partie moins importante et un peu relou à faire

Voilà la configuration à faire pour sauvegarder dans la base de données.

1. Créer le fichier de configuration implémentant `IEntityTypeConfiguration<>` pour chaque DbModel
    - Rappel pour la création de clé étrangère

    ```csharp
    // dans la configuration de la réservation
    builder
        .HasMany(reservation => reservation.Passagers)
        .WithOne()
        .HasForeignKey(passager => passager.ReservationId);
    ```


2. Surcharger `OnModelCreating` de `ReservationsContext` pour y référencer les Configuration créées à l'étape 1
```csharp
    public class ReservationsContext : DbContext
    {        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new /* Fichier de configuration créé précédemment */());
        }
    }
```

3. Créer un fichier `ReservationsContextFactory`, nécessaire pour la gérération des migrations

```csharp
public class ReservationsContextFactory : IDesignTimeDbContextFactory<ReservationContext>
{
    public ReservationContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "../../Application.Web"
                ))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Reservations");
        var optionsBuilder = new DbContextOptionsBuilder<ReservationsContext>();
        optionsBuilder.UseSqlServer(connectionString);
        
        return new ReservationsContext(optionsBuilder.Options);
    }
}
```

4. Dans le fichier `appsettings.json` qui se trouve dans `Application.Web` (racine du projet), ajouter une `ConnectionString` :

    `"Reservations": "Data Source=.;Initial Catalog=TRAIN_TRAIN_RESERVATIONS;Integrated Security=True"`

5. Surcharger `RegisterDbContext` du `ContainerRegistration` dans `Reservations.Web`
```csharp
public override void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<ReservationsContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("Reservations")));
}
```

### Créer les bases

Créer une base de données vide nommée `TRAIN_TRAIN_RESERVATIONS`

(Optionnel) Si vous voulez aussi tester les routes pour la flotte et le reseau :
1. Créer aussi deux autres bases nommées :
    - TRAIN_TRAIN_FLOTTE
    - TRAIN_TRAIN_RESEAU
2. Exécuter le fichier `0_SeedDatabase.bat`

### Générer la migration

1. Ouvrir un terminal
2. Se positionner dans le dossier `Reservations/Reservations.Infra`
3. Lancer `dotnet ef migrations add InitReservations` pour créer les fichiers de migration
4. Lancer `dotnet ef database update` pour lancer la migration


### Tester l'api

POST https://localhost:5001/reservations
{
    "idVoyage": 1213,
    "passagers": [
        {
            "nom": "Moinard",
            "prenom": "Christophe",
            "email": "cmoinard@lucca.fr",
            "dateDeNaissance": "1985-04-10T00:00:00"
        }
    ]
}