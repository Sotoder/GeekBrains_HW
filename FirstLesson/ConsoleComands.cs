using System;

public class ConsoleComands
{
	public void Pause()
	{
		Console.Write("Нажмите любую клавишу для продолжения");
		Console.ReadLine();
	}

	public void ChangeColor(ConsoleColor color)
    {
		Console.ForegroundColor = color;
	}

	public void ResetColor()
	{
		Console.ForegroundColor = ConsoleColor.White;
	}

}
