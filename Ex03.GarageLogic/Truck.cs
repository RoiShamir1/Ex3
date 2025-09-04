using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : FuelCar
    {
        private bool m_IsCarryingCoolingMaterials;
        private float m_CargoVolume;
        public Truck(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
            for (int i = 0; i < 16; i++)
            {
                Wheels.Add(new Wheel("TruckWheel", 28f));
            }
            FuelType = eFuelType.Soler;
            MaxFuelAmount = 140f;
        }
        public bool IsCarryingCoolingMaterials
        {
            get { return m_IsCarryingCoolingMaterials; }
            set { m_IsCarryingCoolingMaterials = value; }
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set
            {
                if (value >= 0)
                {
                    m_CargoVolume = value;
                }
                else
                {
                    throw new ValueRangeException(0, float.MaxValue, "Cargo Volume");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0}Is Carrying Cooling Materials: {1}\nCargo Volume: {2}\n",
                base.ToString(),
                m_IsCarryingCoolingMaterials ? "Yes" : "No",
                m_CargoVolume);
        }
    }
}