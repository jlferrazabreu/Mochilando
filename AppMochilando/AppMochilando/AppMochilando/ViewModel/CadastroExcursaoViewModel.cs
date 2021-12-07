using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using AppMochilando.Model;

namespace AppMochilando.ViewModel
{
    [QueryProperty("PegarIdNavegacao", "parametro_id")]
    class CadastroExcursaoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string nome, origem, destino, descricao, nomeImagem;
        int id;
        DateTime? data;
        decimal? valor;

        public string PegarIdNavegacao
        {
            set
            {
                int id_parametro = Convert.ToInt32(Uri.UnescapeDataString(value));
                ObterExcursao.Execute(id_parametro);
            }
        }

        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nome"));
            }
        }
        public string Origem
        {
            get => origem;
            set
            {
                origem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Origem"));
            }
        }
        public string Destino
        {
            get => destino;
            set
            {
                destino = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Destino"));
            }
        }
        public string Descricao
        {
            get => descricao;
            set
            {
                descricao = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Descricao"));
            }
        }
        public string NomeImagem
        {
            get => nomeImagem;
            set
            {
                nomeImagem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NomeImagem"));
            }
        }
        public int Id
        {
            get => id;
        }
        public DateTime? Data
        {
            get => data;
            set
            {
                data = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Data"));
            }
        }
        public decimal? Valor
        {
            get => valor;
            set
            {
                valor = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Valor"));
            }
        }

        public ICommand NovaExcursao
        {
            get => new Command(() =>
            {
                Nome = String.Empty;
                Origem = String.Empty;
                Destino = String.Empty;
                Data = DateTime.Now;
                Valor = null;
                Descricao = String.Empty;
                NomeImagem = String.Empty;
                //Application.Current.MainPage.DisplayAlert("Alerta", "vc clicou", "OK");
            });
        }

        public ICommand SalvarExcursao
        {
            get => new Command(async () =>
            {
                try
                {
                    Excursao model = new Excursao()
                    {
                        Nome = this.Nome,
                        Origem = this.Origem,
                        Destino = this.Destino,
                        Data = this.Data,
                        Valor = this.Valor,
                        Descricao = this.Descricao,
                        NomeImagem = this.NomeImagem
                    };
                    if (this.Id == 0)
                    {
                        await App.Database.Insert(model);
                    }
                    else
                    {
                        model.Id = this.Id;
                        await App.Database.Update(model);
                    }

                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Excusão Salva", "Ok");

                    await Shell.Current.GoToAsync("//Excursoes");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }

            });
        }

        public ICommand ObterExcursao
        {
            get => new Command<int>(async (int id) =>
            {
                try
                {
                    Excursao model = await App.Database.GetById(id);
                    this.Nome = model.Nome;
                    this.Origem = model.Origem;
                    this.Destino = model.Destino;
                    this.Data = model.Data;
                    this.Valor = model.Valor;
                    this.Descricao = model.Descricao;
                    this.NomeImagem = model.NomeImagem;
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }
            });
        }
    }
}
