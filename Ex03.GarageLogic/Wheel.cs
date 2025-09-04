using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        public Wheel(string i_ManufacturerName , float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = 0;
        }
        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value < m_MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
            }
        }
        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }
        public void InflationTire(float airToAdd)
        {
            if (m_CurrentAirPressure + airToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += airToAdd;
            }
        }
    }
}
