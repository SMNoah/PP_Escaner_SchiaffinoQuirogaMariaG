using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        public Libro(int anio, string autor, string barcode, string numNormalizado, string titulo, int numPaginas) : base(anio, autor, barcode, numNormalizado, titulo)
        {
            this.numPaginas = numPaginas;
        }

        public int NumPaginas { get => numPaginas; }
        public string ISBN { get => NumNormalizado; }

        public static bool operator ==(Libro LibroUno, Libro LibroDos)
        {
            if (LibroUno.Barcode == LibroDos.Barcode || LibroUno.ISBN == LibroDos.ISBN || (LibroUno.Titulo == LibroDos.Titulo && LibroUno.Autor && LibroDos.Autor))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Libro LibroUno, Libro LibroDos)
        {
            return !(LibroUno == LibroDos);
        }

        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();

            strb.Append(base.ToString());
            strb.AppendLine($"Número de páginas: {this.numPaginas}");

            return strb.ToString();
        }

    }
}
