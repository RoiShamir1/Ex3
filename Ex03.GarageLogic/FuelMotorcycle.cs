namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : FuelVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        public FuelMotorcycle(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber ,i_ModelName)
        {
            for (int i = 0; i < 2; i++)
            {
                Wheels.Add(new Wheel("MotorcycleWheel", 29f));
            }
            FuelType = eFuelType.Octan98;
            MaxFuelAmount = 6.5f;
        }
        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }
        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set
            {
                if (value >= 0)
                {
                    m_EngineCapacity = value;
                }
                else
                {
                    throw new ValueRangeException(1, int.MaxValue, "Engine Capacity");
                }
            }
        }
        public override string ToString()
        {
            return string.Format("{0}License Type: {1}\nEngine Capacity: {2}cc\n",
                base.ToString(),
                m_LicenseType.ToString(),
                m_EngineCapacity);
        }
    }
}