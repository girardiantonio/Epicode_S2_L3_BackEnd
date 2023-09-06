using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrrente
{

    internal class ContoCorrente
    {

        #region Paramethers

        private string Nome { get; set; }
        private string Cognome { get; set; }
        private DateTime Apertura { get; set; }
        private string NConto { get; set; }
        private double Saldo { get; set; }
        private List<Movimentazione> Movimentazioni { get; set; } = new List<Movimentazione>();

        public static List<ContoCorrente> ContiCorrente { get; set; } = new List<ContoCorrente>();
        public static bool Acceso { get; set; } = true;

        #endregion

        #region Constructors

        public ContoCorrente(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
            NConto = GeneraNumeroConto(12);
            Apertura = DateTime.Now;
            Saldo = 0;
        }

        #endregion

        #region Methods

        public void Accredito(double importo)
        {
            Saldo += importo;
            Movimentazioni.Add(new Movimentazione(true, importo));
        }

        public void Addebito(double importo)
        {
            Saldo -= importo;
            Movimentazioni.Add(new Movimentazione(false, importo));
        }

        #endregion

        #region Static methods

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine(" GESTISCI I CONTI");
            Console.WriteLine("=============================================");
            Console.WriteLine("1: Creare un nuovo conto");
            Console.WriteLine("2: Effettuare una movimentazione");
            Console.WriteLine("3: Lista delle movimentazioni per un conto");
            Console.WriteLine("4: Mostrare il saldo di tutti i conti");
            Console.WriteLine("5: Esci");
            Console.WriteLine("=============================================");
            Console.Write("Scelta: ");

            int scelta;
            try { scelta = Convert.ToInt32(Console.ReadLine()); }
            catch { scelta = 0; }

            switch (scelta)
            {
                case 1:
                    CreaConto();
                    break;
                case 2:
                    EffettuaMoviementazione();
                    break;
                case 3:
                    OttieniMoviementazioni();
                    break;
                case 4:
                    OttieniSaldi();
                    break;
                case 5:
                    Chiudi();
                    break;
                default:
                    Console.WriteLine("INserire un valore valido");
                    break;
            }

            Console.ReadLine();
        }

        private static string OttieniNumeroConto()
        {
            Console.Clear();
            Console.Write("Inserire numero di conto: ");
            return Console.ReadLine();
        }

        private static void CreaConto()
        {
            Console.Clear();
            //Nome
            Console.Write("Inserisci il nome: ");
            string nome = Console.ReadLine();
            //Cognome
            Console.Write("\nInserisci il cognome: ");
            string cognome = Console.ReadLine();

            ContiCorrente.Add(new ContoCorrente(nome, cognome));
        }

        private static void EffettuaMoviementazione()
        {
            ContoCorrente conto = TrovaConto(OttieniNumeroConto());
            if (conto.Cognome.Contains("Non trov"))
                Console.WriteLine("Conto non trovato");
            else
            {
                Console.Clear();
                Console.WriteLine(" MOVIMENTAZIONE");
                Console.WriteLine("=============================================");
                Console.WriteLine("1: Accredito");
                Console.WriteLine("2: Addebito");
                Console.WriteLine("=============================================");
                Console.Write("Scelta: ");
                int scelta;
                try { scelta = Convert.ToInt32(Console.ReadLine()); }
                catch { scelta = 0; }

                int importo;
                Console.Write("Inserire l'importo: ");
                try { importo = Convert.ToInt32(Console.ReadLine()); }
                catch { importo = 0; }

                switch (scelta)
                {
                    case 1:
                        conto.Accredito(importo);
                        break;
                    case 2:
                        conto.Addebito(importo);
                        break;
                    default:
                        Console.WriteLine("Inserire un valore valido");
                        break;
                }
            }



        }

        private static ContoCorrente TrovaConto(string nConto)
        {
            for (int i = 0; i < ContiCorrente.Count; i++)
            {
                if (ContiCorrente[i].NConto == nConto)
                    return ContiCorrente[i];
            }
            return new ContoCorrente("Utente", "Non trovato");
        }

        private static void OttieniMoviementazioni()
        {
            ContoCorrente conto = TrovaConto(OttieniNumeroConto());
            if (conto.Cognome.Contains("Non trov"))
                Console.WriteLine("Conto non trovato");

            Console.Clear();


            for (int i = 0; i < conto.Movimentazioni.Count; i++)
            {
                Console.Write($"Tipologia: ");
                if (conto.Movimentazioni[i].Accredito)
                    Console.WriteLine("Accredito");
                else
                    Console.WriteLine("Addebito");
                Console.WriteLine($"Importo: {conto.Movimentazioni[i].Importo}");
                Console.WriteLine($"Data: {conto.Movimentazioni[i].Data}\n");
            }
        }

        private static void OttieniSaldi()
        {
            for (int i = 0; i < ContiCorrente.Count; i++)
            {
                Console.WriteLine($"{ContiCorrente[i].Nome} {ContiCorrente[i].Cognome} - {ContiCorrente[i].NConto}");
                Console.WriteLine($"Saldo: {ContiCorrente[i].Saldo} \n");
            }
        }

        private static void Chiudi()
        {
            Acceso = false;
        }


        #region Random

        private static Random random = new Random();
        const string chars = "1234567890";

        private static string GeneraNumeroConto(int length)
        {
            //Un enumerable è una collection che implementa la classe IEnumerable
            //.reapeat genera una sequenza con un valore ripetuto
            //
            string nConto = "IT12A-" + new string
                            (
                                Enumerable.Repeat(chars, length) //Enumerable contenente X volte i nostri char
                                    .Select(s => s[random.Next(s.Length)])
                                        .ToArray()
                            );
            if (CheckNumeroConto(nConto))
                return nConto;

            return GeneraNumeroConto(length);
        }

        private static bool CheckNumeroConto(string nConto)
        {
            for (int i = 0; i < ContiCorrente.Count; i++)
                if (ContiCorrente[i].NConto == nConto)
                    return false;
            return true;
        }

        #endregion

        #endregion
    }

    class Movimentazione
    {
        #region Paramethers

        public bool Accredito { get; set; }
        public double Importo { get; set; }
        public DateTime Data { get; set; }

        #endregion

        #region Constructors

        public Movimentazione(bool accredito, double importo)
        {
            Accredito = accredito;
            Importo = importo;
            Data = DateTime.Now;
        }

        #endregion
    }
}
