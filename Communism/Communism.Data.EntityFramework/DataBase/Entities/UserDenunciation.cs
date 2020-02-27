using System;

namespace Communism.Data.EntityFramework.DataBase.Entities
{
    public class UserDenunciation
    {
        public Guid Uid { get; set; }
        public string Text { get; set; }
        public Guid InformerUid { get; set; }
        public Guid DenunciationToUid { get; set; }
        public virtual User Informer { get; set; }
        public virtual User DenunciationTo { get; set; }
    }
}
