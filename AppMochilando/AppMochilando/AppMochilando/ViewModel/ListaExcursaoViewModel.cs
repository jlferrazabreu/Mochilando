using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using AppMochilando.Model;
using AppMochilando.View;
using Xamarin.Forms;

namespace AppMochilando.ViewModel
{
    class ListaExcursaoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler Property;
        public event PropertyChangedEventHandler PropertyChanged;

        public string ParametroBusca { get; set; }

        bool estaAtualizando = false;
        public bool EstaAtualizando
        {
            get => estaAtualizando;
            set
            {
                estaAtualizando = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EstaAtualizando"));
            }
        }

        ObservableCollection<Excursao> listaExcursao = new ObservableCollection<Excursao>();

        public ObservableCollection<Excursao> ListaExcursao
        {
            get => listaExcursao;
            set => ListaExcursao = value;
        }

        public ICommand CadastroExcursao
        {
            get
            {
                return new Command(async () =>
                {
                    await Shell.Current.Navigation.PushAsync(new CadastroExcursao());
                });

            }
        }

        public ICommand AtualizarLista
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (EstaAtualizando)
                            return;

                        EstaAtualizando = true;

                        List<Excursao> tmp = await App.Database.GetAllRows();

                        ListaExcursao.Clear();
                        tmp.ForEach(item => listaExcursao.Add(item));
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                    }
                    finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        }

        public ICommand Buscar
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (EstaAtualizando)
                            return;

                        EstaAtualizando = true;

                        List<Excursao> tmp = await App.Database.Serch(ParametroBusca);

                        ListaExcursao.Clear();
                        tmp.ForEach(item => listaExcursao.Add(item));
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                    }
                    finally
                    {
                        EstaAtualizando = false;
                    }

;
                });
            }
        }

        public ICommand DetalhesExcursao
        {
            get
            {
                return new Command<int>(async (int id) =>
                {
                    await Shell.Current.GoToAsync($"//CadastroExcursao?parametro_id={id}");
                });
            }
        }

        public ICommand Remover
        {
            get
            {
                return new Command<int>(async (int id) =>
                {
                    try
                    {
                        bool conf = await Application.Current.MainPage.DisplayAlert("Tem certeza que deseja Remover?", "Excluir", "Sim", "Não");
                        if(conf)
                        {
                            await App.Database.Delete(id);
                            AtualizarLista.Execute(null);
                        }
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                    }
                    finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        }
    }

}