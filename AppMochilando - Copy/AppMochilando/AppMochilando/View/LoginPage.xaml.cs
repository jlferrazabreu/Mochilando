using AppMochilando.Api;
using AppMochilando.Model;
using Plugin.Connectivity;
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
        List<Cliente> listaCliente;
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void Logar()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSenha.Text))
                {
                    await DisplayAlert("Erro", "Informe o email e a senha", "OK");
                }
                else
                {

                    listaCliente = await ApiService.ObterCliente();
                    var cliente = listaCliente.Where(c => c.Email.ToLower() == txtEmail.Text.ToLower() && c.Senha.ToLower() == txtSenha.Text.ToLower()).ToList();
                    if (cliente.Count > 0)
                        await Navigation.PushAsync(new ListaClientePage());
                    else
                        await DisplayAlert("Erro", "Login ou senha errado.", "OK");
                }

            }
            else
            {
                await DisplayAlert("", "Sem Internet", "Ok");
            }
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Logar();
        }
    }
}