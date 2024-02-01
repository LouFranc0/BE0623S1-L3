namespace eserS1L3A
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string heading = @"  __        ______    __    __  .______        ___      .__   __.  __  ___ 
|  |      /  __  \  |  |  |  | |   _  \      /   \     |  \ |  | |  |/  / 
|  |     |  |  |  | |  |  |  | |  |_)  |    /  ^  \    |   \|  | |  '  /  
|  |     |  |  |  | |  |  |  | |   _  <    /  /_\  \   |  . `  | |    <   
|  `----.|  `--'  | |  `--'  | |  |_)  |  /  _____  \  |  |\   | |  .  \  
|_______| \______/   \______/  |______/  /__/     \__\ |__| \__| |__|\__\ 
                                                                          ";

            Console.WriteLine(heading);
            Console.WriteLine();
            Console.Write("Salve, vuole aprire un conto alla \"LouBank\"? Prema y per accettare o qualunque altra cosa per uscire: ");
            char answer = char.Parse(Console.ReadLine().ToLower());
            if (answer == 'y')
            {
                Console.WriteLine();
                Console.WriteLine("Benvenuto nella mia banca!");
                Console.WriteLine();
                Console.WriteLine("Se si vuole aprire il conto deve versare un minimo di 1000 euro.");
                Console.Write("Di quanto vuole fare il versamento iniziale? ");
                bool is1000Deposit = false;
                int versamentoIniziale;
                do
                {
                    versamentoIniziale = int.Parse(Console.ReadLine());
                    if (versamentoIniziale < 1000)
                    {
                        Console.Clear();
                        Console.WriteLine($"L'importo minimo deve essere 1000 euro, lei attualmente ha immesso {versamentoIniziale} euro.");
                        Console.Write("Prego, inserisca nuovamente il deposito iniziale: ");
                    }
                    else
                    {
                        is1000Deposit = true;
                    }

                } while (!is1000Deposit);

                Console.Clear();
                ContoCorrente conto = new ContoCorrente(versamentoIniziale);
                Console.WriteLine(heading);
                Console.WriteLine("Congratulazioni, ora ha un conto presso la nostra \"LouBank\", le auguriamo buona permanenza.");
                Console.WriteLine();
                Console.WriteLine($"Al momento lei ha depositato {conto.Saldo}");

                char selectedOption;
                bool isValidOption = true;
                do
                {
                    Console.WriteLine("Benvenuto, utente. Quale operazione vuole fare?");
                    Console.WriteLine("[G]uarda saldo attuale");
                    Console.WriteLine("[P]releva denaro");
                    Console.WriteLine("[D]eposita denaro");
                    Console.WriteLine("[E]sci...");
                    Console.WriteLine();
                    Console.Write("Inserisca l'operazione da svolgere: ");
                    selectedOption = Console.ReadLine()[0];

                    int amount;
                    int totalMoney;
                    switch (selectedOption)
                    {
                        case 'g':
                        case 'G':
                            Console.WriteLine($"Al momento il tuo saldo è di ${conto.Saldo} euro");
                            break;

                        case 'd':
                        case 'D':
                            Console.Write("Quanto vuoi versare?: ");
                            amount = int.Parse(Console.ReadLine());
                            totalMoney = conto.Versamento(amount);
                            Console.WriteLine($"Al momento il tuo saldo è di ${totalMoney} euro");
                            break;

                        case 'p':
                        case 'P':
                            Console.Write("Quanto vuoi prelevare?: ");
                            amount = int.Parse(Console.ReadLine());
                            totalMoney = conto.Prelevamento(amount);
                            if (totalMoney < 0)
                            {
                                Console.WriteLine($"Al momento hai a disposizione {conto.Saldo} euro,\nNon puoi prelevare più soldi di quanti ce ne sono sul conto... Operazione annullata");
                                break;
                            }
                            Console.WriteLine($"Al momento il tuo saldo è di ${totalMoney} euro");
                            break;

                        case 'e':
                        case 'E':
                            isValidOption = false;
                            break;

                        default:
                            Console.WriteLine("Opzione non valida");
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Premi un tasto per proseguire...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine(heading);
                    Console.WriteLine();
                    Console.WriteLine();
                } while (isValidOption);

                Console.Clear();
                Console.WriteLine(heading);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Grazie per aver scelto la nostra banca, arrivederci!");

                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(heading);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Grazie per aver scelto la nostra banca, arrivederci!");

                Console.ReadKey();
            }


        }
    }

    class ContoCorrente
    {
        int _saldo;

        public int Saldo
        {
            get { return _saldo; }
        }

        public ContoCorrente(int saldo)
        {
            _saldo = saldo;
        }

        public int Versamento(int soldiDaAggiungere)
        {
            _saldo += soldiDaAggiungere;
            return Saldo;
        }

        public int Prelevamento(int soldiDaTogliere)
        {
            if (Saldo <= 0 || Saldo < soldiDaTogliere)
            {
                return -1;
            }
            _saldo -= soldiDaTogliere;
            return Saldo;
        }
    }
}
