using System.Net.Mail;

namespace App.Service.Dtos.SubscribeDtos;

public record SubscribeDto(int Id, MailAddress Mail);