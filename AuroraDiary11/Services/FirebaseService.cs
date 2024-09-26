using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading.Tasks;

namespace AuroraDiary.Services
{
    public class FirebaseService
    {
        private readonly FirebaseApp _firebaseApp;

        public FirebaseService()
        {
            // Check if the file exists
            string jsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serviceAccountKey.json");

            if (!File.Exists("C:\\Users\\Admin\\source\\repos\\AuroraDiary11\\AuroraDiary11\\Platforms\\Android\\google-services.json"))
            {
                throw new FileNotFoundException($"The Firebase credentials file was not found: {jsonPath}");
            }

            _firebaseApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(jsonPath),
            });
        }

        public async Task<string> SignInWithEmailPasswordAsync(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);
                if (user != null)
                {
                    // Perform additional checks if necessary
                    return user.Uid;
                }
            }
            catch (FirebaseAuthException ex)
            {
                // Handle error
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                throw;
            }
            return null;
        }
    }
}
