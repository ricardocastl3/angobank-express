
/*

DEVELOP: AUGUSTO RICARDO
DATE: 21/02/2022
DESCRIPTION: THIS IS A SIMPLE PROJECT SIMULATED WHEREVER BANK AGENCY

FACEBOOK: RICARDO CASTLE

TECHNOLOGIES:
- C#

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AngoBank
{
    class Program
    {

        // Variables
        static string name, username, passwd, passwdConfirm, iban;
        static double phone;
        static AdminDashboard admin;


        // Call the method or Admin Dashboard when the login is success very well
        static void AdminSucess()
        {
            Console.Clear();
            admin = new AdminDashboard(name, iban, phone, username, passwd);
            AdminDashboard.openDashboardAdmin();
        }

        // Back To Menu
        public static void goToMenu()
        {
            Console.Clear();
            options();
        }

  
        // Generate random iban
        static string genIban()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            Random r3 = new Random();
            Random r4 = new Random();
            int n1 = r1.Next(0, 9);
            int n2 = r2.Next(0, 9);
            int n3 = r3.Next(0, 9);
            int n4 = r4.Next(0, 9);

            string niban = "AO0600" + n2 + 7 + n1 + n2 +  "23476" + n3 + n4 + "9872548" + n2;

            return niban;
        }

        // Generate random username based on username
        static string userNameGen(string name)
        {
            Random rnd = new Random();
            int id = rnd.Next(100, 200);
            string user = name + "." + id;
            return user;
        }

        // Draw line on the console
        public static void lines()
        {
            int wiWidth = Console.WindowWidth;
            for (int i = 0; i < wiWidth; i++)
            {
                Console.Write("#");
            }
        }

        // Set settings to setup system
        static void setSettings()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetWindowSize(120, 30);
            Console.Title = "ANGOBANK - POR: AUGUSTO A. RICARDO";
        }

        // Login with user and passwd
        static void login()
        {
            int onces = 1;
            string u, p;

            lines();
            Console.WriteLine("### ");
            Console.WriteLine("### ");
            Console.WriteLine("### ANGOBANK EXPRESS - FAZER LOGIN");
            Console.WriteLine("### ");
            Console.Write("### Nome do usuário: ");
            u = Console.ReadLine();

            Console.WriteLine("### ");

            Console.Write("### Palavra-passe: ");
            p = Console.ReadLine();

           if(u != username && p != passwd)
            {
                while (u != username && p != passwd)
                {
                    Console.WriteLine("### Credenciais inválidas! ");
                    Console.WriteLine("### ");

                    Console.Write("### Nome do usuário: ");
                    u = Console.ReadLine();

                    Console.WriteLine("### ");

                    Console.Write("### Palavra-passe: ");
                    p = Console.ReadLine();
                    onces++;

                    if (u == username && p == passwd)
                    {
                        AdminSucess();
                    }

                    if (onces == 3)
                    {
                        goToMenu();
                    }

                }

            }
            else
            {
                AdminSucess();
            }
           


        }

        // Trying createAccount 
        static void tryCreateAccount()
        {
            try
            {
                username = userNameGen(username);
                iban = genIban();

                UserFile.addUser(username, passwd);
                UserFile.addClient(name, iban, phone, username, passwd);

                lines();
                Console.WriteLine("##### CONTA CRIADA COM SUCESSO!");
                Console.WriteLine("##### ");
                Console.WriteLine("##### DADOS DE ACESSO:");
                Console.WriteLine("##### ");
                Console.WriteLine("##### Nome do usuário: " + username);
                Console.WriteLine("##### ");
                Console.WriteLine("##### Palavra-passe: " + passwd);
                lines();
                Console.ReadLine();
                Console.Clear();
                AdminSucess();

            }
            catch (Exception ex)
            {
                lines();
                Console.WriteLine("##### Erro ao criar conta!" + ex.Message + ex.StackTrace);
                lines();
            }

        }

        // Create account
        static void createAccount()
        {


            lines();
            Console.WriteLine("### ");
            Console.WriteLine("### ");
            Console.WriteLine("### ANGOBANK EXPRESS - CRIAR NOVA CONTA");
            Console.WriteLine("### ");
            Console.Write("### Nome completo: ");
            name = Console.ReadLine();

            Console.WriteLine("### ");

            Console.Write("### IBAN (AO06): SERÁ GERADO AUTOMATICAMENTE!");
            Console.WriteLine("### ");
            Console.WriteLine("### ");

            Console.Write("### Nº Celular: ");
            phone = Convert.ToDouble(Console.ReadLine());

            // USER ADD
            Console.WriteLine("### ");
            Console.Write("### Nome do usuário: ");
            username = Console.ReadLine();

            Console.WriteLine("### ");

            Console.Write("### Palavra-passe: ");
            passwd = Console.ReadLine();

            Console.WriteLine("### ");

            Console.Write("### Confirmar palavra-passe: ");
            passwdConfirm = Console.ReadLine();

            Console.WriteLine("### ");

            if(passwdConfirm != passwd)
            {         
                while (passwd != passwdConfirm)
                {
                    Console.WriteLine("### As palavras-passes não coincidem...");
                    Console.Write("### Confirmar palavra-passe: ");
                    passwdConfirm = Console.ReadLine();

                    if(passwd == passwdConfirm)
                    {
                        tryCreateAccount();
                    }
                }

               
            }
            else
            {
                tryCreateAccount();

            }
          
        }
        // Options contains the main 
        static void options()
        {
            int op = 0;

            do
            {

                lines();
                Console.WriteLine("###  ");
                Console.WriteLine("###  ");
                Console.WriteLine("### BEM-VINDO AO ANGOBANK EXPRESS ");
                Console.WriteLine("###  ");
                Console.WriteLine("### [1] Criar nova conta");
                Console.WriteLine("### [2] Fazer Login");
                Console.WriteLine("### [3] Sair");
                Console.WriteLine("### ");
                Console.Write("### [*] >> ");
                try
                {
                    op = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.Beep();

                    switch (op)
                    {
                        case 1:
                            createAccount();
                            break;

                        case 2:
                            login();
                            break;

                        case 3:
                            lines();
                            Console.WriteLine("### Obrigado e volte sempre!");
                            break;
                    }
                }
                catch
                {
                    op = 10;
                    Console.WriteLine("A opção precisa ser numérica!");
                    Console.Clear();
                }
               
                op++;
                
            } while (op > 4 || op <= 1);

        }

    
        static void Main(string[] args)
        {

            setSettings(); // Load local settings 

            Console.WriteLine("###");
            Console.WriteLine("###");

            UserFile.loadSettings(); // LoadFile for user registered.

            options();
            Console.ReadKey();
        }


    }
}
