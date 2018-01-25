namespace CalendarApp.Models
{
    public interface IDayModel
    {
        int Get();
        void Incriment();
        void Set(int day);
        void SetLongMonth();
        void SetShortMonth();

        bool IsShortMonth();
    }
}