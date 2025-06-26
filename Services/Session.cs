namespace projetoPadariaApp.Services
{
    public static class Session
    {
        public static int? FuncionarioId { get; set; }
        public static string FuncionarioNome { get; set; }

        public static void ClearSession()
        {
            FuncionarioId = null;
            FuncionarioNome = string.Empty;
        }
    }
}
