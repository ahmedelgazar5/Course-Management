namespace CourseManagmentBLL.DTO.SessionDto
{
    public class SessionGetByIdDto
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public int DurationInMins { get; set; }
        public int CourseId { get; set; }

    }
}

