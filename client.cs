using System;

public class Client
{
    private string nom { get; set; }
    public string Nom { get {return nom;} set{} }
    private string prenom { get; set; }
    public string Prenom { get {return prenom;} set{} }
    private string carte;
    public string Carte { get {return carte;} set{} }
    private int solde { get; set; }

    public Client() 
    {
      
    }

    public Client(string _nom, string _prenom, string _carte, int montant)
    {
      nom = _nom;
      prenom = _prenom;
      carte = _carte;
      solde = montant;
      Console.WriteLine(prenom + " " + nom + " votre compte numéro " + carte + " est créé avec un solde de "+ solde + "€");
    }

    public void afficher()
    {
      Console.WriteLine("---------------");
      Console.WriteLine("Prénom : "+ prenom);
      Console.WriteLine("Nom : " + nom);
      Console.WriteLine("Numéro de carte : " + carte);
      Console.WriteLine("Solde : " + solde);
    }

    public void retrait(int montant)
    {
      if(solde-montant<0)
        Console.WriteLine("Retrait impossible. Fonds insuffisants");
      else{
        solde-= montant;
        Console.WriteLine("votre solde est maintenant de " + solde + "€");
      }
    }

    public void depot(int montant)
    {
      solde+= montant;
      Console.WriteLine("votre solde est maintenant de " + solde + "€");
    }
}