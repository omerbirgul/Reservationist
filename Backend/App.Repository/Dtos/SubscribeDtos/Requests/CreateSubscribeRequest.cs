using System.Net.Mail;

namespace App.Repository.Dtos.SubscribeDtos.Requests;

public record CreateSubscribeRequest(MailAddress Mail);