using System.Text;

// Encode("aaa");

// SHA256Assigner.AssignString("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

// string teste = SHA256Assigner.AssignFile(@"C:\Users\felip\OneDrive\Imagens\Capturas de tela\testeCamposDealer2Copia.png");
// System.Console.WriteLine(teste);

bool auth = SHA256Assigner.Authenticator(@"C:\Users\felip\OneDrive\Imagens\Capturas de tela\testeCamposDealer2.png", "5dedeaf49ce55bed024e08e680b6c41941b3f3464a8eb73b3d3e4b723124aa70");
System.Console.WriteLine(auth);
