// MainPage.xaml.cs
using Blitzkarten.ViewModels;

namespace Blitzkarten
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            // Wait for the page to appear before setting the card view
            this.Appearing += (s, e) =>
            {
                viewModel.SetCardView(bk);
            };
        }
    }
}
