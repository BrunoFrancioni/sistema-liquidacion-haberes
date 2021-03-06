﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class ViewModelRecibo
    {
        public string LugarTrabajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Antiguedad { get; set; }

        public string MesUltimoDeposito { get; set; }

        public string PorcentajeAntiguedad { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaEgreso { get; set; }
        public string Cuil { get; set; }
        public string Sector { get; set; }
        public string Categoria { get; set; }
        public string ObraSocial { get; set; }
        public string PlanObraSocial { get; set; }

        public string NombreBanco { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaUltimoDeposito { get; set; }

        public decimal SueldoBasico { get; set; }

        public string FeriadosTrabajados { get; set; }

        public decimal CalculoFeriadosTrabajados { get; set; }

        public string HorasExtrasTrabajadas { get; set; }

        public decimal CalculoHorasExtrasTrabajadas { get; set; }

        public decimal CalculoAntiguedad { get; set; }

        public decimal Presentismo { get; set; }
        public decimal Ley19023 { get; set; }

        public decimal CalculoJubilacion { get; set; }

        public decimal CalculoObraSocial { get; set; }

        public decimal Remunerativo { get; set; }

        public decimal Descuentos { get; set; }

        public decimal Neto { get; set; }

        public string NetoEnLetras { get; set; }
    }
}