using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_porf;

namespace Methods
{
    class Methods
    {
        public static void DisplayLeaderboard(string filePath)
        {
            Console.WriteLine("Leaderboard:");

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');

                        if (data.Length == 2)
                        {
                            string name = data[0];
                            string winnings = data[1];

                            Console.WriteLine($"Player: {name} - Winnings: {winnings}");
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Leaderboard file not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the leaderboard: {ex.Message}");
            }

        }



        public static Question GetNextQuestion(int questionLevel, List<Question> easyQuestions, List<Question> mediumQuestions, List<Question> hardQuestions)
        {
            switch (questionLevel)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return GetRandomQuestion(easyQuestions);
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return GetRandomQuestion(mediumQuestions);
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    return GetRandomQuestion(hardQuestions);
                default:
                    return null;
            }
        }



        // Отримати випадкове запитання зі списку запитань
        static Question GetRandomQuestion(List<Question> questions)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, questions.Count);
            return questions[randomIndex];
        }

        // Отримати варіанти відповідей для питання залежно від рівня складності
        static List<Answer> GetAnswersForQuestion(Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
        {
            switch (question.Level)
            {
                case QuestionLevel.Easy:
                    return GetRandomAnswers(question, easyAnswers);
                case QuestionLevel.Medium:
                    return GetRandomAnswers(question, mediumAnswers);
                case QuestionLevel.Hard:
                    return GetRandomAnswers(question, hardAnswers);
                default:
                    return null;
            }
        }

        // Отримати випадкові відповіді для питання
        static List<Answer> GetRandomAnswers(Question question, List<Answer> answers)
        {
            //Random random = new Random();
            List<Answer> randomAnswers = new List<Answer>();
            randomAnswers.Add(question.CorrectAnswer);

            for (int i = 0; i < answers.Count; i += 4)
            {
                if (answers[i].Cont(question.CorrectAnswer) == true)
                {
                    randomAnswers.Add(answers[++i]);
                    randomAnswers.Add(answers[++i]);
                    randomAnswers.Add(answers[++i]);

                    randomAnswers = ListExtensions.RandomSwap(randomAnswers);
                    Answer.PrintAnswers(randomAnswers);
                    return randomAnswers;
                }
            }
            return randomAnswers;
        }

        // Перевірити правильність відповіді
        public static bool CheckAnswer(Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
        {
            List<Answer> answers = GetAnswersForQuestion(question, easyAnswers, mediumAnswers, hardAnswers);
            Console.Write("\nВаша відповідь (введіть номер варіанту : 0 - вихід): ");
            int userChoice = int.Parse(Console.ReadLine());
            if (userChoice == 0)
            {
                Console.WriteLine("\nВи забрали гроші!");
                return false;
            }
            else
            {
                Answer selectedAnswer = answers[userChoice - 1];
                Console.WriteLine("\nВідповідь правильна!");
                return selectedAnswer.IsCorrect;
            }


        }


        // Функція "50/50" - забрати 2 неправильні відповіді
        public static void FiftyFifty(Question question, List<Answer> easyAnswers)
        {
            List<Answer> answers = GetAnswerForHelp(question, easyAnswers);


            Console.WriteLine("Дві відповіді:");
            int countRemovedAnswers = 0;
            for (int i = 0; i < answers.Count; i++)
            {
                if (!easyAnswers[i].IsCorrect)
                {
                    answers.RemoveAt(i);
                    answers.RemoveAt(i);
                    countRemovedAnswers++;
                    countRemovedAnswers++;
                    i--;
                }

                if (countRemovedAnswers == 2)
                    break;
            }

            Answer.PrintAnswers(answers);
        }


        static List<Answer> GetAnswerForHelp(Question question, List<Answer> answers)
        {
            //Random random = new Random();
            List<Answer> randomAnswers = new List<Answer>();
            randomAnswers.Add(question.CorrectAnswer);

            for (int i = 0; i < answers.Count; i += 4)
            {
                if (answers[i].Cont(question.CorrectAnswer) == true)
                {
                    randomAnswers.Add(answers[++i]);
                    randomAnswers.Add(answers[++i]);
                    randomAnswers.Add(answers[++i]);

                    randomAnswers = ListExtensions.RandomSwap(randomAnswers);
                    return randomAnswers;
                }
            }
            return randomAnswers;
        }

        // Функція "Дзвінок другу" - отримати пораду від друга
        public static void CallFriend(Question question)
        {
            Console.WriteLine("\n[Дзвінок другу] Твій друг говорить, що він впевнений, що правильна відповідь - " +
                              $"{question.CorrectAnswer.Text}.");
        }

        // Функція "Допомога з залу" - отримати допомогу залу
        public static void AudienceHelp(Question question)
        {
            Console.WriteLine("\n[Допомога з залу] Більшість глядачів вважають, що правильна відповідь - " +
                              $"{question.CorrectAnswer.Text}.");
        }
    }
}
