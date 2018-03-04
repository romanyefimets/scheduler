using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class AccountManagement
    {
        private Dictionary<string, string> login = new Dictionary<string, string>();
        private string path = "C:/Users/Boggie/Desktop/scheduler/Scheduler/Scheduler/bin/Debug/Files/Logins.txt";

        // Loads all the usernames and passwords into a dictionary
        public void LoadFromFile()
        {
            // Need to add an try/catch for if file doesn't exist
            using (StreamReader sr = new StreamReader(path))
            {
                String temp;

                while ((temp = sr.ReadLine()) != null)
                {
                    String[] kv = temp.Split(' ');
                    login.Add(kv[0], kv[1]);
                }
            }
        }

        // Saving the dictionary of usernames and passwords to a textfile
        public void SaveToFile()
        {
            if (File.Exists(path))


                // using the streamwriter to write to a text file
                using (StreamWriter sw = new StreamWriter(path))
                {
                    using (MD5 myMD5 = MD5.Create())
                    {
                        // Iterating through the dictionary and printing the usernames and passwords in a text file
                        foreach (KeyValuePair<string, string> kvp in login)
                        {
                            sw.WriteLine(kvp.Key + " " + kvp.Value);
                        }
                    }
                }
        }

        // If you can create user then return true
        public bool CreateNewUser(string username, string password)
        {
            using (MD5 myMD5 = MD5.Create())
            {
                if (login.ContainsKey(username))
                {
                    // User already exists
                    return false;
                }
                else
                {
                    // create user
                    login.Add(username, GetMd5Hash(myMD5, password));
                    return true;
                }
            }
        }

        // This function takes in a username and password, and checks
        // if the user 0 - exists, 1 - right username but wrong password, 
        // 2 - wrong username
        public int TryLogin(string username, string password)
        {
            using (MD5 myMD5 = MD5.Create())
            {
                // Generates the hash of the password
                string hash = GetMd5Hash(myMD5, password);

                if (UsernameExists(username))
                {

                    if (hash == login[username])
                        // Login successful
                        return 0;

                    // Right username, wrong password
                    return 1;
                }
                else
                {
                    // Wrong username
                    return 2;
                }
            }
        }

        // Checks if a username already exists
        public bool UsernameExists(string username)
        {
            if (login.ContainsKey(username))
                return true;

            return false;
        }

        // Microsofts .NET hashfunction
        public string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}