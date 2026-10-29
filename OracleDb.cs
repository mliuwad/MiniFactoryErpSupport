using Oracle.ManagedDataAccess.Client;
using System;

namespace FactoryErpSupport
{
    public static class OracleDb
    {
        private const string ConnectionVariableName =
            "FACTORY_ERP_ORACLE_CONNECTION";

        private static string GetConnectionString()
        {
            // Đọc biến môi trường của tài khoản Windows
            string connectionString =
                Environment.GetEnvironmentVariable(
                    ConnectionVariableName,
                    EnvironmentVariableTarget.User);

            // Nếu không có, thử đọc biến của tiến trình hiện tại
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString =
                    Environment.GetEnvironmentVariable(
                        ConnectionVariableName,
                        EnvironmentVariableTarget.Process);
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Chưa cấu hình biến môi trường " +
                    ConnectionVariableName);
            }

            return connectionString;
        }

        public static OracleConnection GetConnection()
        {
            return new OracleConnection(GetConnectionString());
        }

        public static bool TestConnection(out string message)
        {
            try
            {
                using (OracleConnection connection = GetConnection())
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand(
                        "SELECT USER FROM DUAL", connection))
                    {
                        string username =
                            Convert.ToString(command.ExecuteScalar())
                            ?? "Không xác định";

                        message =
                            "Kết nối Oracle thành công!\n" +
                            "Tài khoản: " + username;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                message =
                    "Kết nối Oracle thất bại!\n" + ex.Message;

                return false;
            }
        }
    }
}