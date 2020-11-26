# Exercice 1

## Prérequis

Cloner / Forker : https://github.com/cmoinard/AppTrainTrain
Tag : Exercice1


## But de l'exercice

### Implémenter l'hexagone

- Port primaire
- Use case
- Port(s) secondaire(s)




### Contraintes

- Pas de comportement dans les modèles :
    - que des `{ get; set; }`
    - pas de méthodes en dehors des propriétés
    - toute la logique métier dans le Use case
- Toute méthode dans un port est asynchrone (doit renvoyer un `Task` ou `Task<>`)



### Règles métier

- Quoi qu’il arrive, il est impossible d’avoir un taux d’occupation à plus de 100% (pas plus de places occupées que la capacité)
- La réservation doit empêcher d’avoir une voiture avec un seuil d’occupation de plus de 70%. 
- On ne doit pas éclater un groupe.

#### Exemples

Train avec 2 voitures de 200 places. PO = Places occupées

- Si réservation de 4 places avec V1 vide et V2 vide
    - OK
    - V1 a 4 PO
    - V2 est vide

- Si réservation de 4 places avec V1 a 140 PO et V2 vide
    - OK
    - V1 a 140 PO
    - V2 a 4 PO

- Si réservation de 4 places avec V1 a 140 PO et V2 138 PO
    - ERREUR : Train plein




### Implémentation grossière


1. Récupérer le train affecté au voyage
    - Si pas de train -> ERREUR : train inexistant
2. Vérifier si on peut réserver n places
    1. Si non -> ERREUR : train plein
    2. Si oui
        1. Réserver les places dans le train
        2. Sauvegarder le train
        3. Enregistrer une réservation (Id, IdVoyage, Passagers, Numéro de voiture)
        4. Envoyer un mail aux passagers


## Aide

### Conseils

- Commencer par le port primaire
- Implémenter petit à petit le Use case
- Faire émerger les ports secondaires en les créant qu'au moment où on en a besoin





### Bien débuter

#### Créer le port primaire

```csharp

public interface IReservationUseCase
{
    Task ReserverAsync(int idVoyage, IReadOnlyCollection<Passager> passagers);
}
```

#### Créer le Use case

```csharp
public class ReservationUseCase : IReservationUseCase
{
    public Task ReserverAsync(int idVoyage, IReadOnlyCollection<Passager> passagers)
    {
        throw new System.NotImplementedException();
    }
}
```

#### Premier port secondaire

Besoin l'aller chercher le train en fonction d'un numéro de voyage.

```csharp
public interface ITrainRepository
{
    Task<Train?> GetTrainDuVoyageAsync(int idVoyage);
    Task SaveAsync(Train train);
}
```

#### Lever une exception si le train est null
