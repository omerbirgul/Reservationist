using System.Net.Mail;

namespace App.Repository.Dtos.SubscribeDtos;

public record SubscribeDto(int Id, MailAddress Mail);