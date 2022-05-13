    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    namespace ConsoleUno
    {
        class Program
        {
                //public static string[] cardTypes = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "wild", "skip", "+2", "+4" };
            //cardTypes = { "\u0030\uFE0F\u20E3", "\u0031\uFE0F\u20E3", "\u0032\uFE0F\u20E3", "\u0033\uFE0F\u20E3", "\u0034\uFE0F\u20E3", "\u0035\uFE0F\u20E3", "\u0036\uFE0F\u20E3", "\u0037\uFE0F\u20E3", "\u0038\uFE0F\u20E3", "\u0039\uFE0F\u20E3", "\U0001F921", "\U0001F6AB", "\u26A1\uFe0f", "\U0001F4A5" };
                public static int[] cardColors = { 12, 14, 9, 10 };

            

                public static string currentCard = "null";
                public static int currentColor = 0;

                public static Random random = new Random();

                public static List<CardData> cardDataList = new List<CardData>();
                public static List<CardData> possibleCards = new List<CardData>();

                public class CardData
                {
                    public string cardType { get; set; }
                    public string internalName { get; set; }
                    public int cardColor { get; set; }
                }


                void AddNormalCard(string internalName, string displayName)
                {
                    foreach (var color in cardColors)
                    {
                        possibleCards.Add(new CardData()
                        {
                            internalName = internalName,
                            cardType = displayName,
                            cardColor = color
                        });;
                    }
            }

            void initializeCard()
            {
                AddNormalCard("0", "\u0030\uFE0F\u20E3");
                AddNormalCard("1", "\u0031\uFE0F\u20E3");
                AddNormalCard("2", "\u0032\uFE0F\u20E3");
                AddNormalCard("3", "\u0033\uFE0F\u20E3");
                AddNormalCard("4", "\u0034\uFE0F\u20E3");
                AddNormalCard("5", "\u0035\uFE0F\u20E3");
                AddNormalCard("6", "\u0036\uFE0F\u20E3");
                AddNormalCard("7", "\u0037\uFE0F\u20E3");
                AddNormalCard("8", "\u0038\uFE0F\u20E3");
                AddNormalCard("9", "\u0039\uFE0F\u20E3");
                AddNormalCard("10", "\u0040\uFE0F\u20E3");
                AddNormalCard("wild", "1\U0001F921");
                AddNormalCard("skip", "\U0001F6AB");
                AddNormalCard("+2", "\u26A1\uFe0f");
                AddNormalCard("+4", "\U0001F4A5");
            }

            static void Main(string[] args)
                {

            

                Console.WriteLine(
                    Figgle.FiggleFonts.Ogre.Render("Console UNO \U0001F0CF"));

                    Console.WriteLine("Welcome to Console UNO, a product of my pain. This is the most painful project I've done");
                    Console.WriteLine("--------------------------------------------");

                    int playerCardNum = 0;



                    Console.WriteLine("Enter 'UNO' to start, or enter 'Guide' to find out more");
            
                string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "UNO":
                        case "uno":
                        case "Uno":
                        case "UNo":
                            initializeCard();
                            getCards();
                        playerCardNum += 7;
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

                    while (keepGoing)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Enter your move");
                        string userMove = Console.ReadLine();
                    


                        switch (userMove)
                        {
                            case "cards":
                                Console.Clear();
                                Console.WriteLine("");
                                foreach (var cardData in cardDataList)
                                {
                                    Console.BackgroundColor = (ConsoleColor)cardData.cardColor;
                                    Console.Write(cardData.cardType);
                                    Console.ResetColor();
                                    Console.Write("  ");
                                }
                                break;

                            case "pickup":
                                pickup();
                                break;

                            case "play":
                            Console.WriteLine("Enter the card you want to play");
                            string userTypeChoice = Console.ReadLine();
                        
                            var theObjectYouWant = cardDataList.FirstOrDefault(x => x.cardType.Contains(userTypeChoice));

                           if (theObjectYouWant != null && theObjectYouWant.cardType.Contains(userTypeChoice))
                            {
                                Console.WriteLine("working");
                            }
                            else
                            {
                                Console.WriteLine("not working");
                            } 

                            break; 
                        }
                    }




                    static void getCards()
                    {


                        Console.Clear();
                        Console.WriteLine("");


                        for (int i = 0; i < 7; i++)
                        {


                            int cardTypesRand = random.Next(0, card.Length);
                            int cardColorsRand = random.Next(0, cardColors.Length);

                            var randColor = cardColors[cardColorsRand];
                            var randType = possibleCards[cardTypesRand];


                        //Console Box

                            var boxLine1 = " " + randType + " ";


                            Console.ForegroundColor = (ConsoleColor)randColor;
                            Console.BackgroundColor = (ConsoleColor)randColor;
                            Console.Write(boxLine1);
                            Console.ResetColor();
                            Console.Write("  ");

                    

                        cardDataList.Add(new CardData() { cardType = boxLine1, cardColor = randColor });

                        }

                    }

                    static void pickup()
                    {
                      Dictionary<string, string> emojis = new Dictionary<string, string>();

                    Console.Clear();

                        int cardTypesRand = random.Next(0, cardTypes.Length);
                        int cardColorsRand = random.Next(0, cardColors.Length);

                        var randColor = cardColors[cardColorsRand];
                        var randType = cardTypes[cardTypesRand];


                        //Console Box

                        var boxLine1 = " " + randType + " ";
                        Console.WriteLine("");
                        Console.Write("Picked up:");
                        Console.ForegroundColor = (ConsoleColor)randColor;
                        Console.BackgroundColor = (ConsoleColor)randColor;
                        Console.Write(boxLine1);
                        Console.ResetColor();
                        Console.Write("  ");

                        cardDataList.Add(new CardData() { cardType = boxLine1, cardColor = randColor });
                    }


                    static void guide()
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Hey! Enter 'rules' to learn how to play, or enter 'cards' to find out what they mean!");
                    }
                }
            }
        }
