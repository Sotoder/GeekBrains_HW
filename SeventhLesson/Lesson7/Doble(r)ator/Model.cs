using System;
using System.Collections.Generic;

namespace Doble_r_ator
{
    public class Model
    {
        Stack<int>[] appStack;

        public Model()
        {
            Stack<int>[] appStack = new Stack<int>[2] { new Stack<int>(), new Stack<int>()};
            appStack[0].Push(0);
            appStack[1].Push(0);
            this.appStack = appStack;
        }

        public string Plus(string text)
        {
            appStack[0].Push(appStack[0].Peek() + 1);
            appStack[1].Push(appStack[1].Peek() + 1);

            return appStack[1].Peek().ToString();
        }

        public string Mult(string text)
        {
            appStack[0].Push(appStack[0].Peek() + 1);
            appStack[1].Push(appStack[1].Peek() * 2);

            return appStack[1].Peek().ToString();
        }

        public string ChangeComandsCount(string comands)
        {
            string[] comandsArr = comands.Split(" ");
            if (appStack[0].Count == 0) comandsArr[2] = "0";
            else comandsArr[2] = appStack[0].Peek().ToString();
            return String.Join(" ", comandsArr);
        }

        public void DelFromStack()
        {
            appStack[0].Pop();
            appStack[1].Pop();
        }

        public int GetGameNumber()
        {
            Random rnd = new Random();
            return rnd.Next(appStack[1].Peek() + 1, appStack[1].Peek() + 10);
        }

        public int GetLastInStack(int index) => appStack[index].Peek();

        public int GetMinStepCount(int target)
        {
            int stepCount = 0;
            int curient = appStack[1].Peek();

            if (target == curient) return 0;
            else if (target - 1 == curient) return 1;
            else
            {
                if (target % 2 == 0) 
                {
                    if (target / 2 < curient) return target - curient;
                    else return stepCount + 1 + GetMinStepCount(target / 2);
                } 
                else
                {
                    if ((target - 1) / 2 < curient) return target - curient;
                    else return stepCount + 2 + GetMinStepCount((target - 1) / 2);
                }
            }
        }
    }
}