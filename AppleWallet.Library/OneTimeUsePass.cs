using System.Security.Cryptography.X509Certificates;
using Passbook.Generator;
using Passbook.Generator.Fields;

namespace AppleWallet.Library;

public static class TosselillaPass
{
    private static string CurrentPathImages { get; set; } =
        @"/Users/colinfarkas/RiderProjects/EntryEvent.MobileTicket.AppleWallet/AppleWallet.Library/Images/Tosselilla/";
    public static byte[] Create(string serialNumber)
    {
        PassGenerator generator = new PassGenerator();
    
        PassGeneratorRequest request = new PassGeneratorRequest();
        
        // Toplevel Keys
        request.PassTypeIdentifier = TopLevelKeys.PassTypeIdentifier; 
        request.TeamIdentifier = TopLevelKeys.TeamIdentifier;
        
        // Updatable
        // TODO: Create individual authToken (per pass)
        request.AuthenticationToken = "vxwxd7J8AlNNFPS8k0a0FfUFtq0ewzFdc";
        request.WebServiceUrl = "https://localhost:7161/Passes/";

        request.SerialNumber = serialNumber;
        request.Description = "Entrébiljett till Astrid Lindgrens Värld";
        request.OrganizationName = "Astrid Lindgrens Värld";
        request.LogoText = ""; // TODO: Check space
        request.HeaderFields.Add(new StandardField("entry-date", "10:00-17:00", "04/08-22"));

        // Design
        request.BackgroundColor = "rgb(255,255,60)";
        request.LabelColor = "rgb(45,45,45)";
        request.ForegroundColor = "rgb(0,0,0)";

        // Certification
        request.AppleWWDRCACertificate = new X509Certificate2(@"/Users/colinfarkas/Desktop/AppleWWDRCA.cer");
        request.PassbookCertificate = new X509Certificate2(@"/Users/colinfarkas/Desktop/Certificate.p12", "Pannkakor12Cert");

        // Icon *REQUIRED (shows on notification)
        request.Images.Add(PassbookImage.Icon, File.ReadAllBytes(CurrentPathImages + @"icon.png"));
        request.Images.Add(PassbookImage.Icon2X, File.ReadAllBytes(CurrentPathImages + @"icon@2x.png"));
        
        // Logo (top left corner)
        request.Images.Add(PassbookImage.Logo, File.ReadAllBytes(CurrentPathImages + @"logo.png"));
        request.Images.Add(PassbookImage.Logo2X, File.ReadAllBytes(CurrentPathImages + @"logo@2x.png"));
        
        // Strip (banner)
        request.Images.Add(PassbookImage.Strip, File.ReadAllBytes(CurrentPathImages + @"strip.jpeg"));
        request.Images.Add(PassbookImage.Strip2X, File.ReadAllBytes(CurrentPathImages + @"strip@2x.jpeg"));
        
        request.Style = PassStyle.EventTicket;

        request.AddSecondaryField(new StandardField("pass-name", "", "Tosselilla Nöjespark"));
        
        request.AddAuxiliaryField(new StandardField("pass-type", "Biljett", "Dagsentré (1dag)"));
        request.AddAuxiliaryField(new StandardField("pass-owner-name", "Ägare", "Colin Farkas"));

        request.AddBarcode(BarcodeType.PKBarcodeFormatQR, "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "ISO-8859-1", "46R1C3K52 96R0L1L57");

        byte[] generatedPass = generator.Generate(request);
        return generatedPass;
    }
}