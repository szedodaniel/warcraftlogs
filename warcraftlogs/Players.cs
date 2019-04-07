using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcraftlogs
{
    class Players
    {
        private List<Player> champlist { get; }

        public Players(string fajlNev)
        {
            this.champlist = new List<Player>();
            try
            {
                StreamReader sr = new StreamReader(fajlNev, Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');
                    this.champlist.Add(new Player(Convert.ToInt32(adatok[0]),
                        adatok[1],
                        Convert.ToInt32(adatok[2]),
                        Convert.ToInt32(adatok[3]),
                        adatok[4].Equals("-") ? 0 : Convert.ToInt32(adatok[4]),
                        Convert.ToDouble(adatok[5].Replace(',','.')),
                        float.Parse(adatok[6].Replace(',','.'))
                        )
                        );
                }
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Fájl nem található");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba:" + e);
            }
        }
    
        public string kilencedikFeladat(Players p1)
        {
            string s = "";

            for (int i = 0; i < this.champlist.Count; i++)
            {
                if (p1.ToString().Contains(this.champlist[i].getNev()))
                {
                    s += string.Format("{0};{1};{2};{3};{4};{5};{6}\n", (p1.champlist[i].getParse1()+ this.champlist[i].getParse1())/2,
                        p1.champlist[i].getNev(),
                        (p1.champlist[i].getAmount()+ this.champlist[i].getAmount()),
                        (p1.champlist[i].getFelszerelesLevel()+ this.champlist[i].getFelszerelesLevel())/2,
                        (p1.champlist[i].getTeljesitmenyLevel()+ this.champlist[i].getTeljesitmenyLevel()),
                        (p1.champlist[i].getParse2()+ this.champlist[i].getParse2())/2,
                        (p1.champlist[i].getDps()+ p1.champlist[i].getDps())/2);
                }
            }
            
            return s;
        }
        
        public Player maxLvlFelszereles()
        {
            Player maxlvl = this.champlist[0];
            for (int i = 0; i < this.champlist.Count; i++)
            {
                if(this.champlist[i].getFelszerelesLevel() > maxlvl.getFelszerelesLevel())
                {
                    maxlvl = this.champlist[i];
                }
                if(maxlvl.getFelszerelesLevel() == this.champlist[i].getFelszerelesLevel() && maxlvl.getAmount() < this.champlist[i].getAmount())
                {
                    maxlvl = this.champlist[i];
                }

            }

            return maxlvl;
        }
        public string osszesitetLegjobbJatekos(Players p1)
        {
            string s = "";
            for (int i = 0; i < this.champlist.Count; i++)
            {
                if (this.legjobbTeljesitmenyuJatekos().getNev() == p1.champlist[i].getNev())
                {
                    s = string.Format("A játékos neve: {0} \n" +
                        "A játékos ilvl-e: {1} \n" +
                        "A játékos átlagos teljesítménye: {2} ilvl%: {3}\n" +
                        "A játékos átlagos DPS-e: {4}",
                        this.legjobbTeljesitmenyuJatekos().getNev(),
                        this.legjobbTeljesitmenyuJatekos().getFelszerelesLevel(),
                        (this.legjobbTeljesitmenyuJatekos().getParse1()+p1.champlist[i].getParse1())/2.0,
                        (this.legjobbTeljesitmenyuJatekos().getTeljesitmenyLevel()+p1.champlist[i].getTeljesitmenyLevel())/2.0,
                        (this.legjobbTeljesitmenyuJatekos().getDps()+ p1.champlist[i].getDps())/2
                        
                        );
                }
            }

            return s;
        }
        public Player legjobbTeljesitmenyuJatekos()
        {
            Player p = new Player();
            foreach (Player player in this.champlist)
            {
                if(player.getParse1() > p.getParse1())
                {
                    p = player;
                }
            }

            return p;
        }
        public List<Player> felszerelesValtoJatekosok(Players p2)
        {
            List<Player> jatekosok = new List<Player>();

            for (int i = 0; i < this.champlist.Count; i++)
            {
                Player player = this.champlist[i];
                Player player2 = p2.champlist[i];

                if (player.getNev().Equals(player2.getNev()) && !player.getFelszerelesLevel().Equals(player2.getFelszerelesLevel()))
                {
                    jatekosok.Add(player);
                    jatekosok.Add(player2);
                }
            }
            return jatekosok;
        }
        public Player kifagyottJatekos(Players ps)
        {
            Player p = new Player();
            
            for (int i = 0; i < ps.champlist.Count; i++)
            {
                if(!ps.ToString().Contains(this.champlist[i].getNev())) 
                {
                    p = this.champlist[i];
                }
            }
            return p;
        }
       
        public float teljesKiosztottDps()
        {
            float teljesdps = 0;

            for (int i = 0; i < this.champlist.Count; i++)
            {
                teljesdps += this.champlist[i].getDps();
            }
            return teljesdps;
        }

        public int sebzestOsztottJatekosokSzama()
        {
            int db = 0;
            for (int i = 0; i < this.champlist.Count; i++)
            {
                if(this.champlist[i].getAmount() > 0)
                {
                    db++;
                }
            }

            return db;
        }
        public override string ToString()
        {
            string s = "";

            foreach (Player player in this.champlist)
            {
                s += player + "\n";
            }
            return s;
        }
    }
}
