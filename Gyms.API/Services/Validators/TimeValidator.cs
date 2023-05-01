namespace Gyms.API.Services.Validators
{
    public class TimeValidator
    {
        public static bool CheckIfOverlap(TimeOnly start1, TimeOnly end1, TimeOnly start2, TimeOnly end2)
        {
            if (end1 < start2 || end2 < start1)
            {
                return false;
            }

            return true;
        }
    }
}
