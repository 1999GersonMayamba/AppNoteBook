using AppCloudEditor.INFO;
using AppCloudEditor.INTERFACE;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCloudEditor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{

        public SQLiteConnection conn;
        private List<string> ListaCores = new List<string> { "#BECAE6", "#209EBB", "#023047", "#FFB701", "#FC8500" };

        public Home ()
		{
			InitializeComponent ();
            //Buscar a connection string da base de dados
            conn = DependencyService.Get<Isqlite>().GetConnectionBD();
            //Criar a tabela na base de dados
            conn.CreateTable<Tb_Nota>();
        }

        /// <summary>
        /// Quando a pagaina aparecer só assim carrega os dados
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing(); // seu código aqui; 
            CarregarListaNotas();

        }

        /// <summary>
        /// Quando a apagina começar a desaparecer
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }

        /// <summary>
        /// 
        /// </summary>
        private async void CarregarListaNotas()
        {

            try
            {
                //Trazer a lista de notas que se encontra na base de dados
                var Notas = (from k in conn.Table<Tb_Nota>() select k).ToList();

                Random random = new Random();

                //Se tiver notas na lista
                if (Notas.Count > 0)
                {
                    foreach(var x in Notas)
                    {
                        x.Cor = ListaCores[random.Next(0, 4)];
                    }
                    ListaDeNotas.ItemsSource = Notas;
                }
                else
                {

                }

                // IndicadorDeActividade.IsRunning = true;

                //List<Tb_Nota> tb_Notas = new List<Tb_Nota>()
                //{

                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString() },
                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString() },
                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString() },
                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString() },
                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString() },
                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString()},
                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString() },
                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString() },
                //    new Tb_Nota { Titulo = "Receita Culinaria", Nota = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has", Data_Nota = DateTime.Now.Date.ToShortDateString() }
                //};


                //ListaDeNotas.ItemsSource = tb_Notas;
                // IndicadorDeActividade.IsRunning = false;
            }
            catch (Exception ex)
            {
               await DisplayAlert("ERRO", ex.Message, "OK");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListaDeNotas_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            try
            {

                var Nota = e.Item as Tb_Nota;

                //Deselect Item
                ((ListView)sender).SelectedItem = null;
                //Chamar a pagina de exibir a nota para poder ser editado
                await Navigation.PushAsync(new MainPage(Nota));
            }
            catch(Exception ex)
            {
                await  DisplayAlert("ERRO", ex.Message, "OK");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
               await Navigation.PushAsync(new MainPage());
            }
            catch(Exception ex)
            {
              await  DisplayAlert("ERRO", ex.Message, "OK");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Nova_Nota_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
               await DisplayAlert("ERRO", ex.Message, "OK");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Editar_Clicked(object sender, EventArgs e)
        {
            try
            {

                var Item = ((MenuItem)sender);
                var Nota = Item.CommandParameter as Tb_Nota;

                //Deselect Item
               // ((ListView)sender).SelectedItem = null;
                //Chamar a pagina de exibir a nota para poder ser editado
                await Navigation.PushAsync(new MainPage(Nota));
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERRO", ex.Message, "OK");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Item = ((MenuItem)sender);
                var Nota = Item.CommandParameter; 

                //Eliminar a nota da base de dados
                int Resultado = conn.Delete<Tb_Nota>(Nota);

                if (Resultado == 1)
                {
                    DependencyService.Get<IMessage>().ShortAlert("Nota eliminado com sucesso");
                    CarregarListaNotas();
                }
                else
                {
                    DependencyService.Get<IMessage>().LongAlert("Não foi possivél eliminar a sua nota");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("NOTA", ex.Message, "OK");
            }

        }
    }
}