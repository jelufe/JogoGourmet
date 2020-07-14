using JogoGourmet.Models;
using System;
using System.Collections.Generic;

namespace JogoGourmet
{
    class Program
    {
        private static QuestionTree question = new QuestionTree("Massa", "Lasanha", "Bolo de Chocolate");
        static void Main(string[] args)
        {
            startGame();
        }

        static private void startGame()
        {
            Console.WriteLine("---- Jogo Gourmet ----");
            Console.WriteLine("Pense em um prato que gosta (Digite 'S' e pressione enter para continuar ou Digite qualquer outra coisa para sair)");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "S")
            {
                runQuestion();
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        static private void runQuestion()
        {
            Console.WriteLine("\nO prato que você pensou é " + question.QuestionParam + "? (Digite 'S' para sim e 'N' para não)");
            string answer = Console.ReadLine();

            switch (answer.ToUpper())
            {
                case "S":
                    if (question.nodesYes.Count > 0)
                    {
                        enterNodes(question.nodesYes, question.YesAnswer);
                    } else
                    {
                        Console.WriteLine("\nO prato que você pensou é " + question.YesAnswer + "? (Digite 'S' para sim e 'N' para não)");
                        string answerYes = Console.ReadLine();
                        switch (answerYes.ToUpper())
                        {
                            case "S":
                                Console.WriteLine("\nAcertei!\n");
                                startGame();
                                break;
                            case "N":
                                question.nodesYes.Add(addNewQuestion(question.YesAnswer));
                                startGame();
                                break;
                            default:
                                System.Environment.Exit(0);
                                break;
                        }
                    }
                    break;
                case "N":

                    if (question.nodesNo.Count > 0)
                    {
                        enterNodes(question.nodesNo, question.NoAnswer);
                    }
                    else
                    {
                        Console.WriteLine("\nO prato que você pensou é " + question.NoAnswer + "? (Digite 'S' para sim e 'N' para não)");
                        string answerNo = Console.ReadLine();
                        switch (answerNo.ToUpper())
                        {
                            case "S":
                                Console.WriteLine("\nAcertei!\n");
                                startGame();
                                break;
                            case "N":
                                question.nodesNo.Add(addNewQuestion(question.NoAnswer));
                                startGame();
                                break;
                            default:
                                System.Environment.Exit(0);
                                break;
                        }
                    }
                    break;
                default:
                    System.Environment.Exit(0);
                    break;
            }
        }

        static private QuestionTree addNewQuestion(string questionParam)
        {
            Console.WriteLine("\nQual prato você pensou?");
            string answer = Console.ReadLine();
            while (answer == "" || answer == null)
            {
                Console.WriteLine("\n*Por favor, digite alguma coisa :)");
                Console.WriteLine("Qual prato você pensou?");
                answer = Console.ReadLine();
            }
            Console.WriteLine("\n" + answer + " é _________ mas " + questionParam + " não.");
            string answer2 = Console.ReadLine();
            while (answer2 == "" || answer2 == null)
            {
                Console.WriteLine("\n*Por favor, digite alguma coisa :)");
                Console.WriteLine(answer + " é _________ mas " + questionParam + " não.");
                answer2 = Console.ReadLine();
            }
            Console.WriteLine("\n");
            QuestionTree questionNew = new QuestionTree(answer2, answer, "");
            return questionNew;
        }

        static private void enterNodes(List<QuestionTree> nodes, string lastQuestion)
        {
            nodes.ForEach(node =>
            {
                Console.WriteLine("\nO prato que você pensou é " + node.QuestionParam + "? (Digite 'S' para sim e 'N' para não)");
                string answerNo = Console.ReadLine();
                switch (answerNo.ToUpper())
                {
                    case "S":
                        if (node.nodesYes.Count > 0)
                        {
                            enterNodes(node.nodesYes, node.YesAnswer);
                        }
                        Console.WriteLine("\nO prato que você pensou é " + node.YesAnswer + "? (Digite 'S' para sim e 'N' para não)");
                        string answerNode = Console.ReadLine();
                        switch (answerNode.ToUpper())
                        {
                            case "S":
                                Console.WriteLine("\nAcertei!\n");
                                startGame();
                                break;
                            case "N":
                                node.nodesYes.Add(addNewQuestion(node.YesAnswer));
                                startGame();
                                break;
                            default:
                                System.Environment.Exit(0);
                                break;
                        }
                        startGame();
                        break;
                    case "N":
                        break;
                    default:
                        System.Environment.Exit(0);
                        break;
                }
            });


            Console.WriteLine("\nO prato que você pensou é " + lastQuestion + "? (Digite 'S' para sim e 'N' para não)");
            string answerNo = Console.ReadLine();
            switch (answerNo.ToUpper())
            {
                case "S":
                    Console.WriteLine("\nAcertei!\n");
                    startGame();
                    break;
                case "N":
                    nodes.Add(addNewQuestion(lastQuestion));
                    startGame();
                    break;
                default:
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}
