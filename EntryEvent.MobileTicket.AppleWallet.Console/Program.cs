// See https://aka.ms/new-console-template for more information

using EntryEvent.MobileTicket.AppleWallet.Console;

// Return API GET-call and send mail with ticket attachment
var pass = RequestHandler.GetPass();
EmailHandler.Send(pass);
System.Console.WriteLine("Email was sent!");
