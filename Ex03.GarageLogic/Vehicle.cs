using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentage;
        private List<Wheel> m_Wheels;
        public Vehicle(string i_LicenseNumber, string i_ModelName)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>();
        }
        public string ModelName
        {
            get { return m_ModelName; }
        }
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }
        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    m_EnergyPercentage = value;
                }
                else
                {
                    throw new ValueRangeException(0, 100, "Energy Percentage");
                }
            }
        }
        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }
        public override string ToString()
        {
            return $"Model Name: {m_ModelName}\nLicense Number: {m_LicenseNumber}\nEnergy Percentage: {m_EnergyPercentage}%\nNumber of Wheels: {m_Wheels.Count}\n";
        }
    }
}
