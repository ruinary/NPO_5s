using System.Collections.Generic;
using System.Linq;
using AirCompany.Planes;
using AirCompany.Types;

namespace AirCompany
{
    public class Airport
    {
        private readonly List<Plane> _planes;

        public IEnumerable<Plane> Planes => _planes;

        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return _planes.OfType<PassengerPlane>().ToList();
        }


        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return _planes.OfType<MilitaryPlane>().ToList();
        }


        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().OrderByDescending(x => x.PassengersCapacity).First();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().FindAll(x => x.Type == MilitaryType.TRANSPORT);
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(_planes.OrderBy(w => w.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(w => w.MaxFlightDistance));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(w => w.MaxLoadCapacity));
        }


        public override string ToString()
        {
            return "Airport{" +
                   "planes=" + string.Join(", ", _planes.Select(x => x.Model)) +
                   '}';
        }
    }
}