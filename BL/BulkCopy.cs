using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BL
{
    public class BulkCopy
    {

        public static ML.Result BulkCopySql(IFormFile file)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Leemos el archivo y creamos nuestro datatable
                DataTable DT = CSVtoDT(file);

                //Lo mandamos a la base de datos
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    context.Open();
                    using (SqlTransaction transaction = context.BeginTransaction())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(context, SqlBulkCopyOptions.Default, transaction))
                        {
                            try
                            {
                                bulkCopy.DestinationTableName = "DataTest";
                                bulkCopy.WriteToServer(DT);
                                transaction.Commit();
                                result.Correct = true;
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                context.Close();
                                result.Correct = false;
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static DataTable CSVtoDT(IFormFile file)
        {
            //Se crea el DT
            DataTable dt = new DataTable();
            try
            {
                using (StreamReader reader = new StreamReader(file.OpenReadStream()))
                {
                    //Creamos el header del DT
                    string[] encabezados = reader.ReadLine().Split(',');

                    //Agregamos la columnas al DT
                    foreach (string header in encabezados)
                    {
                        dt.Columns.Add(header.Trim());
                    }

                    //Se leen las demas lineas y las agrega al DT
                    while (!reader.EndOfStream)
                    {
                        string[] rows = reader.ReadLine().Split(',');
                        DataRow dataRow = dt.NewRow();

                        dataRow[0] = rows[0].ToString().Trim();
                        dataRow[1] = rows[1].ToString().Trim();
                        dataRow[2] = rows[2].ToString().Trim();
                        dataRow[3] = rows[3].ToString().Trim();

                        //Para la fecha
                        string[] Date = rows[4].Split(' ');
                        string data = Date[1].Replace('\"', ' ').Trim();
                        DateTime fechaConvertida = DateTime.ParseExact(data, "dd-MMM-yy", CultureInfo.InvariantCulture);
                        dataRow[4] = fechaConvertida.ToString("yyyy/MM/dd");

                        dataRow[5] = decimal.Parse(rows[5]);
                        dataRow[6] = int.Parse(rows[6]);
                        dataRow[7] = decimal.Parse(rows[7].Trim());
                        dataRow[8] = int.Parse(rows[8].ToString().Trim());
                        dataRow[9] = decimal.Parse(rows[9].Trim());
                        dataRow[10] = rows[10].ToString().Trim();
                        dataRow[11] = rows[11].ToString().Trim();
                        dataRow[12] = rows[12].ToString().Trim();
                        var exponencial = rows[13].Trim();
                        Int64 number = Int64.Parse(exponencial, System.Globalization.NumberStyles.Float);
                        dataRow[13] = number;
                        dataRow[14] = rows[14].ToString().Trim();
                        dataRow[15] = rows[15].ToString().Trim();

                        dt.Rows.Add(dataRow);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo CSV: " + ex.Message);
            }
            return dt;
        }
    }
}