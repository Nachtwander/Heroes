﻿using Heroes.Models;
using Heroes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Heroes.ViewModels
{
    public class ViewModelListaHeroes : INotifyPropertyChanged
    {
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Heroes_Modelos.bin");
        public ObservableCollection<Heroe_Modelo> listaHM { get; set; } = new ObservableCollection<Heroe_Modelo>();

        public ObservableCollection<PequeñosHeroes> ListaPH { get; set; } = new ObservableCollection<PequeñosHeroes>();



        public ViewModelListaHeroes() 
        {
            try
            {
                // Verificar si el archivo existe
                if (File.Exists(ruta))
                {
                    // Abrir y leer el archivo
                    byte[] data = File.ReadAllBytes(ruta);
                    MemoryStream memory = new MemoryStream(data);
                    BinaryFormatter formatter = new BinaryFormatter();
                    listaHM = (ObservableCollection<Heroe_Modelo>)formatter.Deserialize(memory);
                    memory.Close();

                    foreach (Heroe_Modelo HM in listaHM)
                    {
                        if (HM.ListaPequeñosHeroes != null)
                        {
                            // Recorrer la lista de PequeñosHeroes y agregarlos a la ListaPH
                            foreach (PequeñosHeroes pequenoHeroe in HM.ListaPequeñosHeroes)
                            {
                                ListaPH.Add(pequenoHeroe);
                            }
                        }
                    };
                }
                else
                {
                    // El archivo no existe, se crea una nueva lista vacía
                    listaHM = new ObservableCollection<Heroe_Modelo>();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la carga de datos
                Console.WriteLine("Error al cargar los datos: " + ex.Message);
                listaHM = new ObservableCollection<Heroe_Modelo>();
            }

            VolverMenu = new Command(() =>
            {
                var pagina = new ViewMenuHeroes();

                Application.Current.MainPage.Navigation.PushAsync(pagina);


            });




        }









        public Command VolverMenu { get; set; }




        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
