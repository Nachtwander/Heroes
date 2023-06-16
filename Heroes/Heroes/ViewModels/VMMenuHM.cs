using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Heroes.ViewModels
{
    public class VMMenuHM : INotifyPropertyChanged
    {
        //Ruta de guardado de serializacion
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Heroes_Modelos.bin");

        public ObservableCollection<Heroe_Modelo> listaHM { get; set; } = new ObservableCollection<Heroe_Modelo>();

        


        public VMMenuHM(Heroe_Modelo HM) 
        {

           listaHM = new ObservableCollection<Heroe_Modelo>();

            try
            {
                // Abrir y leer el archivo
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formatter = new BinaryFormatter();
                listaHM = (ObservableCollection <Heroe_Modelo>)formatter.Deserialize(memory);
                memory.Close();
            }
            catch (FileNotFoundException)
            {
                // El archivo no existe, se crea una nueva lista vacía
                
            }







        }


        Heroe_Modelo HM;

        public Heroe_Modelo hm
        {
            get => HM;

            set
            {
                HM = value;
                OnPropertyChanged(nameof(hm));
            }
        }




        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
