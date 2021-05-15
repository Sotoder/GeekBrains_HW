namespace Function
{
    public class DelegatesList
    {
        //Решил проверить, могу ли я сослаться на делегатов другого класса - Могу)
        //Да и чего бы не вынести список делегатов в отдельный лист.
        public delegate double Fun(double x);
        public delegate double Fun2(double x, double y);
    }
}