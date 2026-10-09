using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Ignacio_Práctica1
{
    public partial class LoginWindow : Window
    {
        private string[,] usuariosEnMemoria = new string[,]
        {
            { "admin", "1234" },
            { "alumno", "dam2" },
            { "gamer", "retro2026" }
        };

        private int intentosFallidos = 0;
        private DispatcherTimer timer;
        private int segundos = 5;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = TxtUsuario.Text.Trim();
            string pass = TxtPassword.Password;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                TxtMensaje.Foreground = (Brush)new BrushConverter().ConvertFromString("#FFCC00");
                TxtMensaje.Text = "Introduzca datos";
                return;
            }

            int indice = -1;
            for (int i = 0; i < usuariosEnMemoria.GetLength(0); i++)
            {
                if (usuariosEnMemoria[i, 0].ToLower() == user.ToLower())
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1)
            {
                TxtMensaje.Foreground = (Brush)new BrushConverter().ConvertFromString("#FF0055");
                TxtMensaje.Text = "El usuario introducido no existe";
                return;
            }

            if (usuariosEnMemoria[indice, 1] != pass)
            {
                intentosFallidos++;
                TxtMensaje.Foreground = (Brush)new BrushConverter().ConvertFromString("#FF0055");

                if (intentosFallidos >= 3)
                {
                    // Iniciar cuenta regresiva de 5 segundos
                    segundos = 5;
                    TxtUsuario.IsEnabled = false;
                    TxtPassword.IsEnabled = false;
                    BtnLogin.IsEnabled = false;

                    TxtMensaje.Text = $"Bloqueado por seguridad. Espere {segundos} segundos...";

                    timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += (s, args) =>
                    {
                        segundos--;
                        if (segundos > 0)
                        {
                            TxtMensaje.Text = $"Bloqueado por seguridad. Espere {segundos} segundos...";
                        }
                        else
                        {
                            timer.Stop();
                            TxtUsuario.IsEnabled = true;
                            TxtPassword.IsEnabled = true;
                            BtnLogin.IsEnabled = true;
                            TxtPassword.Password = "";
                            intentosFallidos = 0;

                            TxtMensaje.Foreground = (Brush)new BrushConverter().ConvertFromString("#FFCC00");
                            TxtMensaje.Text = "Acceso desbloqueado. Vuelva a intentarlo.";
                        }
                    };
                    timer.Start();
                }
                else
                {
                    TxtMensaje.Text = $"La contraseña introducida no es correcta (Intento {intentosFallidos}/3)";
                }
                return;
            }

            intentosFallidos = 0;
            TxtMensaje.Foreground = (Brush)new BrushConverter().ConvertFromString("#00FF66");
            TxtMensaje.Text = "Inicio de sesión exitoso. Redirigiendo...";

            MainWindow principal = new MainWindow(usuariosEnMemoria[indice, 0]);
            principal.Show();
            this.Close();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}