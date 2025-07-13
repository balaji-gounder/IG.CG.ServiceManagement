namespace IG.CG.Core.Application.Models
{
    public class SMSModel
    {
        //public string? UserId { get; set; }
        //public string? Password { get; set; }
        public string? ToNumber { get; set; }
        public string? SmsBody { get; set; }
    }


    public class SMSDetailsModel
    {
        public string? MForm { get; set; }
        public string? MTo { get; set; }

        public string? Mess { get; set; }
        public string? Remarks { get; set; }
        public string? REQID { get; set; }
        public string? SUBMITDATE { get; set; }
        public string? TID { get; set; }
    }
}
