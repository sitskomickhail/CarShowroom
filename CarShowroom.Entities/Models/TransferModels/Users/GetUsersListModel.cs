using System;

namespace CarShowroom.Entities.Models.TransferModels.Users
{
    public class GetUsersListModel
    {
        public string SearchParameter { get; set; } = String.Empty;

        public bool UserBlocked { get; set; } = false;
    }
}