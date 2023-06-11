using System.Text;

namespace Exam_porf
{
    internal class Program
    {

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            List<Question> easyQuestions = GetEasyQuestions();
            List<Question> mediumQuestions = GetMediumQuestions();
            List<Question> hardQuestions = GetHardQuestions();

            List<Answer> easyAnswers = GetEasyAnswers();
            List<Answer> mediumAnswers = GetMediumAnswers();
            List<Answer> hardAnswers = GetHardAnswers();

            Player player = new Player();
            bool isGameActive = true;

            Console.WriteLine("Ласкаво просимо до гри 'Хто хоче стати мільйонером'!");

            while (isGameActive)
            {
                // Виведення питання та варіантів відповідей
                Question currentQuestion = GetNextQuestion(player.QuestionLevel, easyQuestions, mediumQuestions, hardQuestions);
                string text = currentQuestion.Text;
                Console.WriteLine(text);
                Answer.PrintAnswers(GetAnswersForQuestion(currentQuestion, easyAnswers, mediumAnswers, hardAnswers));

                Console.Write("\nВаша відповідь (введіть номер варіанту): ");
                int userChoice = int.Parse(Console.ReadLine());

                // Перевірка правильності відповіді
                bool isAnswerCorrect = CheckAnswer(userChoice, currentQuestion, easyAnswers, mediumAnswers, hardAnswers);
                if (isAnswerCorrect)
                {
                    Console.WriteLine("\nВідповідь правильна!");
                    player.IncrementQuestionLevel();
                    player.IncreasePrizeMoney(currentQuestion.PrizeMoney);
                }
                else
                {
                    Console.WriteLine("\nВідповідь неправильна!");
                    isGameActive = false;
                    break;
                }

                // Перевірка, чи досягнуто позначних запитань
                if (player.QuestionLevel == 5 || player.QuestionLevel == 10)
                {
                    Console.WriteLine("\nБажаєте скористатися підказкою? (Так/Ні)");
                    string hintChoice = Console.ReadLine().ToLower();

                    if (hintChoice == "так")
                    {
                        ProvideHint(player.QuestionLevel, currentQuestion, easyAnswers, mediumAnswers, hardAnswers);
                    }
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
        }
        static Question GetNextQuestion(int questionLevel, List<Question> easyQuestions, List<Question> mediumQuestions, List<Question> hardQuestions)
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

            /*int i = 0;
            while (randomAnswers.Count < 4)
            {
                int randomIndex = random.Next(i, i+4);
                Answer randomAnswer = answers[randomIndex];

                foreach (var item in randomAnswers)
                {
                    item.Cont(randomAnswer);
                }
            }*/

            for (int i = 0; i < answers.Count; i+=4)
            {
                if(answers[i].Cont(question.CorrectAnswer) == true)
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

        // Перевірити правильність відповіді
        static bool CheckAnswer(int userChoice, Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
        {
            List<Answer> answers = GetAnswersForQuestion(question, easyAnswers, mediumAnswers, hardAnswers);
            Answer selectedAnswer = answers[userChoice -1];
            return selectedAnswer.IsCorrect;
        }

        // Надати підказку гравцю
        static void ProvideHint(int questionLevel, Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
        {
            switch (questionLevel)
            {
                case 5:
                    FiftyFifty(question, easyAnswers, mediumAnswers, hardAnswers);
                    break;
                case 10:
                    CallFriend(question);
                    break;
                case 15:
                    AudienceHelp(question);
                    break;
            }
        }

        // Функція "50/50" - забрати 2 неправильні відповіді
        static void FiftyFifty(Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
        {
            List<Answer> answers = GetAnswersForQuestion(question, easyAnswers, mediumAnswers, hardAnswers);

            int countRemovedAnswers = 0;
            for (int i = 0; i < answers.Count; i++)
            {
                if (!answers[i].IsCorrect)
                {
                    answers.RemoveAt(i);
                    countRemovedAnswers++;
                    i--;
                }

                if (countRemovedAnswers == 2)
                    break;
            }

            Answer.PrintAnswers(answers);
        }

        // Функція "Дзвінок другу" - отримати пораду від друга
        static void CallFriend(Question question)
        {
            Console.WriteLine("\n[Дзвінок другу] Твій друг говорить, що він впевнений, що правильна відповідь - " +
                              $"{question.CorrectAnswer.Text}.");
        }

        // Функція "Допомога з залу" - отримати допомогу залу
        static void AudienceHelp(Question question)
        {
            Console.WriteLine("\n[Допомога з залу] Більшість глядачів вважають, що правильна відповідь - " +
                              $"{question.CorrectAnswer.Text}.");
        }

        static List<Question> GetEasyQuestions()
        {
            List<Question> questions = new List<Question>();

            // Перше запитання
            Question question1 = new Question()
            {
                Text = "Яка столиця України?",
                Level = QuestionLevel.Easy,
                PrizeMoney = 100,
                CorrectAnswer = new Answer() { Text = "Київ", IsCorrect = true }
            };
            questions.Add(question1);

            // Друге запитання
            Question question2 = new Question()
            {
                Text = "Яка найбільша річка в Україні?",
                Level = QuestionLevel.Easy,
                PrizeMoney = 200,
                CorrectAnswer = new Answer() { Text = "Дніпро", IsCorrect = true }
            };
            questions.Add(question2);

            // Третє запитання
            Question question3 = new Question()
            {
                Text = "Яка найвища гора в Україні?",
                Level = QuestionLevel.Easy,
                PrizeMoney = 300,
                CorrectAnswer = new Answer() { Text = "Говерла", IsCorrect = true }
            };
            questions.Add(question3);

            // Четверте запитання
            Question question4 = new Question()
            {
                Text = "Який найбільший острів в Україні?",
                Level = QuestionLevel.Easy,
                PrizeMoney = 500,
                CorrectAnswer = new Answer() { Text = "Хортиця", IsCorrect = true }
            };
            questions.Add(question4);

            // П'яте запитання
            Question question5 = new Question()
            {
                Text = "У якому році Україна отримала незалежність?",
                Level = QuestionLevel.Easy,
                PrizeMoney = 1000,
                CorrectAnswer = new Answer() { Text = "1991", IsCorrect = true }
            };
            questions.Add(question5);

            return questions;
        }

        // Запитання для середнього рівня
        static List<Question> GetMediumQuestions()
        {
            List<Question> questions = new List<Question>();

            // Шосте запитання
            Question question6 = new Question()
            {
                Text = "Як називається символ водню у періодичній системі хімічних елементів?",
                Level = QuestionLevel.Medium,
                PrizeMoney = 2000,
                CorrectAnswer = new Answer() { Text = "H", IsCorrect = true }
            };
            questions.Add(question6);

            // Сьоме запитання
            Question question7 = new Question()
            {
                Text = "Яка найбільша пустеля в світі?",
                Level = QuestionLevel.Medium,
                PrizeMoney = 4000,
                CorrectAnswer = new Answer() { Text = "Сахара", IsCorrect = true }
            };
            questions.Add(question7);

            // Восьме запитання
            Question question8 = new Question()
            {
                Text = "Хто написав роман 'Війна і мир'?",
                Level = QuestionLevel.Medium,
                PrizeMoney = 8000,
                CorrectAnswer = new Answer() { Text = "Лев Толстой", IsCorrect = true }
            };
            questions.Add(question8);

            // Дев'яте запитання
            Question question9 = new Question()
            {
                Text = "Яка найбільша країна в світі за площею?",
                Level = QuestionLevel.Medium,
                PrizeMoney = 16000,
                CorrectAnswer = new Answer() { Text = "Росія", IsCorrect = true }
            };
            questions.Add(question9);

            // Десяте запитання
            Question question10 = new Question()
            {
                Text = "Хто зображений на картині 'Мона Ліза'?",
                Level = QuestionLevel.Medium,
                PrizeMoney = 32000,
                CorrectAnswer = new Answer() { Text = "Леонардо да Вінчі", IsCorrect = true }
            };
            questions.Add(question10);

            return questions;
        }

        // Запитання для важкого рівня
        static List<Question> GetHardQuestions()
        {
            List<Question> questions = new List<Question>();

            // Одинадцяте запитання
            Question question11 = new Question()
            {
                Text = "Яка кількість планет у Сонячній системі?",
                Level = QuestionLevel.Hard,
                PrizeMoney = 64000,
                CorrectAnswer = new Answer() { Text = "8", IsCorrect = true }
            };
            questions.Add(question11);

            // Дванадцяте запитання
            Question question12 = new Question()
            {
                Text = "Хто написав трагедію 'Ромео і Джульєтта'?",
                Level = QuestionLevel.Hard,
                PrizeMoney = 125000,
                CorrectAnswer = new Answer() { Text = "Вільям Шекспір", IsCorrect = true }
            };
            questions.Add(question12);

            // Тринадцяте запитання
            Question question13 = new Question()
            {
                Text = "Яке найбільше озеро в світі за площею?",
                Level = QuestionLevel.Hard,
                PrizeMoney = 250000,
                CorrectAnswer = new Answer() { Text = "Каспійське море", IsCorrect = true }
            };
            questions.Add(question13);

            // Чотирнадцяте запитання
            Question question14 = new Question()
            {
                Text = "Хто написав п'єсу 'Гамлет'?",
                Level = QuestionLevel.Hard,
                PrizeMoney = 500000,
                CorrectAnswer = new Answer() { Text = "Вільям Шекспір", IsCorrect = true }
            };
            questions.Add(question14);

            // П'ятнадцяте запитання
            Question question15 = new Question()
            {
                Text = "Яка найбільша гора в світі за висотою?",
                Level = QuestionLevel.Hard,
                PrizeMoney = 1000000,
                CorrectAnswer = new Answer() { Text = "Еверест", IsCorrect = true }
            };
            questions.Add(question15);

            return questions;
        }

        // Відповіді для легкого рівня
        static List<Answer> GetEasyAnswers()
        {
            List<Answer> answers = new List<Answer>();

            // Перше запитання
            Answer answer1 = new Answer() { Text = "Київ", IsCorrect = true };
            Answer answer2 = new Answer() { Text = "Львів", IsCorrect = false };
            Answer answer3 = new Answer() { Text = "Харків", IsCorrect = false };
            Answer answer4 = new Answer() { Text = "Одеса", IsCorrect = false };

            // Друге запитання
            Answer answer5 = new Answer() { Text = "Дніпро", IsCorrect = true };
            Answer answer6 = new Answer() { Text = "Дунай", IsCorrect = false };
            Answer answer7 = new Answer() { Text = "Десна", IsCorrect = false };
            Answer answer8 = new Answer() { Text = "Случ", IsCorrect = false };

            // Третє запитання
            Answer answer9 = new Answer() { Text = "Говерла", IsCorrect = true };
            Answer answer10 = new Answer() { Text = "Брест", IsCorrect = false };
            Answer answer11 = new Answer() { Text = "Чорногора", IsCorrect = false };
            Answer answer12 = new Answer() { Text = "Ельбрус", IsCorrect = false };

            // Четверте запитання
            Answer answer13 = new Answer() { Text = "Хортиця", IsCorrect = true };
            Answer answer14 = new Answer() { Text = "Джарилгацька затока", IsCorrect = false };
            Answer answer15 = new Answer() { Text = "Тенерифе", IsCorrect = false };
            Answer answer16 = new Answer() { Text = "Камбоджа", IsCorrect = false };

            // П'яте запитання
            Answer answer17 = new Answer() { Text = "1991", IsCorrect = true };
            Answer answer18 = new Answer() { Text = "1986", IsCorrect = false };
            Answer answer19 = new Answer() { Text = "2000", IsCorrect = false };
            Answer answer20 = new Answer() { Text = "1975", IsCorrect = false };

            answers.Add(answer1);
            answers.Add(answer2);
            answers.Add(answer3);
            answers.Add(answer4);
            answers.Add(answer5);
            answers.Add(answer6);
            answers.Add(answer7);
            answers.Add(answer8);
            answers.Add(answer9);
            answers.Add(answer10);
            answers.Add(answer11);
            answers.Add(answer12);
            answers.Add(answer13);
            answers.Add(answer14);
            answers.Add(answer15);
            answers.Add(answer16);
            answers.Add(answer17);
            answers.Add(answer18);
            answers.Add(answer19);
            answers.Add(answer20);

            return answers;
        }

        // Відповіді для середнього рівня
        static List<Answer> GetMediumAnswers()
        {
            List<Answer> answers = new List<Answer>();

            // Шосте запитання
            Answer answer21 = new Answer() { Text = "H", IsCorrect = true };
            Answer answer22 = new Answer() { Text = "He", IsCorrect = false };
            Answer answer23 = new Answer() { Text = "O", IsCorrect = false };
            Answer answer24 = new Answer() { Text = "C", IsCorrect = false };

            // Сьоме запитання
            Answer answer25 = new Answer() { Text = "Сахара", IsCorrect = true };
            Answer answer26 = new Answer() { Text = "Каламі", IsCorrect = false };
            Answer answer27 = new Answer() { Text = "Мохаве", IsCorrect = false };
            Answer answer28 = new Answer() { Text = "Гобі", IsCorrect = false };

            // Восьме запитання
            Answer answer29 = new Answer() { Text = "Лев Толстой", IsCorrect = true };
            Answer answer30 = new Answer() { Text = "Федор Достоєвський", IsCorrect = false };
            Answer answer31 = new Answer() { Text = "Антон Чехов", IsCorrect = false };
            Answer answer32 = new Answer() { Text = "Іван Тургенєв", IsCorrect = false };

            // Дев'яте запитання
            Answer answer33 = new Answer() { Text = "Росія", IsCorrect = true };
            Answer answer34 = new Answer() { Text = "Канада", IsCorrect = false };
            Answer answer35 = new Answer() { Text = "Китай", IsCorrect = false };
            Answer answer36 = new Answer() { Text = "США", IsCorrect = false };

            // Десяте запитання
            Answer answer37 = new Answer() { Text = "Леонардо да Вінчі", IsCorrect = true };
            Answer answer38 = new Answer() { Text = "Рафаель", IsCorrect = false };
            Answer answer39 = new Answer() { Text = "Мікеланджело", IsCorrect = false };
            Answer answer40 = new Answer() { Text = "Вінсент ван Гог", IsCorrect = false };

            answers.Add(answer21);
            answers.Add(answer22);
            answers.Add(answer23);
            answers.Add(answer24);
            answers.Add(answer25);
            answers.Add(answer26);
            answers.Add(answer27);
            answers.Add(answer28);
            answers.Add(answer29);
            answers.Add(answer30);
            answers.Add(answer31);
            answers.Add(answer32);
            answers.Add(answer33);
            answers.Add(answer34);
            answers.Add(answer35);
            answers.Add(answer36);
            answers.Add(answer37);
            answers.Add(answer38);
            answers.Add(answer39);
            answers.Add(answer40);

            return answers;
        }

        // Відповіді для важкого рівня
        static List<Answer> GetHardAnswers()
        {
            List<Answer> answers = new List<Answer>();

            // Одинадцяте запитання
            Answer answer41 = new Answer() { Text = "8", IsCorrect = true };
            Answer answer42 = new Answer() { Text = "9", IsCorrect = false };
            Answer answer43 = new Answer() { Text = "7", IsCorrect = false };
            Answer answer44 = new Answer() { Text = "10", IsCorrect = false };

            // Дванадцяте запитання
            Answer answer45 = new Answer() { Text = "Вільям Шекспір", IsCorrect = true };
            Answer answer46 = new Answer() { Text = "Мольєр", IsCorrect = false };
            Answer answer47 = new Answer() { Text = "Данте Аліг'єрі", IsCorrect = false };
            Answer answer48 = new Answer() { Text = "Оскар Уайльд", IsCorrect = false };

            // Тринадцяте запитання
            Answer answer49 = new Answer() { Text = "Каспійське море", IsCorrect = true };
            Answer answer50 = new Answer() { Text = "Мічиган", IsCorrect = false };
            Answer answer51 = new Answer() { Text = "Байкал", IsCorrect = false };
            Answer answer52 = new Answer() { Text = "Суперіор", IsCorrect = false };

            // Чотирнадцяте запитання
            Answer answer53 = new Answer() { Text = "Вільям Шекспір", IsCorrect = true };
            Answer answer54 = new Answer() { Text = "Мольєр", IsCorrect = false };
            Answer answer55 = new Answer() { Text = "Данте Аліг'єрі", IsCorrect = false };
            Answer answer56 = new Answer() { Text = "Оскар Уайльд", IsCorrect = false };

            // П'ятнадцяте запитання
            Answer answer57 = new Answer() { Text = "Еверест", IsCorrect = true };
            Answer answer58 = new Answer() { Text = "Кіліманджаро", IsCorrect = false };
            Answer answer59 = new Answer() { Text = "Аконкагуа", IsCorrect = false };
            Answer answer60 = new Answer() { Text = "Дениалі", IsCorrect = false };

            answers.Add(answer41);
            answers.Add(answer42);
            answers.Add(answer43);
            answers.Add(answer44);
            answers.Add(answer45);
            answers.Add(answer46);
            answers.Add(answer47);
            answers.Add(answer48);
            answers.Add(answer49);
            answers.Add(answer50);
            answers.Add(answer51);
            answers.Add(answer52);
            answers.Add(answer53);
            answers.Add(answer54);
            answers.Add(answer55);
            answers.Add(answer56);
            answers.Add(answer57);
            answers.Add(answer58);
            answers.Add(answer59);
            answers.Add(answer60);

            return answers;
        }
    }

    // Клас, що представляє запитання
    class Question
    {
        public string Text { get; set; }
        public QuestionLevel Level { get; set; }
        public int PrizeMoney { get; set; }
        public Answer CorrectAnswer { get; set; }

    }

    // Клас, що представляє відповідь
    record Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public static void PrintAnswers(List<Answer> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {answers[i].Text}");
            }
        }

        public bool Cont(Answer answer) => (this.Text == answer.Text && this.IsCorrect == answer.IsCorrect);

    }

    // Перерахування для рівнів запитань
    enum QuestionLevel
    {
        Easy,
        Medium,
        Hard
    }

    // Клас, що представляє гравця
    class Player
    {
        public int QuestionLevel { get; set; }
        public int PrizeMoney { get; set; }

        public Player()
        {
            QuestionLevel = 1;
            PrizeMoney = 0;
        }

        public void IncrementQuestionLevel()
        {
            QuestionLevel++;
        }

        public void IncreasePrizeMoney(int amount)
        {
            PrizeMoney += amount;
        }
    }

    // Розширення для перемішування списку
    static class ListExtensions
    {
        private static Random random = new Random();

        public static List<Answer> RandomSwap(List<Answer> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }


}
