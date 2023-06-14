using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Answers_and_questions;
using Methods; 

namespace Exam_porf
{
    internal class Program
    {

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            List<Question> easyQuestions = Answers_and_questions.Answers_and_questions.GetEasyQuestions();
            List<Question> mediumQuestions = Answers_and_questions.Answers_and_questions.GetMediumQuestions();
            List<Question> hardQuestions = Answers_and_questions.Answers_and_questions.GetHardQuestions();

            List<Answer> easyAnswers = Answers_and_questions.Answers_and_questions.GetEasyAnswers();
            List<Answer> mediumAnswers = Answers_and_questions.Answers_and_questions.GetMediumAnswers();
            List<Answer> hardAnswers = Answers_and_questions.Answers_and_questions.GetHardAnswers();

            string Name = "C:\\Users\\gdima\\source\\repos\\Exam_porf\\Exam_porf\\Record.txt";

            Player player = new Player();
            bool isGameActive = true;

            Console.WriteLine("Ласкаво просимо до гри \"Хто хоче стати мільйонером\"!");
            Console.WriteLine("1 - Почати гру . 2 - Таблиця лідерів");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("Введіть ваше ім'я:");
                    player.Name = Console.ReadLine();


                    while (isGameActive)
                    {
                        // Виведення питання та варіантів відповідей
                        Question currentQuestion = Methods.Methods.GetNextQuestion(player.QuestionLevel, easyQuestions, mediumQuestions, hardQuestions);

                        //Перевірка на підсказки
                        if (player.QuestionLevel == 5)
                        {
                            Console.WriteLine("\nБажаєте скористатися підказкою? (Так/Ні)");
                            string hintChoice = Console.ReadLine().ToLower();

                            if (hintChoice == "так")
                            {
                                Methods.Methods.FiftyFifty(currentQuestion, easyAnswers);
                            }
                        }
                        if (player.QuestionLevel == 9)
                        {
                            Console.WriteLine("\nБажаєте скористатися підказкою? (Так/Ні)");
                            string hintChoice = Console.ReadLine().ToLower();

                            if (hintChoice == "так")
                            {
                                Methods.Methods.CallFriend(currentQuestion);
                            }
                        }
                        if (player.QuestionLevel == 14)
                        {
                            Console.WriteLine("\nБажаєте скористатися підказкою? (Так/Ні)");
                            string hintChoice = Console.ReadLine().ToLower();

                            if (hintChoice == "так")
                            {
                                Methods.Methods.AudienceHelp(currentQuestion);
                            }
                        }

                        string text = currentQuestion.Text;
                        Console.WriteLine(text);

                        // Перевірка правильності відповіді
                        bool isAnswerCorrect = Methods.Methods.CheckAnswer(currentQuestion, easyAnswers, mediumAnswers, hardAnswers);
                        if (isAnswerCorrect)
                        {
                            player.IncrementQuestionLevel();
                            player.IncreasePrizeMoney(currentQuestion.PrizeMoney);
                        }
                        else
                        {
                            player.SaveToFile(Name);
                            isGameActive = false;
                            break;
                        }

                        // Перевірка, чи гравець бажає закінчити гру
                        if (player.QuestionLevel == 15)
                        {
                            Console.WriteLine("\nВітаємо! Ви виграли максимальний призовий грошовий фонд!");
                            isGameActive = false;
                            break;
                        }

                        Console.WriteLine("\nНаступне запитання:");
                    }

                    Console.WriteLine($"\nГра закінчена. Ви виграли {player.PrizeMoney} грн. Дякуємо за участь!");
                    break;
                case 2: Methods.Methods.DisplayLeaderboard(Name); break;
            }
        }
    }
}
