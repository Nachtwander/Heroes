using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public class PequeñosHeroes : Heroe_Modelo
    {

        //Polimorfismo Metodo ToString de Clase SuperHeroe
        public override string ToString()
        {
            return $" -Nombre del Heroe Pequeño: {nombre} -Color Preferido: {ColorPreferido} -Nivel {Nivel} -Personas Rescatadas: {PersonasRescatadas} -Identidad Secreta:{IdentidadSecreta} -Tipo de Heroe: {TipoHeroe}" + "\n";
        }

       



    }
}
