using System;
using System.Collections.Generic;
using System.Linq;



public class Banque
{
    private string nom { get; set; }
    private string prenom { get; set; }
    private string carte { get; set; }
    private int solde { get; set; }
    private List<Client> clients = new List<Client>();

    public Banque() 
    {
      
    }

    public void ajouter()
    {
      Console.WriteLine("Saisir le prénom");
      string prenom = Console.ReadLine();
      Console.WriteLine("Saisir le nom");
      string nom = Console.ReadLine();
      Console.WriteLine("Saisir le numéro de compte");
      string carte = Console.ReadLine();
      Console.WriteLine("Saisir le solde");
      string mont = Console.ReadLine();
      int montant = int.Parse(mont);
      Client client = new Client(prenom,nom,carte,montant);
      clients.Add(client);
      
    }

    public void supprimer()
    {
      int i = 0;
      foreach (Client client in clients) {
        i++;
        Console.WriteLine(i + "- " + client.Prenom + " " + client.Nom);
      }
      Console.WriteLine("-----------");
      Console.WriteLine("Quel client voulez-vous supprimer ? (entrez un nombre entre 1 et " + clients.Count() + ")");

      string line = Console.ReadLine();
      int index = int.Parse(line);

      if(index <= clients.Count && index >= 0)
        clients.RemoveAt(index-1);
      else{
        Console.WriteLine("Entrée invalide réessayez");
      }
    }

    public void afficher(int index)
    {
      if(index <= clients.Count && index >= 0)
        clients[index-1].afficher();
      else{
        Console.WriteLine("Entrée invalide réessayez");
      }
    }

    public void depot()
    {
      Console.WriteLine("veuillez entrer le numéro du compte à créditer");
      string num = Console.ReadLine();

      foreach (Client client in clients){
        Console.WriteLine(client.Carte);

        if(num==client.Carte){
          Console.WriteLine(client.Carte);
          Console.WriteLine("Saisir le montant à déposer");
          string line = Console.ReadLine();
          int montant = int.Parse(line);
          client.depot(montant);
          Console.WriteLine("Votre dépôt a bien été effectué");
          break;
        }
        else
          Console.WriteLine("Numéro inconnu. Réessayez");
      }
    }

    public void retrait()
    {      
      Console.WriteLine("veuillez entrer le numéro du compte à debiter");
      string num = Console.ReadLine();

      foreach (Client client in clients){

        if(num==client.Carte){
          Console.WriteLine(client.Carte);
          Console.WriteLine("Saisir le montant à retirer");
          string line = Console.ReadLine();
          int montant = int.Parse(line);
          Console.WriteLine("Votre retrait a bien été effectué");
          client.retrait(montant);
          break;
        }
        else
          Console.WriteLine("Numéro inconnu. Réessayez");
      }
    }

    public void afficherTout()
    {
      if(clients.Count==0)
        Console.WriteLine("Pas de client !");
      else{
        foreach (Client client in clients)
        {
            client.afficher();
        }
      }
    }

      public void menu(){

          Console.WriteLine("-----------------------");
          Console.WriteLine("Que voulez-vous faire ?");
          Console.WriteLine("Saisissez un nombre entre 1 et 7");
          Console.WriteLine("-----------------------");

      
          Console.WriteLine("1- Ajouter un client");
          Console.WriteLine("2- Supprimer un client");
          Console.WriteLine("3- Afficher un client");
          Console.WriteLine("4- Afficher tous les clients");
          Console.WriteLine("5- Effectuer un dépôt");
          Console.WriteLine("6- Effectuer un retrait");
          Console.WriteLine("7- Quitter");
          Console.WriteLine("-----------------------");

          string line = Console.ReadLine();
          int caseSwitch = int.Parse(line);

      switch (caseSwitch)
      {
          case 1:
              this.ajouter();
              break;
          case 2:
            if(clients.Any())
              this.supprimer();
            else
              Console.WriteLine("Pas de client !");
            break;
          case 3:
              Console.WriteLine("Quel compte voulez vous afficher ?");
              int i = 0;
              foreach (Client client in clients) {
                i++;
                Console.WriteLine(i + "- " + client.Prenom + " " + client.Nom);
              }

              string lin = Console.ReadLine();
              int index = int.Parse(lin);
              this.afficher(index);
              break;
          case 4:
              this.afficherTout();
              break;
          case 5:
              this.depot();
              break;
          case 6:
              this.retrait();
              break;
          case 7:
              return;
          default:
              Console.WriteLine("entrée invalide");
              break;
      }

      this.menu();
    }
}