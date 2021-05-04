namespace CarShowroom.Entities.Models.Enums
{
    public enum RequestAction
    {
        Login,
        Register,

        CreateVehicle,
        GetVehicles,
        SearchVehicles,
        EditVehicle,
        DeleteVehicle,

        CreateUser,
        GetUsers,
        DeleteUser,
        EditUser,

        GetClients,
        DeleteClient,
        EditClient,
        GetClientDeals,

        GetSales,
        AcceptSale,

        GetMaintenances,
        EditMaintenace
    }
}