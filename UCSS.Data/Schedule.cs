namespace UCSS.Data
{
    public class Schedule
    {
        public int TeacherId { get; set; }
        public string Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int RoomId { get; set; }
    }
}