using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AngoBank
{
    public static class UserFile
    {
        static string pathDir = Directory.GetCurrentDirectory() + "\\users";
        static string pathDirClient = Directory.GetCurrentDirectory() + "\\clients";
        static string pathFile = pathDir + "\\users.txt";
        static string pathFileClient = pathDirClient + "\\clients.txt";

        static char[] ch = new char[200];

        public static void loginUserWithFile(string user, string passwd)
        {
            try
            {
                StreamReader sr = new StreamReader(pathFile);
                string rowFile = sr.ReadToEnd();

                Console.WriteLine(rowFile);
                Console.WriteLine(rowFile.StartsWith("ricardo.admin"));
       
                sr.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("#### Erro ao iniciar uma nova sessão!");
            }
        }
        public static void addUser(string user, string passwd)
        {
            try
            {
                StreamWriter sw = new StreamWriter(pathFile);
                sw.WriteLine("**************************************");
                sw.WriteLine(user);
                sw.WriteLine(passwd);
                sw.WriteLine("**************************************");
                sw.Close();
            }
            catch
            {
                Console.WriteLine("#### Erro ao criar novo usuário!");
            }
        }

        public static void addClient(string n, string ib, double ph, string us, string pa)
        {
            try
            {
                StreamWriter sw = new StreamWriter(pathFileClient);
                sw.WriteLine("**************************************");
                sw.WriteLine("- Nome completo: " + n);
                sw.WriteLine("- IBAN: " + ib);
                sw.WriteLine("- Celular: " + ph);
                sw.WriteLine("- Senha: " + pa);
                sw.WriteLine("- Usuário: " + us);         
                sw.WriteLine("**************************************");
                sw.Close();
            }
            catch
            {
                Console.WriteLine("#### Erro ao criar novo cliente!");
            }
        }

        static void createDirAndFile()
        {
            try
            {
                Directory.CreateDirectory(pathDir);
                Directory.CreateDirectory(pathDirClient);
                File.Create(pathFile);
                File.Create(pathFileClient);
            }
            catch
            {
                Console.WriteLine("#### Falha no carregamento dos arquivos!");
            }
        }
        static void generateUserFile()
        {     
            if(Directory.Exists(pathDir) && Directory.Exists(pathDirClient))
            {
                if (File.Exists(pathFile) && File.Exists(pathFileClient))
                {
                    Console.WriteLine("#### Arquivos carregados!");
                }
                else
                {
                    File.Create(pathFile);
                    File.Create(pathFileClient);
                    Console.WriteLine("#### Arquivos de configuração criados com sucesso!");
                }
            }
            else
            {
                createDirAndFile();
                Console.WriteLine("#### Arquivos de configuração criados com sucesso!");
            }
        }

        public static void loadSettings()
        {
            Stopwatch stw = new Stopwatch();
            stw.Start();
            generateUserFile();
            stw.Stop();
        }

    }
}
