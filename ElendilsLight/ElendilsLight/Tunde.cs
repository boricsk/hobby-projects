using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EledilsLight
{
    public class Tunde
    {
        /// <summary>
        /// Meghatározzuk azt, hogy melyik fogoly a főnök, ő csak fölkapcsolhat, le nem.
        /// </summary>
        private int BossIndex { get; } = 0;

        /// <summary>
        /// Beállítjuk a láma állapotát false-ra,minden fogoly esetén, mert aki már kapcsolt, az nem kapcsolhatja le.
        /// A szimulációban csak az kapcsolhat aki még nem tette meg. Ezzel biztosítjuk, hogy mindenki csak egyszer kapcsoljon.
        /// </summary>
        public bool[] isTurn { get; set; }

        /// <summary>
        /// A lámpa állapotának változását figyeljük, ha változik akkor növeljük a Count értékét.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// A foglyok számát tároljuk.
        /// </summary>
        public int NumberOfPrisoners { get; }

        /// <summary>
        /// A lámpa állapotát tároljuk. Ha az állapot változik akkor fut az OnLampStateChange esemény.
        /// </summary>
        public bool stateOfLamp { get; set; }

        /// <summary>
        /// A foglyok sétáinak számát tároljuk.
        /// </summary>        
        public int[] NumberOfWalks { get; set; }


        /// <summary>
        /// Konstruktor, amely beállítja a foglyok számát, a lámpa állapotát, a levegőzés számát.
        /// </summary>
        /// <param name="numOfPrisoners">Foglyok száma</param>
        public Tunde(int numOfPrisoners)
        {
            NumberOfPrisoners = numOfPrisoners;
            try
            {
                isTurn = new bool[NumberOfPrisoners];
                NumberOfWalks = new int[NumberOfPrisoners];
            }
            catch (Exception e)
            {
                Console.WriteLine($"A rabok száma pozitív egész legyen ! {e.Message}");
                Environment.Exit(1);
            }

            //Lámpa kezdeti értékének beállítása
            stateOfLamp = false;
            Count = 0;
        }

        /// <summary>
        /// A szimuláció futtatása.
        /// </summary>
        public void RunSimulation()
        {
            int iterationNumber = 0;
            Random rnd = new Random();

            while (Count < NumberOfPrisoners)
            {
                int selectedPrisoner = rnd.Next(0, NumberOfPrisoners);
                if (selectedPrisoner == BossIndex)
                {
                    //A főnök csak felkapcsolhatja a lámpát, lekapcsolnia nem szabad.
                    //Az állapotváltozások számát kell számolnia, ebben segít a Count változó.
                    if (!stateOfLamp)
                    {
                        stateOfLamp = true;
                        isTurn[BossIndex] = true;
                        Count++;
                    }
                }
                else
                {
                    //A többi fogoly csak akkor kapcsolhatja le a lámpát, ha még nem tette meg.
                    if (stateOfLamp && !isTurn[selectedPrisoner])
                    {
                        stateOfLamp = false;
                        isTurn[selectedPrisoner] = true;
                    }
                }
                NumberOfWalks[selectedPrisoner]++;
                iterationNumber++;
            }
            Console.WriteLine($"Iteration number : {iterationNumber}");
            Console.WriteLine();
            Console.WriteLine("Number of walks by prisoner");
            for (int i = 0; i < NumberOfWalks.Length; i++)
            {
                Console.WriteLine($"Prisoner : {i + 1,-3} - {NumberOfWalks[i]}");
            }
            Console.WriteLine();
            Console.WriteLine($"Average number of walks : {NumberOfWalks.Average()}");
        }
    }
}
/*
public bool stateOfLamp
{
    get { return _stateOfLamp; }
    set
    {
        if (_stateOfLamp != value)
        {
            _stateOfLamp = value;
            OnLampStateChange(_stateOfLamp);
        }
    }
}

private bool _stateOfLamp { get; set; }

public event EventHandler<bool> LampStateChanged;

protected virtual void OnLampStateChange(bool newValue)
{
    if (LampStateChanged != null)
    {
        LampStateChanged?.Invoke(this, newValue);
    }
}

Feliratkozás az eseményre a kondtruktorban:
LampStateChanged += (sender, newValue) => Count++; 

 */