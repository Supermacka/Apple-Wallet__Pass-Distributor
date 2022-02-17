using System.Security.Cryptography.X509Certificates;
using Passbook.Generator;
using Passbook.Generator.Fields;

namespace EntryEvent.MobileTicket.AppleWallet.Library;

public static class BoardingPass
{
    public static byte[] Create()
    {
        PassGenerator generator = new PassGenerator();
    
        PassGeneratorRequest request = new PassGeneratorRequest();
        request.PassTypeIdentifier = "pass.tomsamcguinness.events";   
        request.TeamIdentifier = "RW121242";
        request.SerialNumber = "121212";
        request.Description = "My first pass";
        request.OrganizationName = "Tomas McGuinness";
        request.LogoText = "My Pass";
        
        request.BackgroundColor = "rgb(255,255,255)";
        request.LabelColor = "rgb(0,0,0)";
        request.ForegroundColor = "rgb(0,0,0)";
        
        // Certification
        request.AppleWWDRCACertificate = new X509Certificate2(@"/Users/colinfarkas/Desktop/AppleWWDRCA.cer");
        request.PassbookCertificate = new X509Certificate2(@"/Users/colinfarkas/Desktop/Certificate.p12", "Pannkakor12Cert");
        
        // Logo (TODO: Icon not working?)
        request.Images.Add(PassbookImage.Icon, File.ReadAllBytes(@"/Users/colinfarkas/Desktop/icon.png"));
        request.Images.Add(PassbookImage.Icon2X, File.ReadAllBytes(@"/Users/colinfarkas/Desktop/icon@2x.png"));
        
        request.Style = PassStyle.BoardingPass;

        request.AddPrimaryField(new StandardField("origin", "San Francisco", "SFO"));
        request.AddPrimaryField(new StandardField("destination", "London", "LDN"));

        request.AddSecondaryField(new StandardField("boarding-gate", "Gate", "A55"));

        request.AddAuxiliaryField(new StandardField("seat", "Seat", "G5" ));
        request.AddAuxiliaryField(new StandardField("passenger-name", "Passenger", "Thomas Anderson"));

        request.TransitType = TransitType.PKTransitTypeAir;
        
        
        request.AddBarcode(BarcodeType.PKBarcodeFormatQR, "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "ISO-8859-1", "46R1C3K52 96R0L1L57");

        byte[] generatedPass = generator.Generate(request);
        return generatedPass;
    }
}