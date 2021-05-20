
namespace Doble_r_ator
{
    public class Presenter
    {
        public MainWindow view;
        public Model model;
        int gameNumber, minStepCount;
        bool gameStart = false;

        public Presenter(MainWindow mainWindow)
        {
            this.view = mainWindow;
            model = new Model();
        }

        public void LetsPlus()
        {
            view.tbCount.Text = model.Plus(view.tbCount.Text);
            view.Comands = model.ChangeComandsCount(view.Comands);
            CheckGame();
        }

        private void CheckGame()
        {
            if (gameStart)
            {
                minStepCount--;
                if (minStepCount <= 0 && model.GetLastInStack(1) != gameNumber)
                {
                    view.ShowMessage("У вас кончились ходы");
                    minStepCount = 0;
                    gameStart = false;
                } else
                {
                    if (model.GetLastInStack(1) == gameNumber)
                    {
                        view.ShowMessage("Вы получили данное число!");
                        gameStart = false;
                    }
                    else if (model.GetLastInStack(1) > gameNumber)
                    {
                        view.ShowMessage("ЭРЭБОР!!!");
                        gameStart = false;
                    }
                }

            }
        }

        public void LetsMult()
        {
            view.tbCount.Text = model.Mult(view.tbCount.Text);
            view.Comands = model.ChangeComandsCount(view.Comands);
            CheckGame();
        }

        public void LetsCancel()
        {
            try
            {
                model.DelFromStack();
                UpdateTb();
            }
            catch
            {
                view.ShowMessage("Отменять больше нечего");
            }

        }

        public void UpdateTb()
        {
            view.Comands = model.ChangeComandsCount(view.Comands);
            view.Result = model.GetLastInStack(1).ToString();
        }

        internal void LetsPlay()
        {
            if (!gameStart)
            {
                view.ShowMessage("Давай сыграем!");
                gameNumber = model.GetGameNumber();
                minStepCount = model.GetMinStepCount(gameNumber);
                view.ShowMessage($"Попробуй получить число {gameNumber} за {minStepCount.ToString()} " + GetEnd(minStepCount));
                gameStart = true;
                
            } else view.ShowMessage("Игра уже идет!");

        }

        private string GetEnd(int stepCount)
        {
            if (stepCount >= 5 && stepCount < 21)
            {
                return "шагов";
            }
            else
            {
                var mod = stepCount % 10;
                return mod switch
                {
                    1 => "шаг",
                    >= 2 and <= 4 => "шага",
                    >= 5 or 0 => "шагов"
                };
            }
        }
    }
}