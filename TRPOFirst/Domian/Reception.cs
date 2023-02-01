namespace TRPOFirst.Domian;

/// <summary>
/// Сущность представляющая приём у врача
/// </summary>
public class Reseption
{
    // <summary>
    /// Идентификатор
    /// </summary>
    public int IdReception { get; set; }

    /// <summary>
    /// Ссылка на первичный осмотр врача
    /// </summary>
    public DoctorsAppointments? IdAppointments { get; set; }
    
    /// <summary>
    /// Жалобы пациента
    /// </summary>
    public string? Complaints { get; set; }
    
    /// <summary>
    /// Диагноз для пациента
    /// </summary>
    public Diseases? IdDisease { get; set; }
    
    /// <summary>
    /// Дата приёма у вврача
    /// </summary>
    public DateTime DateReception { get; set; }
}