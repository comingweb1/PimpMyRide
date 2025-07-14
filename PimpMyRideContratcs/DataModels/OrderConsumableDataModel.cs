using PimpMyRideContratcs.Exceptions;
using PimpMyRideContratcs.Extensions;
using PimpMyRideContratcs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace PimpMyRideContratcs.DataModels;

public class OrderConsumableDataModel
{
    public int Id { get; private set; }
    public int QuantityUsed { get; private set; }
    public int OrderId { get; private set; }
    public int ConsumableId { get; private set; }
    public ConsumableDataModel Consumable { get; private set; }

    public OrderConsumableDataModel(int id, int quantityUsed, int orderId, int consumableId)
    {
        Id = id;
        QuantityUsed = quantityUsed;
        OrderId = orderId;
        ConsumableId = consumableId;
    }

    public void Validate()
    {
        if (Id <= 0)
            throw new ValidationException("Invalid ID");

        if (QuantityUsed <= 0)
            throw new ValidationException("Quantity must be positive");

        if (OrderId <= 0)
            throw new ValidationException("Invalid order ID");

        if (ConsumableId <= 0)
            throw new ValidationException("Invalid consumable ID");
    }
}
