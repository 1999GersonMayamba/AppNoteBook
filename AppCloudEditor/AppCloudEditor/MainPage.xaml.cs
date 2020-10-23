using AppCloudEditor.INFO;
using AppCloudEditor.INTERFACE;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCloudEditor
{
    public partial class MainPage : ContentPage
    {

        public SQLiteConnection conn;
        string ID_Nota = null;
        int Resultado = 0;
        Tb_Nota _tb_Nota;

        public MainPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<Isqlite>().GetConnectionBD();
        }


        public MainPage(Tb_Nota tb_Nota)
        {
            InitializeComponent();
            conn = DependencyService.Get<Isqlite>().GetConnectionBD();
            Titulo.Text = tb_Nota.Titulo;
            Editor_Nota.Text = tb_Nota.Nota;
            ID_Nota = tb_Nota.Id;
            _tb_Nota = tb_Nota;
        }

        /// <summary>
        /// Evento invocado quando se clicar no botão salvar, ele em duas funções ao mesmo tempo
        /// Salvar a nota, e actualizar a nota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Salvar_Nota_Icon_Clicked(object sender, EventArgs e)
        {
            try
            {

                if(string.IsNullOrEmpty(Titulo.Text))
                {
                    DependencyService.Get<IMessage>().ShortAlert("Preencher o titulo da sua nota");
                }
                else if(string.IsNullOrEmpty(Editor_Nota.Text))
                {
                    DependencyService.Get<IMessage>().ShortAlert("Preencher o conteudo da sua nota");
                }
                else
                {

                    if(_tb_Nota != null)
                    {
                        //Eliminar a nota da base de dados
                        Resultado = conn.Delete<Tb_Nota>(_tb_Nota.Id);

                        if (Resultado == 1)
                        {
                            _tb_Nota.Nota = Editor_Nota.Text;
                            _tb_Nota.Data_Nota = DateTime.Now.Date.ToShortDateString();
                            Resultado = conn.Insert(_tb_Nota);
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            DependencyService.Get<IMessage>().LongAlert("Não foi possivél actualizar a sua nota");
                        }
                    }
                    else
                    {
                        //Montar o objecto, a estrutura para pode fazer o insert
                        Tb_Nota tb_Nota = new Tb_Nota();
                        tb_Nota.Nota = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";//Editor_Nota.Text;
                        tb_Nota.Titulo = Titulo.Text;
                        tb_Nota.Id = Guid.NewGuid().ToString();
                        tb_Nota.Data_Nota = DateTime.Now.ToShortDateString();
                        conn.CreateTable<Tb_Nota>();
                        Resultado = conn.Insert(tb_Nota);
                    }                                    

                   if(Resultado == 1)
                    {
                        DependencyService.Get<IMessage>().ShortAlert("Nota Salvo Com Sucesso");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                      await DisplayAlert("NOTA", "Não foi possivél salvar a sua nota", "OK");
                    }
                }
                
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("UNIQUE constraint failed"))
                {
                    await DisplayAlert("NOTA", "Já existe uma nota com esse titulo, porfavor inseri um titulo diferente.", "OK");
                }
                else
                {
                    await DisplayAlert("NOTA", "Já existe uma nota com esse titulo, porfavor inseri um titulo diferente.", "OK");

                }

            }

        }


        /// <summary>
        /// Evento invocado quando se clicar no botão eliminar para eliminar a nota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Eliminar_Nota_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (_tb_Nota != null)
                {
                    //Eliminar a nota da base de dados
                    int Resultado = conn.Delete<Tb_Nota>(_tb_Nota.Id);

                    if (Resultado == 1)
                    {
                        DependencyService.Get<IMessage>().ShortAlert("Nota eliminado com sucesso");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        DependencyService.Get<IMessage>().LongAlert("Não foi possivél eliminar a sua nota");
                    }
                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("NOTA", ex.Message, "OK");
            }

        }
    }
}
