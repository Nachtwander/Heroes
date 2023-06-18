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

        public ObservableCollection<string> ListaAtaques { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListaPoderes { get; set; } = new ObservableCollection<string>();


        /* ------------------------------------------- Metodo Constructor ---------------------------------------*/

        //Metodo Constructor
        //el constructor "VMHeroeModelo" toma un objeto de tipo "Heroe_Modelo"
        //como parámetro y lo utiliza para inicializar el objeto creado a partir de la clase "VMHeroeModelo
        public VMHeroeModelo()
        {
            CrearHM = new Command(() => {


                Heroe_Modelo HM = new Heroe_Modelo()
                {
                    Nombre = this.nombreHM,
                    IdentidadSecreta = this.idSecretaHM,
                    ColorPreferido = this.colorPreferidoHM,
                    TipoHeroe = "Modelo",
                    

                };

                ListaAtaques.Add(ataque);
                ListaPoderes.Add(Poder);
                HM.listPoderes = this.ListaPoderes;
                HM.listAtaques = this.ListaAtaques;
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
            CrearAtaques = new Command(async () =>
            {
                for (int i = 0; i < CantidadAtaques; i++)
                {
                    string ataque = await Application.Current.MainPage.DisplayPromptAsync("Crear Ataque", "Ingrese el nombre del ataque " + i, "Aceptar", "Cancelar", placeholder: "Ataque " + "\n");
                    if (!string.IsNullOrWhiteSpace(ataque))
                    {
                        this.ListaAtaques.Add(ataque);
                    }
                }
            });

            CrearPoderes = new Command(async () =>
            {
                for (int i = 0; i < CantidadPoderes; i++)
                {
                    string poder = await Application.Current.MainPage.DisplayPromptAsync("Crear Poder", "Ingrese el nombre del poder " + i, "Aceptar", "Cancelar", placeholder: "Poder " + "\n");
                    if (!string.IsNullOrWhiteSpace(poder))
                    {
                        this.ListaPoderes.Add(poder);
                    }
                }
            });



        }

        /* ------------------------------------------- Fin Metodo Constructor ---------------------------------------*/


        /* ------------------------------------------- Variables  ---------------------------------------*/



        string poder;
        public string Poder
        {
            get => poder;
            set
            {
                poder = value;
                OnPropertyChanged(nameof(Poder));
            }
        }





        string ataque;
        public string Ataque
        {
            get => ataque;
            set
            {
                ataque = value;
                OnPropertyChanged(nameof(Ataque));
            }
        }





        int cantidadAtaques;
        int cantidadPoderes;

        public int CantidadAtaques
        {
            get => cantidadAtaques;
            set
            {
                cantidadAtaques = value;
                OnPropertyChanged(nameof(CantidadAtaques));
            }
        }

        public int CantidadPoderes
        {
            get => cantidadPoderes;
            set
            {
                cantidadPoderes = value;
                OnPropertyChanged(nameof(CantidadPoderes));
            }
        }





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

        public Command CrearPoderes { get; set; }

        public Command CrearAtaques { get; set; }

        //comando crear heroe
        public Command CrearHM { get; set; }

        //comando get poderes
       

        /* ------------------------------------------- Fin Comandos---------------------------------------*/



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;

    }
}
