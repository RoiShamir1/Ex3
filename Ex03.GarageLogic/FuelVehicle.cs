using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;
        public FuelVehicle(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber ,i_ModelName)
        {
            m_CurrentFuelAmount = 0;
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }
        public float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }
            set
            {
                if (value >= 0 && value <= m_MaxFuelAmount)
                {
                    m_CurrentFuelAmount = value;
                    EnergyPercentage = (m_CurrentFuelAmount / m_MaxFuelAmount) * 100;
                }
                else
                {
                    throw new ValueRangeException(0, m_MaxFuelAmount, "Current Fuel Amount");
                }
            }
        }
        public float MaxFuelAmount
        {
            get { return m_MaxFuelAmount; }
            protected set
            {
                if (value > 0)
                {
                    m_MaxFuelAmount = value;
                }
                else
                {
                    throw new ValueRangeException(1, float.MaxValue, "Max Fuel Amount");
                }
            }
        }
        public void Refuel(eFuelType i_FuelType, float i_AmountToAdd)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException("Incorrect fuel type.");
            }
            if (i_AmountToAdd < 0 || m_CurrentFuelAmount + i_AmountToAdd > m_MaxFuelAmount)
            {
                throw new ValueRangeException(0, m_MaxFuelAmount - m_CurrentFuelAmount, "Amount to add");
            }
            CurrentFuelAmount += i_AmountToAdd;
        }

        public override string ToString()
        {
            return string.Format("{0}Fuel Type: {1}\nCurrent Fuel Amount: {2}L\nMax Fuel Amount: {3}L\n",
                base.ToString(),
                m_FuelType.ToString(),
                m_CurrentFuelAmount,
                m_MaxFuelAmount);
        }
    }
}
