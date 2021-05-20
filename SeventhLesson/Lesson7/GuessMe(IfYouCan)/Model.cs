using System;

namespace GuessMe_IfYouCan_
{
    class Model
    {
        public int TargetNumber
        {
            get => targetNumber;
            set => targetNumber = value;
        }

        int targetNumber;
        public Model()
        {
        }

        public void StarGame()
        {
            Random rnd = new Random();
            targetNumber = rnd.Next(1, 101);         
        }

        public bool CheckAnswer(int numberForCheck, out int diff)
        {
            diff = 0;
            if (numberForCheck != targetNumber)
            {
                diff = targetNumber - numberForCheck;
                return false;
            }
            else return true;
        }
    }
}