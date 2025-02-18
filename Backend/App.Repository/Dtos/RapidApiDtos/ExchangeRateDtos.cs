using System.Text.Json.Serialization;

namespace App.Repository.Dtos.RapidApiDtos;

public record ExchangeRootObject(
    bool status,
    string message,
    long timestamp,
    ExchangeDatas data
);

public record ExchangeDatas(
    List<Exchange_Rates> exchange_rates,
    string base_currency,
    string base_currency_date
);

public record Exchange_Rates(
    string exchange_rate_buy,
    string currency
);

public record CurrencyData(string Currency, string ExhancgeRateBuy);




    
    