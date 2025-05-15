namespace projetoPadariaApp.Services
{
    public static class Session
    {
        public static int? FuncionarioId { get; set; }  // Alterado para nullable int
        public static string FuncionarioNome { get; set; }

        public static void ClearSession()
        {
            FuncionarioId = null;  // Mudança para null ao invés de 0
            FuncionarioNome = string.Empty;
        }
    }
}
