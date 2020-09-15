using System;

namespace PonderingProgrammer.NTangle.Model
{
    public class TipRelation : IEquatable<TipRelation>
    {
        public TipRelation()
        {
        }
        
        public TipRelation(Tip source, Tip target, RelationType relationType) : this()
        {
            Source = source;
            Target = target;
            SourceTipId = source.Id;
            TargetTipId = target.Id;
            RelationType = relationType;
        }

        public int SourceTipId { get; private set; }
        public int TargetTipId { get; private set; }
        public Tip Source { get; private set; }
        public Tip Target { get; private set; }
        public RelationType RelationType { get; private set; }

        public bool Equals(TipRelation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return SourceTipId == other.SourceTipId && TargetTipId == other.TargetTipId && Equals(Source, other.Source) && Equals(Target, other.Target) && RelationType == other.RelationType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((TipRelation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = SourceTipId;
                hashCode = (hashCode * 397) ^ TargetTipId;
                hashCode = (hashCode * 397) ^ (Source != null ? Source.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Target != null ? Target.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) RelationType;
                return hashCode;
            }
        }

        public static bool operator ==(TipRelation left, TipRelation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TipRelation left, TipRelation right)
        {
            return !Equals(left, right);
        }
    }
}