using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngoBank
{
    public class AdminDashboard
    {

        // Variables
        static string name, iban, username, passwd, ibanService;
        static double phone, balance, valueToUse, ibanDestin;

        static List<string> activitiesTypeList = new List<string>();
        static List<string> activitiesDateList = new List<string>();

        static string date = DateTime.Now.ToLongDateString();


        // Construtor
        public AdminDashboard(string n, string ib, double ph, string us, string pa)
        {
            name = n;
            username = us;
            passwd = pa;
            phone = ph;
            iban = ib;
        }

        // Insert the title on the console with lines up
        static void drawTitle(string text)
        {
            Program.lines();
            Console.WriteLine("###");
            Console.WriteLine("###");
            Console.WriteLine("### ANGOBANK EXPRESS - " + text);
            Console.WriteLine("### ");
        }

        // Back to Main
        static void goToMENU()
        {
            Console.WriteLine("### ");
            Console.WriteLine("### Pressione qualquer tecla para voltar...");
            Console.ReadLine();
            Console.Clear();
            openDashboardAdmin();
        }

        // Consult the balance
        static void consultBalance()
        {
            drawTitle(name.ToUpper());
            Console.WriteLine("### SALDO: " + balance + "Kz");
            Console.WriteLine("###");
            goToMENU();
        }

        // Consult information about account
        public static void consultInfoAccount()
        {
            drawTitle(name.ToUpper());
            Console.WriteLine("### Nome completo: " + name.ToUpper());
            Console.WriteLine("### ");
            Console.WriteLine("### IBAN: " + iban);
            Console.WriteLine("### ");
            Console.WriteLine("### Nº Celular: " + phone);
            Console.WriteLine("### ");
            Console.WriteLine("### Usuário: " + username);
            Console.WriteLine("### ");
            Console.WriteLine("### Palavra-passe: " + passwd);
            Console.WriteLine("###");
            goToMENU();
        }

        // Payment an service
        private static void payment(string service)
        {

            switch (service)
            {
                case "1XBET":
                    ibanService = "AO060022141411171698401";
                    break;

                case "UNITEL":
                    ibanService = "AO060033121814181688201";
                    break;

                case "MOVICEL":
                    ibanService = "AO060033151334151898201";
                    break;

                case "AFRICEL":
                    ibanService = "AO060044157334151798201";
                    break;

                case "CDU - Donation":
                    ibanService = "AO060099121314124698201";
                    break;

            }

            drawTitle("PAGAMENTO PARA " + service);
            Console.Write("### Valor a pagar: ");
            valueToUse = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("### ");
            Program.lines();
            Console.WriteLine("### ");
            if (balance < valueToUse)
            {
                Console.WriteLine("### Oops! Saldo insuficiente! Pagamento cancelado!");
            }
            else
            {
                balance -= valueToUse;
                Console.WriteLine("### PAGAMENTO FEITO COM SUCESSO!");
                Console.WriteLine("### ");
                Console.WriteLine("### VALOR PAGO: " + valueToUse + "Kz");
                Console.WriteLine("### ");
                Console.WriteLine("### SERVIÇO: " + service);
                Console.WriteLine("### ");
                Console.WriteLine("### IBAN DO SERVIÇO: " + ibanService);
                setActivities("Pagmento á serviço");

            }
            goToMENU();
        }

        // Do payment in the services
        static void doPayment()
        {
            int op;

            drawTitle("PAGAMENTOS");
            Console.WriteLine("### [1] 1XBET");
            Console.WriteLine("### [2] UNITEL");
            Console.WriteLine("### [3] MOVICEL");
            Console.WriteLine("### [4] AFRICEL");
            Console.WriteLine("### [5] CDU - Donation");
            Console.WriteLine("### [6] Sair");
            Console.WriteLine("### ");
            Console.Write("### [*] >> ");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    payment("1XBET");
                    break;
                case 2:
                    payment("UNITEL");
                    break;

                case 3:
                    payment("MOVICEL");
                    break;

                case 4:
                    payment("AFRICEL");
                    break;

                case 5:
                    payment("CDU - Donation");
                    break;

                case 6:
                    openDashboardAdmin();
                    break;
            }
        }

        // Transfer money with IBAN
        static void transference()
        {

            drawTitle("TRAMSFERÊNCIA");
            Console.Write("### IBAN (AO06): ");
            ibanDestin = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("### ");
            Console.Write("### Valor a transferir: ");
            valueToUse = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("### ");
            Program.lines();
            Console.WriteLine("### ");
            if (balance > valueToUse)
            {
                balance -= valueToUse;

                Console.WriteLine("### TRANSFERËNCIA FEITA COM SUCESSO!");
                Console.WriteLine("### ");
                Console.WriteLine("### TRANSFERIDO PARA: " + "AO06" + ibanDestin);
                Console.WriteLine("### ");
                Console.WriteLine("### VALOR TRANSFERIDO: " + valueToUse + "Kz");
                Console.WriteLine("### ");
                Console.WriteLine("### SALDO ATUAL: " + balance + "Kz");
                setActivities("Transferência");
            }
            else
            {
                
                Console.WriteLine("### ");
                Console.WriteLine("### Oops! O saldo não é suficiente! Transferência cancelada!");
            }

            goToMENU();
        }

        // Income the money in the account
        static void income()
        {

            drawTitle("DEPÓSITO");
            Console.Write("### Valor a depositar: ");
            valueToUse = Convert.ToDouble(Console.ReadLine());

            balance += valueToUse;

            Console.WriteLine("### ");
            Program.lines();
            Console.WriteLine("### ");
            Console.WriteLine("### VALOR DEPOSITADO COM SUCESSO!");
            Console.WriteLine("### ");
            Console.WriteLine("### VALOR DEPOSITADO: " + valueToUse + "Kz");
            Console.WriteLine("### ");
            Console.WriteLine("### SALDO ATUAL: " + balance + "Kz");
            setActivities("Depósito");
            goToMENU();
        }

        // set a new Activity on account
        static void setActivities(string type)
        {
            activitiesTypeList.Add(type);
            activitiesDateList.Add(date);
        }
        // Visualize the activities done on the account
        static void seeActivities()
        {
            drawTitle("REGISTRO DE ATIVIDADES");

            if (activitiesTypeList.Count < 0)
            {
                Console.WriteLine("### SEM NENHUMA ATIVIDADE");
            }
            else
            { 
                foreach (var activity in activitiesTypeList)
                {
                    foreach(var act in activitiesDateList)
                    {
                        Console.WriteLine("### TIPO: " + activity);
                        Console.WriteLine("### DATA: " + act);
                        Console.WriteLine("### ---------------------------------");
                        goToMENU();
                    }
                 }
            }
        }
        // Open Dashboard when the user is logged
        public static void openDashboardAdmin()
        {
            int op = 0;

            do
            {

                Program.lines();
                Console.WriteLine("###  ");
                Console.WriteLine("###  ");
                Console.WriteLine("### BEM-VINDO AO ANGOBANK EXPRESS - SENHOR(A) " + name.ToUpper());
                Console.WriteLine("###  ");
                Console.WriteLine("### [1] Consultar saldo");
                Console.WriteLine("### [2] Depositar");
                Console.WriteLine("### [3] Pagamento");
                Console.WriteLine("### [4] Transferência");
                Console.WriteLine("### [5] Consultar meus dados");
                Console.WriteLine("### [6] Atividades");
                Console.WriteLine("### [7] Sair");
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
                            consultBalance();
                            break;

                        case 2:
                            income();
                            break;

                        case 3:
                            doPayment();
                            break;
                        case 4:
                            transference();
                            break;

                        case 5:
                            consultInfoAccount();
                            break;

                        case 6:
                            seeActivities();
                            break;
                        case 7:
                            Program.goToMenu();
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

            } while (op > 6 || op <= 1);

        }

    }
}
