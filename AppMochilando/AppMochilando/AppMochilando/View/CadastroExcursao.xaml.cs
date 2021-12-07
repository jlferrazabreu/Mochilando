using AppMochilando.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMochilando.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroExcursao : ContentPage
    {
        public CadastroExcursao()
        {
            InitializeComponent();

            BindingContext = new CadastroExcursaoViewModel();
        }
        protected override async void OnAppearing()
        {
            var vm = (CadastroExcursaoViewModel)BindingContext;
            if (vm.Id == 0)
            {
                vm.NovaExcursao.Execute(null);
            }
        }
    }
}