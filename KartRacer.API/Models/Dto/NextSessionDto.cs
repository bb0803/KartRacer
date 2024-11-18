using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Dto
{
    public class NextSessionDto
    {
        public int X_ClassId { get; set; }
        public Int32 X_CircuitId {  get; set; }
        public Int32 Yr { get; set; }
        public Int32 Series { get; set; }
        public Int16 Round { get; set; }
        public string SessionType {  get; set; } 
		public string SessionTitle {  get; set; }
        public Int16 Sequence {  get; set; }
        public string Description {  get; set; }
    }
}
