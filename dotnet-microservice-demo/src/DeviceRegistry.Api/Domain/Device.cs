namespace DeviceRegistry.Api.Domain;

public class Device
{
    public int Id { get; set; }                 // Primärnyckel i databasen
    public string Name { get; set; } = "";      // Ex: "Sensor A"
    public string Type { get; set; } = "";      // Ex: "Temperature"
    public string SerialNumber { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
