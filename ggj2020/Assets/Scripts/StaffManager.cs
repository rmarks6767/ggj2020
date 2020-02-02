using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class StaffManager : MonoBehaviour
    {

     

        private List<string> firstNameList = new List<string>();
        private List<string> lastNameList = new List<string>();


        private int StaffIdCounter = 0;


        // Start is called before the first frame update
        void Start()
        {
			
        }

        // Update is called once per frame
        void Update()
        {

        }


        //public Create


        /// <summary>
        /// Returns a full name as a string 
        /// </summary>
        /// <returns></returns>
        public string RandomlySelectName()
        {
            string firstName;
            string lastName;

            firstName = firstNameList[Random.Range(0, firstNameList.Count)];
            lastName = lastNameList[Random.Range(0, lastNameList.Count)];

            return firstName + " " + lastName;
        }


        /// <summary>
        /// Fils the list with random Names
        /// </summary>
        private void FillNameListS()
        {
            firstNameList.Add("Darragh");
            firstNameList.Add("Fay");
            firstNameList.Add("Teodor");
            firstNameList.Add("Izabella");
            firstNameList.Add("Mercy");
            firstNameList.Add("Ayse");
            firstNameList.Add("Dolores");
            firstNameList.Add("Anjali");
            firstNameList.Add("Daniella");
            firstNameList.Add("Katie");
            firstNameList.Add("Huzaifah");
            firstNameList.Add("Connah");
            firstNameList.Add("Shabaz");
            firstNameList.Add("Murtaza");
            firstNameList.Add("August");
            firstNameList.Add("Lewis");
            firstNameList.Add("Sammy");
            firstNameList.Add("Humera");
            firstNameList.Add("Bree");
            firstNameList.Add("Yuvaan");
            firstNameList.Add("Sarah");
            firstNameList.Add("Leilani");
            firstNameList.Add("Marcus");
            firstNameList.Add("Elsa");
            firstNameList.Add("Emeli");
            firstNameList.Add("Aminah");
            firstNameList.Add("Sumaiyah");
            firstNameList.Add("Vladimir");
            firstNameList.Add("Nevaeh");
            firstNameList.Add("Marguerite");
            firstNameList.Add("Nikodem");
            firstNameList.Add("Maxwell");
            firstNameList.Add("Dev");
            firstNameList.Add("Avneet");
            firstNameList.Add("Lorena");
            firstNameList.Add("Pia");
            firstNameList.Add("Emilija");
            firstNameList.Add("Tiah");
            firstNameList.Add("Willow");
            firstNameList.Add("Neriah");
            firstNameList.Add("Freja");
            firstNameList.Add("Andrea");
            firstNameList.Add("Elinor");
            firstNameList.Add("Ernest");
            firstNameList.Add("Kylan");
            firstNameList.Add("Jevan");
            firstNameList.Add("Sid");
            firstNameList.Add("Keegan");
            firstNameList.Add("Grayson");
            firstNameList.Add("Santino");
            firstNameList.Add("Nansi");
            firstNameList.Add("Velma");
            firstNameList.Add("Krish");
            firstNameList.Add("Shiv");
            firstNameList.Add("Nicola");
            firstNameList.Add("Chandler");
            firstNameList.Add("Tracey");
            firstNameList.Add("Kylo");
            firstNameList.Add("Hamzah");
            firstNameList.Add("Benn");
            firstNameList.Add("Mia");
            firstNameList.Add("Stanislaw");
            firstNameList.Add("Asim");
            firstNameList.Add("Lilli");
            firstNameList.Add("Kayden");
            firstNameList.Add("Rosalie");
            firstNameList.Add("Ajwa");
            firstNameList.Add("Lara");
            firstNameList.Add("Aiesha");
            firstNameList.Add("Carson");
            firstNameList.Add("Kyra");
            firstNameList.Add("Rubi");
            firstNameList.Add("Theodora");
            firstNameList.Add("Efan");
            firstNameList.Add("Ed");
            firstNameList.Add("Alaya");
            firstNameList.Add("Talia");
            firstNameList.Add("Darnell");
            firstNameList.Add("Caitlyn");
            firstNameList.Add("Alysha");
            firstNameList.Add("Azaan");
            firstNameList.Add("Rueben");
            firstNameList.Add("Layla");
            firstNameList.Add("Violet");
            firstNameList.Add("Karson");
            firstNameList.Add("Leigh");
            firstNameList.Add("Jareth");
            firstNameList.Add("Kelly");
            firstNameList.Add("Eoghan");
            firstNameList.Add("Aneesah");
            firstNameList.Add("Kaine");
            firstNameList.Add("Howard");
            firstNameList.Add("Andrei");
            firstNameList.Add("Jackson");
            firstNameList.Add("Nabiha");
            firstNameList.Add("Rhiannan");

            lastNameList.Add("Lister");
            lastNameList.Add("Moody");
            lastNameList.Add("Croft");
            lastNameList.Add("Roth");
            lastNameList.Add("Adam");
            lastNameList.Add("Espinoza");
            lastNameList.Add("Moses");
            lastNameList.Add("Howe");
            lastNameList.Add("Simon");
            lastNameList.Add("Snyder");
            lastNameList.Add("Bush");
            lastNameList.Add("Pitts");
            lastNameList.Add("Person");
            lastNameList.Add("Huang");
            lastNameList.Add("Logan");
            lastNameList.Add("Williams");
            lastNameList.Add("Norton");
            lastNameList.Add("Mendoza");
            lastNameList.Add("Winter");
            lastNameList.Add("Nelson");
            lastNameList.Add("Camacho");
            lastNameList.Add("Reynolds");
            lastNameList.Add("Hawkins");
            lastNameList.Add("Hardy");
            lastNameList.Add("Wainwright");
            lastNameList.Add("Arias");
            lastNameList.Add("Wilks");
            lastNameList.Add("Yang");
            lastNameList.Add("Forbes");
            lastNameList.Add("Leech");
            lastNameList.Add("Andrade");
            lastNameList.Add("Barr");
            lastNameList.Add("Alexander");
            lastNameList.Add("Carroll");
            lastNameList.Add("Jefferson");
            lastNameList.Add("Hancock");
            lastNameList.Add("Velazquez");
            lastNameList.Add("Henry");
            lastNameList.Add("Gamble");
            lastNameList.Add("Wiley");
            lastNameList.Add("Garrett");
            lastNameList.Add("Barnes");
            lastNameList.Add("Lester");
            lastNameList.Add("Penn");
            lastNameList.Add("Medina");
            lastNameList.Add("Gibson");
            lastNameList.Add("Guzman");
            lastNameList.Add("Fernandez");
            lastNameList.Add("Maguire");
            lastNameList.Add("Bishop");
            lastNameList.Add("Cunningham");
            lastNameList.Add("Whitley");
            lastNameList.Add("Chapman");
            lastNameList.Add("Rodriquez");
            lastNameList.Add("Snow");
            lastNameList.Add("Stokes");
            lastNameList.Add("Hills");
            lastNameList.Add("Farley");
            lastNameList.Add("Cooke");
            lastNameList.Add("Sutherland");
            lastNameList.Add("Reader");
            lastNameList.Add("Hensley");
            lastNameList.Add("Truong");
            lastNameList.Add("Phillips");
            lastNameList.Add("Shepard");
            lastNameList.Add("Ellison");
            lastNameList.Add("Rivas");
            lastNameList.Add("Bentley");
            lastNameList.Add("Davie");
            lastNameList.Add("Castaneda");
            lastNameList.Add("Ramirez");
            lastNameList.Add("Greig");
            lastNameList.Add("Key");
            lastNameList.Add("Nielsen");
            lastNameList.Add("Bob");
            lastNameList.Add("Medrano");
            lastNameList.Add("Steele");
            lastNameList.Add("Moreno");
            lastNameList.Add("Nairn");
            lastNameList.Add("Chavez");
            lastNameList.Add("Alfaro");
            lastNameList.Add("Allen");
            lastNameList.Add("Jeffery");
            lastNameList.Add("Stark");
            lastNameList.Add("Connolly");
            lastNameList.Add("Nicholson");
            lastNameList.Add("Casey");
            lastNameList.Add("Garner");
            lastNameList.Add("Robbins");
            lastNameList.Add("Whitney");
            lastNameList.Add("Beech");
            lastNameList.Add("Fletcher");
            lastNameList.Add("Riddle");
            lastNameList.Add("Bernal");
            lastNameList.Add("Gates");
            lastNameList.Add("North");
        }



    }
}
