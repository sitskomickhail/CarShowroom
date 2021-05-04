using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
    public class AcceptSaleHandlerService : IHandlerService<AcceptSaleModel, SaleAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<SaleAnswerModel> ExecuteAsync(AcceptSaleModel model)
        {
            var sale = await SqlContext.Sales
                                        .Include(c => c.Client).Include(s => s.Client.User)
                                        .Include(c => c.Client.Maintenances).Include(s => s.Client.Sales)
                                        .Include(s => s.Vehicle)
                                        .FirstOrDefaultAsync(s => s.Id == model.Id);

            sale.Status = model.IsAccepted ? SaleStatus.Accepted : SaleStatus.Declined;
            await SqlContext.SaveChangesAsync();

            var saleAnswer = Mapper.Map<SaleAnswerModel>(sale);
            return saleAnswer;
        }
    }
}