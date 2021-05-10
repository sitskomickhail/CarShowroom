namespace CarShowroom.Services.Interfaces
{
    public interface IPdfService
    {
        bool GeneratePDF(string filename, string imageLoc);
    }
}