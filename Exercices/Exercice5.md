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

### Classes à créer

1. Le(s) DbModel(s) nécessaires pour sauvegarder une réservation
2. Créer le fichier de configuration implémentant `IEntityTypeConfiguration<>` pour chaque DbModel
    - Rappel pour la création de clé étrangère

    ```csharp
    builder.Property(p => p.ReservationId).IsRequired();
    builder
        .HasOne(p => p.Reservation)
        .WithMany()
        .HasForeignKey(p => p.ReservationId);
    ```


3. Créer un `ReservationsContext` héritant de `DbContext`
```csharp
    public class ReservationsContext : DbContext
    {
        public ReservationsContext(DbContextOptions<ReservationsContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new /* Fichier de configuration créé précédemment */());
        }
    }
```
4. Créer un fichier `ReservationContextFactory`, nécessaire pour la gérération des migrations

```csharp

public class ReservationContextFactory : IDesignTimeDbContextFactory<ReservationContext>
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

        var connectionString = configuration.GetConnectionString("Reservation");
        var optionsBuilder = new DbContextOptionsBuilder<ReservationContext>();
        optionsBuilder.UseSqlServer(connectionString);
        
        return new ReservationContext(optionsBuilder.Options);
    }
}
```

5. Dans le fichier `appsettings.json` qui se trouve dans `Application.Web` (racine du projet), ajouter une `ConnectionString` :

    `"Flotte": "Data Source=.;Initial Catalog=TRAIN_TRAIN_RESERVATION;Integrated Security=True"`


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

