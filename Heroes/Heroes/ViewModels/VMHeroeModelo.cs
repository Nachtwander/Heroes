using Heroes.Models;
using Heroes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Heroes.ViewModels
{
    [Serializable]
    public class VMHeroeModelo : INotifyPropertyChanged
    {

        //Ruta de guardado de serializacion
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Heroes_Modelos.bin");

        public ObservableCollection<Heroe_Modelo> listaHM { get; set; } = new ObservableCollection<Heroe_Modelo>();
        public Heroe_Modelo HM { get; }


        /* ------------------------------------------- Metodo Constructor ---------------------------------------*/

        //Metodo Constructor
        //el constructor "VMHeroeModelo" toma un objeto de tipo "Heroe_Modelo"
        //como parámetro y lo utiliza para inicializar el objeto creado a partir de la clase "VMHeroeModelo
        public VMHeroeModelo()
        {
            CrearHM = new Command(() => {


                Heroe_Modelo HM = new Heroe_Modelo()
                {
                    nombre = this.nombreHM,
                    IdentidadSecreta = this.idSecretaHM,
                    ColorPreferido = this.colorPreferidoHM,
                    TipoHeroe = "Modelo",

                };

                listaHM.Add(HM);
                


                //Rutina de Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memory = new MemoryStream();
                formatter.Serialize(memory, listaHM);
                byte[] SerializedData = memory.ToArray();
                memory.Close();
                File.WriteAllBytes(ruta, SerializedData);



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

        //variable Privada usuario
        string HMnombre;

        //Varible publica Usuario que recibira los datos y dalar valor a la variable privada usuario
        public string hMnombre
        {
            get => HMnombre;

            set
            {
                HMnombre = value;
                OnPropertyChanged(nameof(hMnombre));
            }
        }



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
