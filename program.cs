using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


/* HELLO! Welcome to Tabogachi's ConsoleUno. This project was made in a week or so, and is a product of pain and suffering.
 * ------------------
 * if you find a better way to do stuff you can message me on discord (tabogachi#0602) and I might add it
 * this idea was sparked due to CSNET course at Waikato University out of spite of Xamarin and windows forms. 
 * ------------------
 * CHECKLIST:
 * 
 * add computer functionality 😭
 * make title screen actually look a bit more bearable (colors?)
 * add things other than picking up and putting down cards
 * add rules/guide
 * sleep 
 * optimize. lmao dev won't do this
 * comment more code so you know wtf your doing
 * sleep
 * ------------------
 * thank you for reading through these comments. don't know why you did, but you did, so good job
 * hmu on discord if you want, I'm almost always online
*/

namespace ConsoleUno
{
    class Program
    {
        //possible card types and colors
        public static string[] possibleTypes = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "wild", "skip", "+2", "+4" };
        public static int[] possibleColors = { 12, 14, 9, 10 };

        //the current card and color
        public static string currentCard = "N/A";
        public static int currentColor = 0;

        //storing the players cards
        public static List<(string type, int color)> playerCardsAndColors = new List<(string, int)>();

        static void Main(string[] args)
        {


            //title 
            Console.WriteLine(
                Figgle.FiggleFonts.Ogre.Render("Console UNO"));

            Console.WriteLine("Welcome to Console UNO, a product of my pain. This is the most painful project I've done");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Enter 'UNO' to start, or enter 'Guide' to find out more");

            string userInput = Console.ReadLine();
            //gets the start user input ONLY ONCE
            switch (userInput)
            {
                case "UNO":
                case "uno":
                case "Uno":
                case "UNo":
                    getCards();

                    break;
                case "Guide":
                case "guide":
                case "GUide":
                case "GUIDE":
                    guide();
                    break;

            }

            Console.ForegroundColor = ConsoleColor.White;
            bool keepGoing = true;

            //player move loop (needs adjusting for computer cards 😩
            while (keepGoing)
            {
                Console.WriteLine(" ");
                Console.WriteLine("---------------");
                Console.WriteLine("Enter your move");
                string userMove = Console.ReadLine();


                //the repeatable user input. options: cars, pickup, play
                switch (userMove)
                {
                    case "cards":
                        showCards();
                        break;

                    case "pickup":
                        pickup();
                        break;

                    case "play":
                        int userCardColorConvert = 0;

                        //user input for playing a card
                        Console.WriteLine("Enter the card you want to play");
                        string userCardTypeChoice = Console.ReadLine();
                        Console.WriteLine("Enter the color of the card");
                        string userCardColorChoice = Console.ReadLine();
                        bool somethingIdk = false;

                        //converting string to int (for the console color)
                        switch (userCardColorChoice)
                        {
                            case "green":
                                userCardColorConvert = 10;
                                break;
                            case "red":
                                userCardColorConvert = 12;
                                break;
                            case "yellow":
                                userCardColorConvert = 14;
                                break;
                            case "blue":
                                userCardColorConvert = 9;
                                break;
                        }


                        //if the input matches what's in the players deck set "somethingIdk" to true
                        foreach ((string type, int color) in playerCardsAndColors)
                        {
                            if (type == userCardTypeChoice && color == userCardColorConvert)
                            {
                                somethingIdk = true;
                            }

                        }

                        //because its a foreach loop i have to outsource :sob:
                        if (somethingIdk == true)
                        {
                            string emojiType = "";

                            //really stupid long internal to display thing that can be WAAAAAY shorter but the dev is way to lazy
                            switch (userCardTypeChoice)
                            {
                                case "0":
                                    emojiType = "\u0030\uFE0F\u20E3";
                                    break;
                                case "1":
                                    emojiType = "\u0031\uFE0F\u20E3";
                                    break;
                                case "2":
                                    emojiType = "\u0032\uFE0F\u20E3";
                                    break;
                                case "3":
                                    emojiType = "\u0033\uFE0F\u20E3";
                                    break;
                                case "4":
                                    emojiType = "\u0034\uFE0F\u20E3";
                                    break;
                                case "5":
                                    emojiType = "\u0035\uFE0F\u20E3";
                                    break;
                                case "6":
                                    emojiType = "\u0036\uFE0F\u20E3";
                                    break;
                                case "7":
                                    emojiType = "\u0037\uFE0F\u20E3";
                                    break;
                                case "8":
                                    emojiType = "\u0038\uFE0F\u20E3";
                                    break;
                                case "9":
                                    emojiType = "\u0039\uFE0F\u20E3";
                                    break;
                                case "wild":
                                    emojiType = "\U0001F921";
                                    break;
                                case "skip":
                                    emojiType = "\U0001F6AB";
                                    break;
                                case "+2":
                                    emojiType = "\u26A1\uFe0f";
                                    break;
                                case "+4":
                                    emojiType = "\U0001F4A5";
                                    break;
                            }
                            //setting the current card stuff
                            currentColor = userCardColorConvert;
                            currentCard = userCardTypeChoice;
                            //clearing the chosen card from player deck
                            playerCardsAndColors.Remove((userCardTypeChoice, userCardColorConvert));
                            Console.Clear();
                            //showCards() in any place will generate the current cards
                            showCards();
                            Console.WriteLine(" ");
                            Console.WriteLine("---------------");
                            Console.Write("Played: ");
                            Console.BackgroundColor = (ConsoleColor)userCardColorConvert;
                            Console.Write(" " + emojiType + " ");
                            Console.ResetColor();
                            
                        }
                        else
                        {
                            //if you enter the wrong card you might have brain damage you moron. ignore commented code here
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("You don't have that card" /*you fucking moron. Kill yourself you failed abortion*/);
                            Console.ResetColor();
                        }
                        break;
                }
            }



            //generating cards
            static void getCards()
            {


                Console.Clear();
                showCards();

                //generates 7 cards. adjust the i < 7 to generate any amount. broken if it goes over another line
                for (int i = 0; i < 7; i++)
                {
                    Random random = new Random();

                    //probably useless messy way to generate random card color and type
                    int cardTypesRand = random.Next(0, possibleTypes.Length);
                    int cardColorsRand = random.Next(0, possibleColors.Length);

                    var randColor = possibleColors[cardColorsRand];
                    var randType = possibleTypes[cardTypesRand];

                    
                    //adding the card to the player deck
                    playerCardsAndColors.Add((randType, randColor));

                    string emojiType = "";

                    //again more stupid internal to display. dev needs to shorten
                    switch (randType)
                    {
                        case "0":
                            emojiType = "\u0030\uFE0F\u20E3";
                            break;
                        case "1":
                            emojiType = "\u0031\uFE0F\u20E3";
                            break;
                        case "2":
                            emojiType = "\u0032\uFE0F\u20E3";
                            break;
                        case "3":
                            emojiType = "\u0033\uFE0F\u20E3";
                            break;
                        case "4":
                            emojiType = "\u0034\uFE0F\u20E3";
                            break;
                        case "5":
                            emojiType = "\u0035\uFE0F\u20E3";
                            break;
                        case "6":
                            emojiType = "\u0036\uFE0F\u20E3";
                            break;
                        case "7":
                            emojiType = "\u0037\uFE0F\u20E3";
                            break;
                        case "8":
                            emojiType = "\u0038\uFE0F\u20E3";
                            break;
                        case "9":
                            emojiType = "\u0039\uFE0F\u20E3";
                            break;
                        case "wild":
                            emojiType = "\U0001F921";
                            break;
                        case "skip":
                            emojiType = "\U0001F6AB";
                            break;
                        case "+2":
                            emojiType = "\u26A1\uFe0f";
                            break;
                        case "+4":
                            emojiType = "\U0001F4A5";
                            break;
                    }

                    var boxLine1 = " " + emojiType + " ";


                    Console.ForegroundColor = (ConsoleColor)randColor;
                    Console.BackgroundColor = (ConsoleColor)randColor;
                    Console.Write(boxLine1);
                    Console.ResetColor();
                    Console.Write("  ");
                }



            }

            //picks up a single card and adds it to player deck. review getCards() comments on what it does, it's a copy and paste
            static void pickup()
            {

                Console.Clear();
                Console.WriteLine(" ");
                Random random = new Random();

                int cardTypesRand = random.Next(0, possibleTypes.Length);
                int cardColorsRand = random.Next(0, possibleColors.Length);

                var randColor = possibleColors[cardColorsRand];
                var randType = possibleTypes[cardTypesRand];

                

                playerCardsAndColors.Add((randType, randColor));

                string emojiType = "";

                switch (randType)
                {
                    case "0":
                        emojiType = "\u0030\uFE0F\u20E3";
                        break;
                    case "1":
                        emojiType = "\u0031\uFE0F\u20E3";
                        break;
                    case "2":
                        emojiType = "\u0032\uFE0F\u20E3";
                        break;
                    case "3":
                        emojiType = "\u0033\uFE0F\u20E3";
                        break;
                    case "4":
                        emojiType = "\u0034\uFE0F\u20E3";
                        break;
                    case "5":
                        emojiType = "\u0035\uFE0F\u20E3";
                        break;
                    case "6":
                        emojiType = "\u0036\uFE0F\u20E3";
                        break;
                    case "7":
                        emojiType = "\u0037\uFE0F\u20E3";
                        break;
                    case "8":
                        emojiType = "\u0038\uFE0F\u20E3";
                        break;
                    case "9":
                        emojiType = "\u0039\uFE0F\u20E3";
                        break;
                    case "wild":
                        emojiType = "\U0001F921";
                        break;
                    case "skip":
                        emojiType = "\U0001F6AB";
                        break;
                    case "+2":
                        emojiType = "\u26A1\uFe0f";
                        break;
                    case "+4":
                        emojiType = "\U0001F4A5";
                        break;
                }

                var boxLine1 = " " + emojiType + " ";

                Console.Clear();
                showCards();
                Console.WriteLine(" ");
                Console.WriteLine("---------------");
                Console.Write("Picked up: ");
                Console.ForegroundColor = (ConsoleColor)randColor;
                Console.BackgroundColor = (ConsoleColor)randColor;
                Console.Write(boxLine1);
                Console.ResetColor();
                Console.Write("  ");
            }

            //displays guide as the starting command. dev needs to add rules
            static void guide()
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("Hey! Enter 'rules' to learn how to play, or enter 'emojis' to find out what cards mean!");
                string rulesInput = Console.ReadLine();
                switch (rulesInput)
                {
                    case "rules":
                    case "RULES":
                    case "Rules":
                    case "RUles":
                        Console.WriteLine("You start UNO with 7 cards each. Your goal is to get rid of all your cards before the" +
                            " other person can. You start first by placing a card down with the command 'play'. \nYou can also pickup with 'pickup'." +
                            " \nIf you've never played uno before, play real life uno first, \nas this experience is not even close to the real thing and " +
                            "is missing a lot of features,\nalso with the other player (bot) playing what ever card is possible." +
                            "\nThank you for taking time to read the rules, now go on to try beat the computer!");
                        Console.WriteLine("---------------");
                        Console.WriteLine("press any key to start!");
                        Console.ReadKey();
                        getCards();
                        break;
                    case "emojis":
                    case "EMOJIS":
                    case "Emojis":
                    case "EMojis":
                        break;
                }
                //getCards();

            }

            //displays the players deck at any given time this is used. may be broken(?)
            static void showCards()
            {
                Console.Clear();
                displayCurrentCard();
                Console.WriteLine("---------------");
                foreach (var both in playerCardsAndColors)
                {
                    string emojiType = "";


                    //dev please shorten this is stupid
                    switch (both.type)
                    {
                        case "0":
                            emojiType = "\u0030\uFE0F\u20E3";
                            break;
                        case "1":
                            emojiType = "\u0031\uFE0F\u20E3";
                            break;
                        case "2":
                            emojiType = "\u0032\uFE0F\u20E3";
                            break;
                        case "3":
                            emojiType = "\u0033\uFE0F\u20E3";
                            break;
                        case "4":
                            emojiType = "\u0034\uFE0F\u20E3";
                            break;
                        case "5":
                            emojiType = "\u0035\uFE0F\u20E3";
                            break;
                        case "6":
                            emojiType = "\u0036\uFE0F\u20E3";
                            break;
                        case "7":
                            emojiType = "\u0037\uFE0F\u20E3";
                            break;
                        case "8":
                            emojiType = "\u0038\uFE0F\u20E3";
                            break;
                        case "9":
                            emojiType = "\u0039\uFE0F\u20E3";
                            break;
                        case "wild":
                            emojiType = "\U0001F921";
                            break;
                        case "skip":
                            emojiType = "\U0001F6AB";
                            break;
                        case "+2":
                            emojiType = "\u26A1\uFe0f";
                            break;
                        case "+4":
                            emojiType = "\U0001F4A5";
                            break;
                    }

                    Console.BackgroundColor = (ConsoleColor)both.color;
                    Console.Write(" " + emojiType + " ");
                    Console.ResetColor();
                    Console.Write("  ");
                    emojiType = "";
                }

            }

            //displays the current card (duh). can be changed by the player or computer using "play"
            static void displayCurrentCard()
            {
                string emojiType = "";

                //dev istg please fix the stupid emoji thing
                switch (currentCard)
                {
                    case "0":
                        emojiType = "\u0030\uFE0F\u20E3";
                        break;
                    case "1":
                        emojiType = "\u0031\uFE0F\u20E3";
                        break;
                    case "2":
                        emojiType = "\u0032\uFE0F\u20E3";
                        break;
                    case "3":
                        emojiType = "\u0033\uFE0F\u20E3";   //pog 500 lines of suffering. cheers to another 500 more :sobbing:
                        break;
                    case "4":
                        emojiType = "\u0034\uFE0F\u20E3";
                        break;
                    case "5":
                        emojiType = "\u0035\uFE0F\u20E3";
                        break;
                    case "6":
                        emojiType = "\u0036\uFE0F\u20E3";
                        break;
                    case "7":
                        emojiType = "\u0037\uFE0F\u20E3";
                        break;
                    case "8":
                        emojiType = "\u0038\uFE0F\u20E3";
                        break;
                    case "9":
                        emojiType = "\u0039\uFE0F\u20E3";
                        break;
                    case "wild":
                        emojiType = "\U0001F921";
                        break;
                    case "skip":
                        emojiType = "\U0001F6AB";      
                        break;
                    case "+2":
                        emojiType = "\u26A1\uFe0f";
                        break;
                    case "+4":
                        emojiType = "\U0001F4A5";
                        break;
                }
                Console.Write("Current Card: ");
                Console.BackgroundColor = (ConsoleColor)currentColor;
                Console.Write(" " + emojiType + " ");
                Console.WriteLine("");
                Console.ResetColor();
            }
        }
    }
}





//basic functionality achived 15/5/2022
//massive thanks to TheRanger, Sammy Samour and JetTax absolute legends
//special thanks to devRant for obvious reasons
//remember to comment your code fellow devs. have a lovely day
