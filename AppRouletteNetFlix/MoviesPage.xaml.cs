using System;
using System.Collections.Generic;

using Xamarin.Forms;
using AppRouletteNetFlix.Service;
using AppRouletteNetFlix.Model;

namespace AppRouletteNetFlix
{
    public partial class MoviesPage : ContentPage
    {
        MovieService service = new MovieService();

        public MoviesPage()
        {
            InitializeComponent();
        }

        async void SearchBar_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
			// verifica a quantidade de caracteres digitados
			if (e.NewTextValue.Length < 6) {

				// esconde o listview e exibe o label coma mensagem
				lvwMovies.IsVisible = false;
				lblMsg.IsVisible = true;
				lblMsg.Text = "Digite pelo menos 6 caracteres.";
                return;
            }

            List<Movie> movies = await service.LocalizarFilmesPorAtor(e.NewTextValue);

            if (movies == null || movies.Count == 0) {

				// esconde o listview e exibe o label
				// exibe a mensagem no label
				lvwMovies.IsVisible = false;
                lblMsg.IsVisible = true;
                lblMsg.Text = "Nenhum filme encontrado";
                lblMsg.TextColor = Color.Red;
                return;

            }

			// exibe o listview e esconde o label 
			// exibe a lista de filmes
			lvwMovies.IsVisible = true;
            lblMsg.IsVisible = false;

            lvwMovies.ItemsSource = movies;
       }

        async void LvwMovies_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) {
                return;
            }

			// obtem o item selecionado
			var movie = e.SelectedItem as Movie;

			// deseleciona o item do listview
			lvwMovies.SelectedItem = null;

			// chama a pagina MovieDetailsPage
			await Navigation.PushAsync(new MovieDetailsPage(movie));
        }
    }
}
