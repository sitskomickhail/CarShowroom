using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Sales;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Sales
{
    public class GetSaleListHandlerService : IHandlerService<GetSalesListModel, List<SaleAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<SaleAnswerModel>> ExecuteAsync(GetSalesListModel model)
        {
            var query = SqlContext.Sales
                                        .Include(s => s.Client).Include(s => s.Client.User)
                                        .Include(s => s.Client.Sales).Include(s => s.Client.Maintenances)
                                        .Include(s => s.Vehicle);

            query = model.AcceptedSale ? query.Where(s => s.Status != SaleStatus.Waiting) : query.Where(s => s.Status == SaleStatus.Waiting);

            var sales = await query.ToListAsync();
            sales = sales.Select(s => s).Where(s => s.Client.User.Name.Contains(model.SearchParameter) ||
                                                    s.Vehicle.Mark.Contains(model.SearchParameter) ||
                                                    s.TotalCost.ToString().Contains(model.SearchParameter)).ToList();

            var salesAnswer = Mapper.Map<List<SaleAnswerModel>>(sales);
            return salesAnswer;
        }
    }
}