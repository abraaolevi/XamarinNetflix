using System;

using Xamarin.Forms;

namespace AppRouletteNetFlix
{
    public class MovieDetailsPage : ContentPage
    {
        public MovieDetailsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

