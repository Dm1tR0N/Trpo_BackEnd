namespace TRPOFirst.Contracts.Hospital;

public static class ApiRoutes
{
    public const string Root = "api";
    
    public const string Version = "v1";

    public const string Base = Root + "/" + Version;
    
    public static class Hospital
    {
        // Все связанное с Пациентами
        public const string GetAllPacients = Base + "/pacients";
        
        public const string UpdatePacients = Base + "/pacients/{IdPacient}";

        public const string GetPacients = Base + "/pacients/{IdPacient}";
        
        public const string CreatePacients = Base + "/pacients";
        
        // Все связанное с Докторами
        public const string GetAllDoctors = Base + "/doctors";
        
        public const string UpdateDoctor = Base + "/doctors/{idDoctor}";
        
        public const string GetDoctors = Base + "/doctors/{idDoctor}";
        
        public const string CreateDoctors = Base + "/doctors";

    }
}