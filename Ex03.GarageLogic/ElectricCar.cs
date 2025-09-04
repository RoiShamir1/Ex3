namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private eCarColor m_CarColor;
        private eCarDoorNumber m_CarDoorNumber;
        public ElectricCar(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
            for (int i = 0; i < 5; i++)
            {
                Wheels.Add(new Wheel("CarWheel", 33f));
            }
            MaxBatteryTime = 5.2f;
        }
        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }
        public eCarDoorNumber CarDoorNumber
        {
            get { return m_CarDoorNumber; }
            set { m_CarDoorNumber = value; }
        }
        public override string ToString()
        {
            return string.Format("{0}Car Color: {1}\nNumber of Doors: {2}\n",
                base.ToString(),
                m_CarColor.ToString(),
                (int)m_CarDoorNumber);
        }
    }
}