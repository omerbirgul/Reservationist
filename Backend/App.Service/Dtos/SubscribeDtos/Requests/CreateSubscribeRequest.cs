using System.Net.Mail;

namespace App.Service.Dtos.SubscribeDtos.Requests;

public record CreateSubscribeRequest(MailAddress Mail);