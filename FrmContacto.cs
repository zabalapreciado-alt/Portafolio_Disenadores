using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortafolioDiseñadores
{
    public partial class FrmContacto : Form
    {
        public FrmContacto()
        {
            InitializeComponent();
        }
        private void FrmContacto_Load(object sender, EventArgs e)
        {
            lblContacto.Text = "Email: mariaclara@correo.com\nTel: +57 300 123 4567\nInstagram: @mariaclara.design";
        }
    }
}
