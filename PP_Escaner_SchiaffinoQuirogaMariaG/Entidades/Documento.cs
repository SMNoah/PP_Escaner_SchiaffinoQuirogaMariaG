using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        int anio;
        string autor;
        string barcode;
        Paso estado;
        string numNormalizado;
        string titulo;

        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        protected Documento(int anio, string autor, string barcode, string numNormalizado, string titulo)
        { 
            this.anio = anio;
            this.autor = autor;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
            this.numNormalizado = numNormalizado;
            this.titulo = titulo;
        }

        public int Anio { get => anio; }
        public string Autor { get => autor; }
        public string Barcode { get => barcode; }
        public Paso Estado { get => estado; }
        protected string NumNormalizado { get => numNormalizado; }
        public string Titulo { get => titulo; }

        public bool AvanzarEstado()
        {
            switch (this.estado)
            {
                case Paso.Inicio:
                    this.estado = Paso.Distribuido;
                    return true;
                case Paso.Distribuido:
                    this.estado = Paso.EnEscaner;
                    return true;
                case Paso.EnEscaner:
                    this.estado = Paso.EnRevision;
                    return true;
                case Paso.EnRevision:
                    this.estado = Paso.Terminado;
                    return true;
                case Paso.Terminado:
                    return false;
                default:
                    return false;
            }
        }

        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();

            strb.AppendLine("");
            strb.AppendLine($"Titulo: {this.titulo}");
            strb.AppendLine($"Autor: {this.autor}");
            strb.AppendLine($"Año: {this.anio}");
            strb.AppendLine($"Cód. de barras: {this.barcode}");

            return strb.ToString();
        }


    }
}
