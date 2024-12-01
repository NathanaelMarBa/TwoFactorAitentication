using System.Data;

namespace WebAPI_TwoFactor.Clases
{
    public class Usuarios
    {

        public Usuarios()
        {
            AccesoDatos.cadenaConexion = @"Data Source=NATHANAEL\MSSQLSERVER01;Initial Catalog=2FA;Integrated Security=SSPI;";
        }

        public void SetSecret(string email, string code)
        {
            AccesoDatos.ExecuteQuery($"UPDATE dbo.Usuarios SET TwoFactorSecret='{code}' WHERE email='{email}'");
        }

        public string GetSecret(string email)
        {
            DataTable dt = AccesoDatos.GetTmpDataTable($"SELECT TwoFactorSecret FROM dbo.Usuarios WHERE email='{email}'");
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["TwoFactorSecret"].ToString();
            }
            else
            {
                return "";
            }
        }

    }
}
