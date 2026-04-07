namespace TalentInsights.Shared.Constants
{
    public static class ResponseConstants
    {
        public const string COLLABORATOR_NOT_EXISTS = "El colaborador no existe";

        //Projects
        public const string PROJECT_NOT_EXISTS = "El proyecto no existe";

        public static string ERROR_UNEXPECTED(string traceid)
        {
            return $"Ha ocurrido un error inesperado: Contacte con soporte, mencionando el siguiente codigo de error: {traceid}";
        }
    }
}
