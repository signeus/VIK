using VIK.Core.Interfaces;

namespace VIK.Core.Entities
{
    class CommandEntity : IEntity
    {
        public string VoiceCommand { get; set; }
        public string KeyCommand { get; set; }
        public string Description { get; set; }
        public string Speaking { get; set; }

        public CommandEntity()
        {

        }
    }
}
