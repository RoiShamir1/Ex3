using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_CurrentBatteryTime;
        private float m_MaxBatteryTime;
        public ElectricVehicle(string i_LicenseNumber ,string i_ModelName)
            : base(i_LicenseNumber ,i_ModelName)
        {
            m_CurrentBatteryTime = 0;
        }

        public float CurrentBatteryTime
        {
            get { return m_CurrentBatteryTime; }
            set
            {
                if (value >= 0 && value <= m_MaxBatteryTime)
                {
                    m_CurrentBatteryTime = value;
                    EnergyPercentage = (m_CurrentBatteryTime / m_MaxBatteryTime) * 100;
                }
                else
                {
                    throw new ValueRangeException(0, m_MaxBatteryTime, "Current Battery Time");
                }
            }
        }
        public float MaxBatteryTime
        {
            get { return m_MaxBatteryTime; }
            protected set
            {
                if (value > 0)
                {
                    m_MaxBatteryTime = value;
                }
                else
                {
                    throw new ValueRangeException(0, float.MaxValue, "Max Battery Time");
                }
            }
        }
        public void ChargeBattery(float i_HoursToAdd)
        {
            if (i_HoursToAdd < 0 || m_CurrentBatteryTime + i_HoursToAdd > m_MaxBatteryTime)
            {
                throw new ValueRangeException(0, m_MaxBatteryTime - m_CurrentBatteryTime, "Hours to add");
            }
            CurrentBatteryTime += i_HoursToAdd;
        }
        public override string ToString()
        {
            return string.Format("{0}Current Battery Time: {1} hours\nMax Battery Time: {2} hours\n",
                base.ToString(),
                m_CurrentBatteryTime,
                m_MaxBatteryTime);
        }
    }
}
