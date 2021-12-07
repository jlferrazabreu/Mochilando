using AppMochilando.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMochilando.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void Logar()
        {
            var Clientes = await ApiService.ObterCliente();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Logar();
        }
    }
}