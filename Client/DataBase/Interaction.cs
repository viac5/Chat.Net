using Npgsql;
using System.Windows.Input;

namespace Client.DataBase
{
    internal class Interaction
    {
        Config config = new Config();

        IdentificatoinKey ik = new IdentificatoinKey();
        ActionsAuthorizationData autData = new ActionsAuthorizationData();

        public void RegistrtationUser(string login, string password)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(config.ConnectionString))
            {
                try
                {
                    string key = ik.CreateKey();
                    connection.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO user_chat (login, password, identification_key, date_time) VALUES (@lg, @pass, @idK, @dt);", connection))
                    {
                        cmd.Parameters.Add("@lg", NpgsqlTypes.NpgsqlDbType.Text).Value = login;
                        cmd.Parameters.Add("@pass", NpgsqlTypes.NpgsqlDbType.Text).Value = password;
                        cmd.Parameters.Add("@idK", NpgsqlTypes.NpgsqlDbType.Text).Value = key;
                        cmd.Parameters.Add("@dt", NpgsqlTypes.NpgsqlDbType.Text).Value = DateTime.Now.ToShortDateString();
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();

                    autData.SaveData(login, password, key);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка подключения: {ex.Message}");
                }
            }
        }
        public bool TheUserAlreadyExists(string login)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(config.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand($"SELECT * FROM user_chat WHERE login = @lg;", connection))
                    {
                        cmd.Parameters.Add("@lg", NpgsqlTypes.NpgsqlDbType.Text).Value = login;
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                return true;
                            else
                                return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка подключения: {ex.Message}");
                    return false;
                }
            }
        }
        public string[] ReadUserData(string login)
        {
            string[] key = new string[3];
            using (NpgsqlConnection connection = new NpgsqlConnection(config.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand($"SELECT * FROM user_chat WHERE login = @lg;", connection))
                    {
                        cmd.Parameters.Add("@lg", NpgsqlTypes.NpgsqlDbType.Text).Value = login;
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                key[0] = reader.GetString(0);
                                key[1] = reader.GetString(1);
                                key[2] = reader.GetString(2);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка подключения: {ex.Message}");
                }
            }
            return key;
        }
        public void WriteProfileText(string nickname, string profileText)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(config.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Проверяем, существует ли пользователь с указанным именем
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand($"SELECT COUNT(*) FROM user_profile WHERE nickname = @nn;", connection))
                    {
                        checkCmd.Parameters.Add("@nn", NpgsqlTypes.NpgsqlDbType.Text).Value = nickname;

                        int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            // Если пользователь существует, обновляем его профиль
                            using (NpgsqlCommand updateCmd = new NpgsqlCommand($"UPDATE user_profile SET description = @desc WHERE nickname = @nn;", connection))
                            {
                                updateCmd.Parameters.Add("@nn", NpgsqlTypes.NpgsqlDbType.Text).Value = nickname;
                                updateCmd.Parameters.Add("@desc", NpgsqlTypes.NpgsqlDbType.Text).Value = profileText;
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Если пользователь не существует, добавляем новую запись
                            using (NpgsqlCommand insertCmd = new NpgsqlCommand($"INSERT INTO user_profile (nickname, description) VALUES (@nn, @desc);", connection))
                            {
                                insertCmd.Parameters.Add("@nn", NpgsqlTypes.NpgsqlDbType.Text).Value = nickname;
                                insertCmd.Parameters.Add("@desc", NpgsqlTypes.NpgsqlDbType.Text).Value = profileText;
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка подключения: {ex.Message}");
                }
            }
        }
        public string ReadProfileText(string nickname)
        {
            string description = "";

            using (NpgsqlConnection connection = new NpgsqlConnection(config.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand($"SELECT description FROM user_profile WHERE nickname = @nn;", connection))
                    {
                        cmd.Parameters.Add("@nn", NpgsqlTypes.NpgsqlDbType.Text).Value = nickname;
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                                description = reader.GetString(0);
                            else
                                description = "О себе";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка подключения: {ex.Message}");
                }
            }
            return description;
        }
    }
}
