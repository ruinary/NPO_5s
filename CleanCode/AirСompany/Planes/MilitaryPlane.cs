using AirCompany.Types;

namespace AirCompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            Type = type;
        }

        public MilitaryType Type { get; }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   Type == plane.Type;
        }

        public override int GetHashCode()
        {
            var hashCodeFirstMultiplier = 1701194404;
            var hashCodeSecondMultiplier = -1521134295;
            return (hashCodeFirstMultiplier * hashCodeSecondMultiplier + base.GetHashCode()) *
                   (hashCodeFirstMultiplier + Type.GetHashCode());
        }

        public override string ToString()
        {
            var baseToString = base.ToString();
            var indexOfLastCurlyBracket = baseToString.LastIndexOf('}');
            return baseToString.Insert(indexOfLastCurlyBracket,
                $", type={Type}");
        }
    }
}