using Heroes.Models;
using Heroes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Heroes.ViewModels
{
    public class VMHeroeModelo : INotifyPropertyChanged
    {

        /* ------------------------------------------- Observable Collections ---------------------------------------*/

        //OBC que almacena Heroe Modelo
        public ObservableCollection<Heroe_Modelo> ListaHM { get; set; } = new ObservableCollection<Heroe_Modelo>();

        //OBC almacena ataques de Heroe Modelo
        public List<String> ListaPoderesHM { get; set; } = new List<String>();

        //OBC almacena ataques de Heroe Modelo
        public ObservableCollection<Heroe_Modelo> ListaAtaquesHM { get; set; } = new ObservableCollection<Heroe_Modelo>();

        //Observable Collection de pequeños heroes  
        public ObservableCollection<PequeñosHeroes> ListaPequeñosHeroes { get; set; } = new ObservableCollection<PequeñosHeroes>();

        /* ---------------------------------------  Fin Observable Collections  ---------------------------------------*/



        /* ------------------------------------------- Metodo Constructor ---------------------------------------*/

        //Metodo Constructor
        //el constructor "VMHeroeModelo" toma un objeto de tipo "Heroe_Modelo"
        //como parámetro y lo utiliza para inicializar el objeto creado a partir de la clase "VMHeroeModelo
        public VMHeroeModelo()
        {


            CrearHM = new Command(() => {



                ListaHM.Add(new Heroe_Modelo()
                {
                    nombre = nombreHM,
                    IdentidadSecreta = idSecretaHM,
                    ColorPreferido = colorPreferidoHM,
                    TipoHeroe = "Modelo",
                    
                });
                 

                var pagina = new ViewSeleccion_Heroes_Modelo();

                Application.Current.MainPage.Navigation.PushAsync(pagina);



            });


            //posible comando para ingresar poderes en un heroe modelo
            GetPoderesHM = new Command(() => {


               
                




                var pagina = new ViewSeleccion_Heroes_Modelo();

                Application.Current.MainPage.Navigation.PushAsync(pagina);



            });


        }

        /* ------------------------------------------- Fin Metodo Constructor ---------------------------------------*/






      


        /* ------------------------------------------- Variables  ---------------------------------------*/


        //Variable Privada del nombre del Heroe
        string poderHM;

        //Variable Publica del nombre del Heroe
        public string PoderHM
        {
            get => poderHM;

            set
            {
                poderHM = value;
                OnPropertyChanged(nameof(PoderHM));
            }

        }


        //Variable Privada del nombre del Heroe
        string nombreHM;

        //Variable Publica del nombre del Heroe
        public string NombreHM
        {
            get => nombreHM;

            set
            {
                nombreHM = value;
                OnPropertyChanged(nameof(NombreHM));
            }

        }

        //Variable Privada Identidad Secreta del Heroe Modelo
        string idSecretaHM;
        //variable publica
        public string IdSecretaHM
        {
            get => idSecretaHM;

            set
            {
                idSecretaHM = value;
                OnPropertyChanged(nameof(IdSecretaHM));
            }

        }

        //variable del color preferido del Heroe Modelo
        string colorPreferidoHM;
        //variable publica
        public string ColorPreferidoHM
        {
            get => colorPreferidoHM;

            set
            {
                colorPreferidoHM = value;
                OnPropertyChanged(nameof(ColorPreferidoHM));
            }

        }



        /* ------------------------------------------- Fin Variables ---------------------------------------*/




        /* ------------------------------------------- Comandos ---------------------------------------*/

        //comando crear heroe
        public Command CrearHM { get; set; }

        //comando get poderes
        public Command GetPoderesHM { get; set; }

        /* ------------------------------------------- Fin Comandos---------------------------------------*/






        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;

    }
}
