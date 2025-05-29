using GestionDeMatriculas.Pages;

namespace GestionDeMatriculas
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Estudiantes());

        }

        private void btnEstudianteFemenino_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EstudiantesFemeninos());
        }

        private void btnEstudianteMasculino_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EstudiantesMasculinos());
        }
    }
}