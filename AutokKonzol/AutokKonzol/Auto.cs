using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokKonzol
{
    internal class Auto
    {
        int sorszam, gyartasiEv, eladottDb, atlagosAr;
        string marka, modell, szin;

        public Auto(int sorszam, int gyartasiEv, int eladottDb, int atlagosAr, string marka, string modell, string szin)
        {
            this.Sorszam = sorszam;
            this.GyartasiEv = gyartasiEv;
            this.EladottDb = eladottDb;
            this.AtlagosAr = atlagosAr;
            this.Marka = marka;
            this.Modell = modell;
            this.Szin = szin;
        }
        public Auto(string CSVsor)
        {
            var mezo = CSVsor.Split(';');
            sorszam = int.Parse(mezo[0]);
            marka = mezo[1];
            modell = mezo[2];
            gyartasiEv = int.Parse(mezo[3]);
            szin = mezo[4];
            eladottDb=int.Parse(mezo[5]);
            atlagosAr = int.Parse(mezo[6]);
        }

        public int Sorszam { get => sorszam; set => sorszam = value; }
        public int GyartasiEv { get => gyartasiEv; set => gyartasiEv = value; }
        public int EladottDb { get => eladottDb; set => eladottDb = value; }
        public int AtlagosAr { get => atlagosAr; set => atlagosAr = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Modell { get => modell; set => modell = value; }
        public string Szin { get => szin; set => szin = value; }
    }
}
