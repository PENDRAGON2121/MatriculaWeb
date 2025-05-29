using GestionDeMatriculas.Logic;
using GestionDeMatriculas.ViewModels;

namespace GestionDeMatriculas.Pages;

public partial class Estudiantes : ContentPage
{
    private EstudiantesViewModel viewModel;

    public Estudiantes()
	{
		InitializeComponent();
		BindingContext = new EstudiantesViewModel();
        viewModel = new EstudiantesViewModel();
        BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.ObtenerEstudiantesAsync();
    }

}