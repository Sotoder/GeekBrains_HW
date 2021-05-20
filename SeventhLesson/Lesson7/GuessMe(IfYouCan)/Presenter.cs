using System;
using System.Windows;

namespace GuessMe_IfYouCan_
{
    public class Presenter
    {
        MainWindow mainWindow;
        Model model;
        public static int step = 3;

        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            model = new Model();
        }

        internal void LetsStart()
        {
            mainWindow.ShowMessage("Компьютер загадает число от 1 до 100.\nУгадайте число за 3 хода");
            model.StarGame();
            mainWindow.TbOn();
            mainWindow.btnFormForAnswer.IsEnabled = true;
        }

        public void LetsCheckAnswer(string text, IView curWindow)
        {
            step--;
            bool isRight = model.CheckAnswer(Convert.ToInt32(text), out int diff);
            if (step != 0 || isRight)
            { 
                if (isRight)
                {
                    mainWindow.ShowMessage("Верно! Вы угадали");
                } else
                {
                    mainWindow.ShowMessage(diff switch
                                            {
                                                > 0 => "Не верно! Загаданное число больше!",
                                                < 0 => "Не верно! Загаданное число меньше!"
                                            }
                                            );

                }
            } else
            {
                mainWindow.ShowMessage($"Игра закончена, вы не угадали.\nКомпьютер загадал {model.TargetNumber}");
                curWindow.TbOff();
            }
        }
    }
}