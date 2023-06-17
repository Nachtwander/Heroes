using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Heroes.Models
{
    [Serializable]
    public class Heroe_Modelo : Heroes
    {

        
        public ObservableCollection<PequeñosHeroes> ListaPequeñosHeroes { get; set; } = new ObservableCollection<PequeñosHeroes> ();


        //Polimorfismo del metodo ToString de Super clase SuperHeroe 
        public override string ToString()
        {
            return $" {nombre} - {ColorPreferido} -{IdentidadSecreta} - {TipoHeroe}  ";
        }

       


        //Polimorfismo
        //Por Cada variable x de tipo String en Lista de poderes,
        //a Poderes se le sumara la variable String almacenada mas un salto de linea y retornara cada variable dentro de la lista de Poderes.
        public string getPoderes()
        {
            string Poderes = "";

            foreach (string x in listPoderes)
            {
                Poderes += x + ", ";
            }
            return $"Poderes: {Poderes} ";
        }

        //Polimorfismo
        //Por Cada variable x de tipo String en Lista de Ataques,
        //a ataques se le sumara la variable String almacenada mas un salto de linea y retornara cada variable dentro de la lista de ataques.
        public string getAtaques()
        {
            string Ataques = "";

            foreach (string x in listAtaques)
            {
                Ataques += x + ", ";
            }
            return $"Ataques: {Ataques} ";
        }


        //Polimorfismo
        //Por Cada variable x de tipo String en Lista de Ataques,
        //a Daño se le sumara 70 de daño y retornara la sumatoria del daño de los ataques.
        public string getDaño()
        {
            int daño = 0;

            foreach (string x in listAtaques)
            {
                daño = daño + 70;
            }
            return $"daño causado por sumatoria de los ataques de {nombre}: {daño} puntos de vida al enemigo. " + "\n";
        }

        //Metodo exclusivo clase Heroes Modelos
        //Por Cada variable x de tipo String en Lista de Heroes Pequeños,
        //a HeroesP se le sumaran los datos de los Heroes Pequeños Formados por el Objeto Heroe Modelo.
        public string getHeroesPequeños()
        {
            string HeroesP = "";

            foreach (PequeñosHeroes x in ListaPequeñosHeroes)
            {
                HeroesP += x + "\n";
            }
            return $"Los Heroes Pequeños Formados por {nombre} son:" + "\n" + $" {HeroesP} ";
        }

        
    



}
}
