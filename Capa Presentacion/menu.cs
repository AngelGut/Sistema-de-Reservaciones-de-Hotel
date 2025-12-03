using MaterialSkin.Controls;
using MaterialSkin;
using System.Drawing;

namespace Capa_Presentacion
{
    public partial class menu : MaterialForm
    {
        public menu()
        {
            InitializeComponent();

            // Configurar MaterialSkin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600,
                Primary.Blue900,
                Primary.Blue100,
                Accent.LightBlue200,
                TextShade.WHITE
            );

            // Cambiar color del label manualmente
            lblNombreC.ForeColor = Color.White;
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
