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

}
}
