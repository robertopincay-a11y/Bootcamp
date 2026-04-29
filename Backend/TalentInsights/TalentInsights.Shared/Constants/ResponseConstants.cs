namespace TalentInsights.Shared.Constants
{
    public static class ResponseConstants
    {
        //Collaborators
        public const string COLLABORATOR_NOT_EXISTS = "El colaborador no existe";

        //Role
        public static string RoleNotFound(string name) => $"El rol {name} no existe";
        public static string RoleNotFound(Guid id) => $"El rol con ID: {id} no existe";

        //Projects
        public const string PROJECT_NOT_EXISTS = "El proyecto no existe";

        //Auth
        public const string AUTH_TOKEN_NOT_FOUND = "El token no es correcto, expiró o no se argumentó";
        public const string AUTH_USER_OR_PASSWORD_NOT_FOUND = "Usuario o contraseña incorrectos";
        public const string AUTH_REFRESH_TOKEN_NOT_FOUND = "El token para refrescar la sesión expiró, no existe o es incorrecto";

        public static string ErrorUnexpected(string traceid)
        {
            return $"Ha ocurrido un error inesperado: Contacte con soporte, mencionando el siguiente codigo de error: {traceid}";
        }

        public static string ConfigurationPropertyNotFound(string property)
        {
            return $"Falta la propiedad: '{property}' por establecer en la configuracion del aplicativo";
        }


    }
}
