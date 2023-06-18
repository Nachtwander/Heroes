﻿using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms;

namespace Heroes.ViewModels
{
    public class VMMenuHM : INotifyPropertyChanged
    {
        //Ruta de guardado de serializacion
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Heroes_Modelos.bin");

        
        
        


        public VMMenuHM() 
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

            Redireccion = new Command(() =>
            {
                if (OpcionSeleccionada != null)
                {
                    HeroeSeleccionado = OpcionSeleccionada; // Asigna el héroe modelo seleccionado

                    
                    


                }


            });

            





        }



       







        Heroe_Modelo opcionSeleccionada;

        public Heroe_Modelo OpcionSeleccionada
        {
            get => opcionSeleccionada;
            set
            {
                opcionSeleccionada = value;
                OnPropertyChanged(nameof(OpcionSeleccionada));
            }

        }

        public Heroe_Modelo HeroeSeleccionado { get; set; }



        public Command AgregarHeroePequeno { get; }
        public Command Redireccion { get; }

        public ObservableCollection<Heroe_Modelo> listaHM { get; set; } = new ObservableCollection<Heroe_Modelo>();
        

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
