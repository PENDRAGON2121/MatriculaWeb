using GestionDeMatriculas.ViewModels;

namespace GestionDeMatriculas.Pages;

public partial class EstudiantesMasculinos : ContentPage
{

    private EstudiantesViewModel viewModel;
    public EstudiantesMasculinos()
	{
		InitializeComponent();
        BindingContext = new EstudiantesViewModel();
        viewModel = new EstudiantesViewModel();
        BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.ObtenerEstudiantesMasculinosAsync();
    }
}