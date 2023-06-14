using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_porf;

namespace Answers_and_questions
{
    class Answers_and_questions
    {
        public static List<Question> GetEasyQuestions()
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
        public static List<Question> GetMediumQuestions()
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
        public static List<Question> GetHardQuestions()
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
        public static List<Answer> GetEasyAnswers()
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
        public static List<Answer> GetMediumAnswers()
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
        public static List<Answer> GetHardAnswers()
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
}
