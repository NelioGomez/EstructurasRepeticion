namespace pjControlRegistroParticipantes
{
    public partial class frmParticipantes : Form
    {
        int num;
        int cjefe, cOPerario, cAdministrativo, cPracticante;
        public frmParticipantes()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void frmParticipantes_Load(object sender, EventArgs e)
        {
            num++;
            lblFecha.Text = DateTime.Now.ToString("d");
            lblNumero.Text = num.ToString("D4");
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Capturando los datos
            DateTime fecha, hora;
            int numero;
            string participante, cargo;
            participante = txtParticipantes.Text;
            numero = int.Parse(lblNumero.Text);
            fecha = DateTime.Parse(lblFecha.Text);
            hora = DateTime.Parse(lblHora.Text);
            cargo = cboCargo.Text;

            // contabilizar la cantidad segun los cargos
            switch (cargo)
            {

                case "Jefe": cjefe++; break;
                case "Administrativo": cAdministrativo++; break;
                case "Operario": cOPerario++; break;
                case "Practicante": cPracticante++; break;

            }

            //Imprimiendo el registro
            ListViewItem fila = new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);

            //Imprimiendo las estadisticas
            lvEstadisticas.Items.Clear();
            string[] elementosfila = new string[2];
            ListViewItem row;

            //añadimos la primera fila de lvEstadisticas
            elementosfila[0] = "Jefe";
            elementosfila[1] = cjefe.ToString();
            row = new ListViewItem(elementosfila);
            lvEstadisticas.Items.Add(row);

            //añadimos la segunda fila de lvEstadisticas
            elementosfila[0] = "Operario";
            elementosfila[1] = cOPerario.ToString();
            row = new ListViewItem(elementosfila);
            lvEstadisticas.Items.Add(row);

            //añadimos la tercera fila de lvEstadisticas
            elementosfila[0] = "Administrativo";
            elementosfila[1] = cAdministrativo.ToString();
            row = new ListViewItem(elementosfila);
            lvEstadisticas.Items.Add(row);

            //añadimos la cuarta fila de lvEstadisticas
            elementosfila[0] = "Practicante";
            elementosfila[1] = cPracticante.ToString();
            row = new ListViewItem(elementosfila);
            lvEstadisticas.Items.Add(row);

            //mostrando el nuevo numero de registro
            num++;
            lblNumero.Text = num.ToString("D4");

            //Limpiando los controles
            txtParticipantes.Clear();
            cboCargo.SelectedIndex = -1;
            txtParticipantes.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}