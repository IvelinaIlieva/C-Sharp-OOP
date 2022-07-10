namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;
    public interface ILieutenantGeneral: IPrivate
    {
        List<Private> Privates { get; }
    }
}
