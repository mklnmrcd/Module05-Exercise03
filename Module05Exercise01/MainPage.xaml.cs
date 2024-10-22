using MySql.Data.MySqlClient;
using Module05Exercise01.Services;

namespace Module05Exercise01
{
    public partial class MainPage : ContentPage
    {

        private readonly DatabaseConnectionService _dbConnectionService;


        public MainPage()
        {
            InitializeComponent();

            //Initialize database connection
            _dbConnectionService = new DatabaseConnectionService();
        }


        private async void OnTestConnectionClicked(object sender, EventArgs e)
        {
            var connectionString = _dbConnectionService.GetConnectionString();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    ConnectionStatusLabel.Text = "Connection Successful";
                    ConnectionStatusLabel.TextColor = Color.FromArgb("#8B5FBF");
                }
            }
            catch (Exception ex)
            {
                ConnectionStatusLabel.Text = $"Connection Failed: {ex.Message}";
                ConnectionStatusLabel.TextColor = Color.FromArgb("#FF0000");
            }
        }

        private async void OpenViewEmployee(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ViewEmployee");
        }
    }

}
