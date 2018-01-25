namespace calendarProject
{
    public interface IMonth
    {
        int Get();
        void Incriment();
        void Set(int month);
        string GetMonthName();

        void PerformMoonCorrection();
    }
}