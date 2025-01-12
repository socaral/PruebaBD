using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PruebaBD
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            


        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
            {
                CounterBtn.Text = $"Clicked {count} time";

                string connstring = @"server=localhost;userid=root;password=Socaral160375;database=prueba";
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connstring);
                    conn.Open();

                    string query = "SELECT * FROM tablaprueba;";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tablaprueba");
                    DataTable dt = ds.Tables["tablaprueba"];

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            //Console.Write("Valor" + row[col] + "\t");
                            DisplayAlert("Hola", "Valor: " + row[col], "OK");
                        }

                        Console.Write("\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
                
            else

                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
