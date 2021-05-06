namespace CarShowroom.Entities.Models.Enums
{
    public enum RequestAction
    {
        Login = 1,
        Register = 2,

        CreateVehicle = 3,
        GetVehicles = 4,
        SearchVehicles = 5,
        EditVehicle = 6,
        DeleteVehicle = 7,
        GetSailingVehicles = 23,
        GetClientVehicles = 26,

        CreateUser = 8,
        GetUsers = 9,
        DeleteUser = 10,
        EditUser = 11,

        GetClients = 12,
        DeleteClient = 13,
        EditClient = 14,
        GetClientDeals = 15,
        GetClientByUserId = 21,

        GetSales = 16,
        AcceptSale = 17,
        CreateSale = 22,

        GetMaintenances = 18,
        EditMaintenace = 20,
        GetMaintenanceStatistic = 24,
        GetClientMaintenances = 25
    }
}