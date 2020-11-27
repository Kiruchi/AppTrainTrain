# Exercice 4

## Étape précédente

Tag : Exercice4


## But de l'exercice

### Implémenter l'adapteur primaire (controlleur)

- Ajouter des DTO
- Catcher les exceptions métier pour les convertir en Ok/BadRequest…


### Bouchonner les ports secondaires

Dans l'infra, implémenter les ports secondaires et mettez des valeurs bidon dedans.

Il faudra les référencer dans l'injection de dépendance. Aller dans `ContainerRegistration` du projet `Reservation.Web` et surcharger `RegisterServices` :

```csharp
public override void RegisterServices()
{
    // Ports primaires
    ServiceContainer.Register<IReservationUseCase, ReservationUseCase>();
    
    // Ports secondaires
    ServiceContainer.Register<ITrainRepository, DummyTrainRepository>();
    ServiceContainer.Register<IReservationRepository, DummyReservationRepository>();
    ServiceContainer.Register<IReservationNotifieur, DummyReservationNotifieur>();
}
```

Exemples de bouchons :

```csharp
public class DummyReservationRepository : IReservationRepository
{
    public async Task SaveAsync(Reservation reservation)
    {
        await Task.CompletedTask;
    }
}

public class DummyTrainRepository : ITrainRepository
{
    public async Task<Train> GetTrainDuVoyageAsync(IdVoyage idVoyage)
    {
        await Task.CompletedTask;
        return new Train(
            idVoyage,
            new []
            {
                new Voiture(new NumeroVoiture(12), 100), 
                new Voiture(new NumeroVoiture(13), 100, 50), 
            });
    }

    public async Task SaveAsync(Train train)
    {
        await Task.CompletedTask;
    }
}
```

## Aide

### Conseils

- Dans le controller, un catch par exception métier
- Certains DTO doivent être convertis en objets du domaine, une méthode `ToDomain()` sur le DTO peut être utile.