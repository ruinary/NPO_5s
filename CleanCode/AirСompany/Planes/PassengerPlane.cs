namespace AirCompany.Planes
{
    public class PassengerPlane : Plane
    {
        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity,
            int passengersCapacity)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            PassengersCapacity = passengersCapacity;
        }

        public int PassengersCapacity { get; }

        public override bool Equals(object obj)
        {
            var plane = obj as PassengerPlane;
            return plane != null &&
                   PassengersCapacity == plane.PassengersCapacity;
        }

        public override int GetHashCode()
        {
            var firstHashCodeMultiplier = 751774561;
            var secondHashCodeMultiplier = -1521134295;
            return (firstHashCodeMultiplier * secondHashCodeMultiplier + base.GetHashCode()) *
                   (secondHashCodeMultiplier + PassengersCapacity.GetHashCode());
        }

        public override string ToString()
        {
            var baseToString = base.ToString();
            var indexOfLastCurlyBracket = baseToString.LastIndexOf('}');
            return baseToString.Insert(indexOfLastCurlyBracket,
                $", passengersCapacity={PassengersCapacity}");
        }
    }
}