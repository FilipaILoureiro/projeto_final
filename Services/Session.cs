namespace projetoPadariaApp.Services
{
    public static class Session
    {
        public static int? FuncionarioId { get; set; }
        public static string FuncionarioNome { get; set; }
        public static string Username { get; set; } 
        public static bool IsAdmin { get; set; }     
        public static string Funcao { get; set; }    

        public static void InitializeSession(UserInfo userInfo)
        {
            FuncionarioId = userInfo.Id;
            FuncionarioNome = userInfo.Nome;
            Username = userInfo.Username;
            IsAdmin = userInfo.IsAdmin;
            Funcao = userInfo.Funcao;
        }

        public static void ClearSession()
        {
            FuncionarioId = null;
            FuncionarioNome = string.Empty;
            Username = string.Empty;     
            IsAdmin = false;             
            Funcao = string.Empty;       
        }

        public static bool IsLoggedIn => FuncionarioId.HasValue;
    }
}
