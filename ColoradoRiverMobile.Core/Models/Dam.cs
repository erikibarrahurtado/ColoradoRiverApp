using System;
namespace ColoradoRiverMobile.Core.Models
{
    public class Dam
    {
        public Dam()
        {
        }
        public int DamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompletionYear { get; set; }
        public string ImageName { get; set; }
        public int GPIO { get; set; }
        public string AnswerImageName { get; set; }
        public string AnswerDescription { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
    }
}
