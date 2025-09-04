using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eStatus m_VehicleStatus;
        public GarageVehicle(Vehicle i_Vehicle ,string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = eStatus.InRepair;
        }
        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }
        public string OwnerName
        {
            get { return m_OwnerName; }
        }
        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
        }
        public eStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }
        public override string ToString()
        {
            return string.Format("Owner Name: {0}\nOwner Phone Number: {1}\nVehicle Status: {2}\nVehicle Information:{3}\n",
                m_OwnerName,
                m_OwnerPhoneNumber,
                m_VehicleStatus.ToString(),
                m_Vehicle.ToString());
        }
    }
}
