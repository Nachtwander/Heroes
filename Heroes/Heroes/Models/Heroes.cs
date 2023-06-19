using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace Heroes.Models
{
    [Serializable]
    public class Heroes
    {
        //Varibles de Clase Heroe
        public string Nombre { get; set; }
        public string ColorPreferido { get; set; }
       
        public string IdentidadSecreta { get; set; }
        public string TipoHeroe { get; set; }
        public int Nivel { get; set; }
        public int PersonasRescatadas { get; set; }

        public double Daño { get; set; }


        //Listas observable collection de poseres y ataques

        public ObservableCollection<string> listAtaques { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> listPoderes { get; set; } = new ObservableCollection<string>();

       

    }
}
