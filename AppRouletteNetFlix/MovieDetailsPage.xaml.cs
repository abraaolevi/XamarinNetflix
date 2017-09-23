using System;
using System.Collections.Generic;

using Xamarin.Forms;
using AppRouletteNetFlix.Model;

namespace AppRouletteNetFlix
{
    public partial class MovieDetailsPage : ContentPage
    {
        public MovieDetailsPage(Movie movie)
        {
			// verifica se o objeto é null 
			// lança a exceção
            if (movie == null) {
                throw new ArgumentNullException(nameof(movie));
            }

            InitializeComponent();


			// vincula o filme ao BindingContext 
			// para fazer o databinding na view
			BindingContext = movie;
        }
    }
}
