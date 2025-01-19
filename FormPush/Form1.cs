using System.Data;

namespace FormPush
{
    public partial class Form1 : Form
    {
        string fileName = "c:\\Empleados.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            //openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            openFileDialog1.ShowDialog();

            string archivo = openFileDialog1.FileName;


            if (archivo.Trim().Length > 0)
            {
                try
                {
                    string line;
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("Tipo de registro");
                    dt.Columns.Add("Cedula");
                    dt.Columns.Add("Ocupacion");
                    dt.Columns.Add("Salario");
                    dt.Columns.Add("Fecha de ingreso");
                    dt.Columns.Add("Estatus laboral");

                    // lee linea a linea 
                    System.IO.StreamReader file = new System.IO.StreamReader(archivo);
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] registro = line.Split(',');
                        DataRow fila = dt.NewRow();
                        fila["Tipo de registro"] = registro[0];
                        fila["Cedula"] = registro[1];
                        fila["Ocupacion"] = registro[2];
                        fila["Salario"] = registro[3];
                        fila["Fecha de ingreso"] = registro[4];
                        fila["Estatus laboral"] = registro[5];

                        dt.Rows.Add(fila);
                    }

                    file.Close();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
                catch (Exception  ex)
                {
                   Console.WriteLine(ex.Message);
                }
                
            }
            

        }
    }
}
