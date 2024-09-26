using System;
using System.Threading.Tasks;
using Firebase.Auth;
using AuroraDiary.Models;
using Firebase.Auth.Providers;
using User = AuroraDiary.Models.User;

namespace AuroraDiary.Services
{
    public static class FirebaseAuthManager
    {
        private static readonly FirebaseAuthClient _authClient;
        private static User currentUser;

        // Keep track of the currently signed-in user
        public static User GetCurrentUser()
        {
            return currentUser;
        }

        // Keep track of the currently signed-in user
        public static void SetCurrentUser(User value)
        {
            currentUser = value;
        }

        // Store last reason for failed auth to display in error message
        public static AuthErrorReason FailReason { get; set; } = AuthErrorReason.Undefined;

        // This is a static constructor, so it only runs once the first time
        // the FirebaseAuthManager class is used
        static FirebaseAuthManager()
        {
            // Initialize the authentication client using the details we copied from Firebase
            _authClient = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBNkgTRl3NCwB9gQ2z64eKyImtv_Edd5gk",
                AuthDomain = "aurora-diary11.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
        }

        // Register an account with Firebase
        public async static Task<bool> RegisterAccount(User user, string password)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                var credentials = await _authClient.CreateUserWithEmailAndPasswordAsync(user.Email, password);
                string uid = credentials.User.Uid;
                user.Id = uid;
                SetCurrentUser(user);

                return true;
            }
            catch (FirebaseAuthException fae)
            {
                // Store failure reason
                FailReason = fae.Reason;
                return false;
            }
            catch (Exception)
            {
                FailReason = AuthErrorReason.Undefined;
                return false;
            }
        }

        // Try to log in with Firebase
        public async static Task<bool> Login(string email, string password)
        {
            try
            {
                var credentials = await _authClient.SignInWithEmailAndPasswordAsync(email, password);
                var id = credentials.User.Uid;

                // Set the current user if login was successful
                SetCurrentUser(new User()
                {
                    Id = id,
                    Email = email
                });
                return true;
            }
            catch (FirebaseAuthException fae)
            {
                // Store failure reason
                FailReason = fae.Reason;
                return false;
            }
            catch (Exception)
            {
                FailReason = AuthErrorReason.Undefined;
                return false;
            }
        }
    }
}
