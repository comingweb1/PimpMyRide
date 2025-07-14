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

public class ClientDataModel
{
    public string Id { get; private set; }
    public string FullName { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string CardNumber { get; private set; }
    public decimal TotalSpent { get; private set; }
    public decimal DiscountRate { get; private set; }

    // Конструктор для обязательных полей
    public ClientDataModel(string id, string fullName, string phone)
    {
        Id = id;
        FullName = fullName;
        Phone = phone;

        // Опциональные поля можно инициализировать дефолтными значениями
        Email = string.Empty;
        CardNumber = string.Empty;
        TotalSpent = 0;
        DiscountRate = 0;
    }

    // Метод для изменения данных
    public void UpdateInfo(string fullName, string phone, string email)
    {
        FullName = fullName;
        Phone = phone;
        Email = email;
    }

    public void Validate()
    {
        if (string.IsNullOrEmpty(Id))
        {
            throw new ValidationException("Field Id is empty");
        }
        if (!Guid.TryParse(Id, out _))
        {
            throw new ValidationException("The value in the field Id is not a unique identifier");
        }
        if (!Regex.IsMatch(Phone, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d- ]{7,10}$"))
        {
            throw new ValidationException("Field Phone is empty");
        }
    }
}
