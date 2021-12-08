using AppMochilando.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMochilando.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaExcursao : ContentPage
    {

        public ListaExcursao()
        {
            BindingContext = new ListaExcursaoViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var vm = (ListaExcursaoViewModel)BindingContext;
            vm.AtualizarLista.Execute(null);
        }

    }
}