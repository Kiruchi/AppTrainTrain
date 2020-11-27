# Exercice 3

## Étape précédente

Tag : Exercice3


## But de l'exercice

### Lever que des Exceptions métier

Faire des exceptions qui héritent de `DomainException`.


### Remplacer les types primitifs par des ValueObject

- Remplacer les types int/Guid utilisés comme identifiant par des Id<>
- Remplacer le string de l’email par un ValueObject Email
- Remplacer le decimal/double du seuil par un ValueObject TauxOccupation



## Aide

### Implémenter un ValueObject

Il existe une classe `ValueObject` qui oblige à implémenter une méthode devant lister TOUTES les propriétés de la classe :

```csharp
public class Montant : ValueObject
{
    public decimal Quantite { get; }
    public string Devise { get; }

    public Montant(decimal quantite, string devise)
    {
        Quantite = quantite;
        Devise = devise;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Quantite;
        yield return Devise;
    }
}

// Implémente l'égalité structurelle
new Montant(10, "EUR") == new Montant(10, "EUR") // true
new Montant(10, "USD") == new Montant(10, "EUR") // false
new Montant(13, "EUR") == new Montant(10, "EUR") // false
```

Mais il existe plusieurs sous-types de ValueObjects plus simples.

`SimpleValueObject` pour les `ValueObject` avec une seule propriété :

```csharp
public class JourOuvré : SimpleValueObject<DayOfWeek>
{
    public JourOuvré(DayOfWeek value) : base(value)
    {
        if (value == DayOfWeek.Saturday || value == DayOfWeek.Sunday)
            throw new ArgumentException();
    }
}
```

`StringBasedValueObject` est un `SimpleValueObject` dédié aux `string` :
```csharp
public class CodePostal : StringBasedValueObject
{
    public CodePostal(string internalValue) : base(internalValue)
    {
    }
}

// Permet de faire un cast en string
var codePostal = new CodePostal("44100");
var strCodePostal = (string)codePostal;
```

`Id<>` qui permet de représenter un identifiant :

```csharp
public class PersonneId : Id<Guid>
{
    public PersonneId(Guid internalValue) : base(internalValue)
    {
    }
}

// Permet de faire un cast en T
var personneId = new PersonneId(Guid.NewGuid());
var id = (Guid)personneId;
```


`ComparableValueObject` pour les `SimpleValueObject` comparables :

```csharp
public class Classement : ComparableValueObject<int>
{
    public Classement(int internalValue) : base(internalValue)
    {
        
        if (internalValue < 0 || 5 < internalValue)
            throw new ArgumentException();
    }
}

// Permet de faire un cast en T
var c5 = new Classement(5);
var valeur = (int)c5;

// Implémente les opérateurs de comparaison
new Classement(4) > new Classement(5) // false
}
```


### Conseils

- Commencer par remplacer les Exceptions au fur et à mesure
- Trouver les identifiants à remplacer (IdVoyage, NumeroVoiture…)
- Quel meilleur type de ValueObject pour l'Email ?
- Quel meilleur type de ValueObject pour le TauxOccupation ?