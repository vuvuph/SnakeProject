using System.Collections.Generic;
using System.IO;

namespace SnakeProject.SnakeGame
{
    public class HighScores
    {
        private const string filePath = "C:\\Users\\Vu Phan\\AppData\\Local\\Highscores.txt";

        //Load high scores from a file
        public static List<int> LoadHighScores()
        {
            List<int> highScores = new List<int>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (int.TryParse(line, out int score))
                    {
                        highScores.Add(score);
                    }
                }
            }

            highScores.Sort();
            highScores.Reverse();
            return highScores;
        }

        //Save high scores to a file
        public static void SaveHighScores(List<int> highScores)
        {
            File.WriteAllLines(filePath, highScores.ConvertAll(score => score.ToString()));
        }

        //Update high scores list
        public static void UpdateHighScores(int newScore, List<int> highScores)
        {
            if (highScores.Count < 5 || newScore > highScores[highScores.Count - 1])
            {
                highScores.Add(newScore);
                highScores.Sort();
                highScores.Reverse();

                //Keep only the top 5 scores
                if (highScores.Count > 5)
                {
                    highScores.RemoveAt(5);
                }

                SaveHighScores(highScores);
            }
        }
    }
}
