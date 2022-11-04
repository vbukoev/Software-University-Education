namespace MilitaryElite.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates
            => (IReadOnlyCollection<IPrivate>)this.privates;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Privates:");
            foreach (IPrivate pr in privates)
            {
                sb.AppendLine($"  {pr.ToString().TrimEnd()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
