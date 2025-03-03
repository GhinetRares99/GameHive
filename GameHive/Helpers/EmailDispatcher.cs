// <copyright file="EmailDispatcher.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Helpers;

using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using GameHive.Models;
using Newtonsoft.Json;

/// <summary>
/// A class used to send emails.
/// </summary>
public static class EmailDispatcher
{
    /// <summary>
    /// A function used to send emails.
    /// </summary>
    /// <param name="recipientEmail">The recipient's email address.</param>
    /// <param name="parameters">The parameters of the email.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="emailTemplate">The email template.</param>
    public static async void Send(string recipientEmail, string parameters, IConfiguration configuration, EmailTemplate emailTemplate)
    {
        var gmailSmtp = configuration.GetSection(ConstantValues.EmailSection).GetValue<string>("GmailSmtp");
        var portSmtp = configuration.GetSection(ConstantValues.EmailSection).GetValue<int>("PortSmtp");
        var sslSmtp = configuration.GetSection(ConstantValues.EmailSection).GetValue<bool>("SslSmtp");
        var passwordSmtp = configuration.GetSection(ConstantValues.EmailSection).GetValue<string>("PasswordSmtp");
        var gameHiveEmailAddress = configuration.GetSection(ConstantValues.EmailSection).GetValue<string>("GameHiveEmailAddress");

        var templateParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameters);

        var mailMessage = new MailMessage
        {
            From = new MailAddress(gameHiveEmailAddress ?? string.Empty),
            Subject = emailTemplate.Subject,
            Body = ReplaceParameters(emailTemplate.Text, templateParameters),
            IsBodyHtml = emailTemplate.IsHtmlEmail,
        };

        mailMessage.To.Add(recipientEmail);

        var smtpClient = new SmtpClient(gmailSmtp, portSmtp);
        smtpClient.Credentials = new NetworkCredential(gameHiveEmailAddress, passwordSmtp);
        smtpClient.EnableSsl = sslSmtp;

        await smtpClient.SendMailAsync(mailMessage);
    }

    private static string ReplaceParameters(string text, Dictionary<string, string> templateParameters)
    {
        foreach (var param in templateParameters)
        {
            text = Regex.Replace(text, $"\\{{{param.Key}\\}}", param.Value);
        }

        return text;
    }
}