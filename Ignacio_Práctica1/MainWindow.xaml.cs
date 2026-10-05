using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PortalVideojuegos
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OcultarVistas()
        {
            VistaTienda.Visibility = Visibility.Collapsed;
            VistaPerfil.Visibility = Visibility.Collapsed;
            VistaGenerica.Visibility = Visibility.Collapsed;

            // Restablece el botón de perfil a su fondo oscuro
            BtnPerfil.Background = (Brush)new BrushConverter().ConvertFromString("#20153D");
        }

        private void BtnTienda_Click(object sender, RoutedEventArgs e)
        {
            OcultarVistas();
            VistaTienda.Visibility = Visibility.Visible;
            TxtEstado.Text = "ACCESO: Catálogo Retro";
        }

        private void BtnComunidad_Click(object sender, RoutedEventArgs e)
        {
            OcultarVistas();
            TxtTituloGenerico.Text = "👾 COMUNIDAD ARCADE";
            VistaGenerica.Visibility = Visibility.Visible;
            TxtEstado.Text = "ACCESO: Sala de Comunidad";
        }

        private void BtnSoporte_Click(object sender, RoutedEventArgs e)
        {
            OcultarVistas();
            TxtTituloGenerico.Text = "💾 SOPORTE TÉCNICO";
            VistaGenerica.Visibility = Visibility.Visible;
            TxtEstado.Text = "ACCESO: Centro de Ayuda";
        }

        private void BtnPerfil_Click(object sender, RoutedEventArgs e)
        {
            OcultarVistas();
            VistaPerfil.Visibility = Visibility.Visible;
            // Se ilumina en cian para destacar que está activo
            BtnPerfil.Background = (Brush)new BrushConverter().ConvertFromString("#00F0FF");
            TxtEstado.Text = "ACCESO: Perfil de Usuario";
        }

        private void BtnDestacados_Click(object sender, RoutedEventArgs e)
        {
            OcultarVistas();
            VistaTienda.Visibility = Visibility.Visible;
            TxtEstado.Text = "ACCESO: Títulos Destacados";
        }

        private void BtnMisJuegos_Click(object sender, RoutedEventArgs e)
        {
            OcultarVistas();
            TxtTituloGenerico.Text = "🕹 MIS CARTUCHOS / JUEGOS";
            VistaGenerica.Visibility = Visibility.Visible;
            TxtEstado.Text = "ACCESO: Biblioteca Personal";
        }

        private void BtnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            OcultarVistas();
            TxtTituloGenerico.Text = "⚙ CONFIGURACIÓN ARCADE";
            VistaGenerica.Visibility = Visibility.Visible;
            TxtEstado.Text = "ACCESO: Ajustes del Sistema";
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnJugar_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string juego = btn.Tag.ToString();
            TxtEstado.Text = "CARGANDO: " + juego + "... [INSERT COIN]";
        }
    }
}
