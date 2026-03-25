namespace TableFlow.Data.Dtos;

public class CreateTableDto
{
    public string TableName { get; set; }
    public int RoomID { get; set; }
    public int OrganisationId { get; set; }
    public double PositionX { get; set; }
    public double PositionY { get; set; }
}