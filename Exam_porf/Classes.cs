namespace Exam_porf
{

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
        public string Name { get; set; }
        public int QuestionLevel { get; set; }
        public int PrizeMoney { get; set; }

        public Player()
        {
            QuestionLevel = 1;
            PrizeMoney = 0;
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine($"{Name};{PrizeMoney}");
                Console.WriteLine();
            }
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
