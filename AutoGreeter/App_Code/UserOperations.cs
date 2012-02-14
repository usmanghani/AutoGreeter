using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoGreeter
{
    using AutoGreeter.Models;
    using System.Security.Cryptography;

    public class UserOperations
    {
        public static User CreateUser(string username, string password, string email, string facebookHandle = null, string twitterHandle = null)
        {
            string salt = ComputeSalt(password);

            string encryptedPassword = EncryptPassword(password, salt);
            string token = CreateToken(username, salt);

            User user = new User();
            user.Salt = salt;
            user.Username = username;
            user.PasswordHash = encryptedPassword;
            user.Email = email;
            user.FacebookHandle = facebookHandle;
            user.TwitterHandle = twitterHandle;

            return user;
        }


        public static bool LoginUser(string usernameOrEmail, string password, bool rememberMe = false)
        {

            string encryptedPassword = EncryptPassword(password, profile.Salt);
            if (encryptedPassword != profile.PasswordHash)
            {
                // we failed to log in the user.
                result.Reason = LoginFailureReason.InvalidPassword;
                return result;
            }

            result.Token = SessionOperations.CreateOrReturnSession(profile, rememberMe);
            result.Success = true;

            return result;
        }

        public static void LogoutUser(string token)
        {
            try
            {
                SessionManager.Current.RemoveSession(token);
            }
            catch (SessionNotFoundException)
            {
                // ignore.
            }
        }

        public static bool ChangePassword(string token, string oldPassword, string newPassword)
        {
            try
            {
                UserSession session = SessionManager.Current.GetSession(token);
                UserProfile profile = Repositories.Repositories.Users.GetItemByHandle(session.UserProfile);

                if (EncryptPassword(oldPassword, profile.Salt).Equals(profile.PasswordHash))
                {
                    profile.PasswordHash = EncryptPassword(newPassword, profile.Salt);
                    Repositories.Repositories.Users.Save(profile);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (SessionNotFoundException)
            {
                return false;
            }
        }

        public static UserProfile GetUserProfileFromSession(string token)
        {
            try
            {
                UserSession session = SessionManager.Current.GetSession(token);
                UserProfile profile = Repositories.Repositories.Users.GetItemByHandle(session.UserProfile);

                return profile;
            }
            catch (SessionNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        /// Creates the token.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <returns></returns>
        public static string CreateToken(UserProfile profile)
        {
            return CreateToken(profile.UserID, profile.Salt);
        }

        public static void UpdateUserCurrentTopic(UserProfile profile, GetNextTopicResult result)
        {
            TopicHistoryItem item = new TopicHistoryItem();
            item.Topic = new TopicHandle(result.TargetTopic);
            item.IsPseudoTopic = result.IsPseudo;
        }


        private static string CalculateHash(string str)
        {
            return BitConverter.ToString(new SHA512CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str)));
        }

        private static string ComputeSalt(string password)
        {
            return CalculateHash(string.Format("{0}--{1}", DateTime.UtcNow, password));
        }

        private static string EncryptPassword(string password, string salt)
        {
            return CalculateHash(string.Format("{0}--{1}", salt, password));
        }

        private static string CreateToken(string username, string salt)
        {
            return string.Concat(username, ",", salt);
        }
    }
}