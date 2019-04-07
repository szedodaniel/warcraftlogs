using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcraftlogs
{
    class Program
    {
        static void Main(string[] args)
        {
            Players championOfLight = new Players("1_champion_of_light.csv");
            Players grong = new Players("2_grong.csv");

            
            Console.WriteLine("3.feladat: Sebzést kiosztó játékosok száma:");
            Console.WriteLine("Champion of Light: {0}fő\nGrong {1}fő\n",championOfLight.sebzestOsztottJatekosokSzama(),
             grong.sebzestOsztottJatekosokSzama());

            Console.WriteLine("4.feladat:  A teljes DPS Champion of Lighton: {0}\n", championOfLight.teljesKiosztottDps());
            Console.WriteLine("5. feladat: A legnagyobb ilvl-ű játékos Grongon: \n" +
                "A játékos neve: {0}\n" +
                "A jatekos ilvl-e: {1}\n" +
                "A játékos teljesítménye: {2} ilvl%: {3}\n" +
                "A játékos DPS-e: {4}\n", grong.maxLvlFelszereles().getNev(),
                grong.maxLvlFelszereles().getFelszerelesLevel(),              
                grong.maxLvlFelszereles().getParse1(),
                grong.maxLvlFelszereles().getTeljesitmenyLevel(),
                grong.maxLvlFelszereles().getDps());

            Console.WriteLine("6. A Grongról kifagyott játékos adatai előző bossról: \n" +
                "A játékos neve: {0}\n" +
                "A jatekos ilvl-e: {1}\n" +
                "A játékos teljesítménye: {2} ilvl%: {3}\n" +
                "A játékos DPS-e: {4}\n", championOfLight.kifagyottJatekos(grong).getNev(),
                championOfLight.kifagyottJatekos(grong).getFelszerelesLevel(),
                championOfLight.kifagyottJatekos(grong).getParse1(),
                championOfLight.kifagyottJatekos(grong).getTeljesitmenyLevel(),
                championOfLight.kifagyottJatekos(grong).getDps());

            //Console.WriteLine("7. feladat: Felszerelést váltó játékosok: \n"+ grong.felszerelesValtoJatekosok(championOfLight).ToString());
            Console.WriteLine("8. Feladat: A legjobb telesítményű játékos\n"+grong.osszesitetLegjobbJatekos(championOfLight));
            kiiras(grong.kilencedikFeladat(championOfLight));

            Console.ReadKey();
        }

        private static void kiiras(string tartalom)
        {
            try
            {
                StreamWriter sw = new StreamWriter("champion_and_grong.csv");
                sw.WriteLine(tartalom);

                sw.Close();

            }
            catch (IOException)
            {
                Console.WriteLine("Sikertelen kiírás!");
            }
        }
    }
}
