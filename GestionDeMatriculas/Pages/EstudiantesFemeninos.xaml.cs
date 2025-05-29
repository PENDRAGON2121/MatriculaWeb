using GestionDeMatriculas.ViewModels;

namespace GestionDeMatriculas.Pages;

public partial class EstudiantesFemeninos : ContentPage
{
    private EstudiantesViewModel viewModel;
    public EstudiantesFemeninos()
	{
		InitializeComponent();
        BindingContext = new EstudiantesViewModel();
        viewModel = new EstudiantesViewModel();
        BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.ObtenerEstudiantesFemeninosAsync();
    }
}