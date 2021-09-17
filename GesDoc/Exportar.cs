using System;
using System.Windows.Forms;

namespace GesDoc
{
    class Exportar
    {
        public void ExportarDataGridViewExcel(DataGridView grd)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColumna = 0;
                foreach (DataGridViewColumn columna in grd.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColumna++;
                    excel.Cells[1, IndiceColumna] = columna.Name;
                }
                int IndiceFila = 0;
                foreach (DataGridViewRow fila in grd.Rows) //Aquí leemos las filas de las columnas leídas
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in grd.Columns)
                    {
                        IndiceColumna++;
                        excel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                    }
                }
                excel.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No hay Registros a Exportar.");
            }



        }
    }
}
