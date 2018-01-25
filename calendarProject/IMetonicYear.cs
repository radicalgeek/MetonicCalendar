namespace calendarProject
{
    public interface IMetonicYear
    {
        int GetMetonicYear();
        void IncrimentYear();
        bool IsLeapYear();
        void SetMetonicYear(int yeartoSet);
    }
}