using System;
using System.Collections.Generic;
using System.IO;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private List<GarageVehicle> m_GarageVehicles;

        public GarageUI()
        {
            m_GarageVehicles = new List<GarageVehicle>();
        }
        public List<GarageVehicle> GarageVehicle
        {
            get { return m_GarageVehicles; }
        }
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                //Console.Clear();
                Console.WriteLine("Welcome to the Garage Management System");
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. Load vehicles from file");
                Console.WriteLine("2. Insert new vehicle");
                Console.WriteLine("3. Show license plates (with filter)");
                Console.WriteLine("4. Change vehicle status");
                Console.WriteLine("5. Inflate wheels to max");
                Console.WriteLine("6. Refuel vehicle");
                Console.WriteLine("7. Recharge electric vehicle");
                Console.WriteLine("8. Show full vehicle data");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        LoadVehiclesFromFile();
                        break;
                    case "2":
                        InsertVehicle();
                        break;
                    case "3":
                        ShowLicenseNumbers();
                        break;
                    case "4":
                        ChangeVehicleStatus();
                        break;
                    case "5":
                        InflateWheels();
                        break;
                    case "6":
                        RefuelVehicle();
                        break;
                    case "7":
                        RechargeVehicle();
                        break;
                    case "8":
                        ShowVehicleData();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Error, try again");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //הצגת נתונים מלאים
        private void ShowVehicleData()
        {
            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine();
            foreach (GarageVehicle garageVehicle in m_GarageVehicles)
            {
                if (garageVehicle.Vehicle.LicenseNumber == licenseNumber)
                {
                    Console.WriteLine(garageVehicle.ToString());
                    return;
                }
            }
            Console.WriteLine("Vehicle not found in the garage.");
        }

        //טעינת רכב חשמלי
        private void RechargeVehicle()
        {
            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine();
            foreach (GarageVehicle garageVehicle in m_GarageVehicles)
            {
                if (garageVehicle.Vehicle.LicenseNumber == licenseNumber)
                {
                    if (garageVehicle.Vehicle is ElectricVehicle)
                    {
                        Console.Write("Enter amount of minuts to recharge: ");
                        string inputMin = Console.ReadLine();
                        float hoursToAdd = float.Parse(inputMin);
                        try
                        {
                            ((ElectricVehicle)garageVehicle.Vehicle).ChargeBattery(hoursToAdd);
                            Console.WriteLine("Vehicle recharged successfully");
                        }
                        catch (ValueRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("This vehicle is not electric");
                    }
                    return;
                }
            }
            Console.WriteLine("Vehicle not found in the garage.");
            Console.ReadKey();
        }

        //תדלוק רכב
        private void RefuelVehicle()
        {   
            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine();
            foreach (GarageVehicle garageVehicle in m_GarageVehicles)
            {
                if (garageVehicle.Vehicle.LicenseNumber == licenseNumber)
                {
                    if (garageVehicle.Vehicle is FuelVehicle)
                    {
                        Console.WriteLine("Etner fuel type: 1 for Octan95 2 for Octan96 3 Octan98 4 Soler");
                        eFuelType eFuelType;
                        switch (Console.ReadLine())
                        {
                            case "1":
                                eFuelType = eFuelType.Octan95;
                                break;
                            case "2":
                                eFuelType = eFuelType.Octan96;
                                break;
                            case "3":
                                eFuelType = eFuelType.Octan98;
                                break;
                            case "4":
                                eFuelType = eFuelType.Soler;
                                break;
                            default:
                                eFuelType = eFuelType.Octan95;
                                return;
                        }
                        Console.WriteLine("Enter amount of liters to refuel: ");
                        string inputLiters = Console.ReadLine();
                        float litersToAdd = float.Parse(inputLiters);
                        try
                        {
                            ((FuelVehicle)garageVehicle.Vehicle).Refuel(eFuelType ,litersToAdd);
                            Console.WriteLine("Vehicle refueled successfully");
                        }
                        catch (ValueRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("This vehicle is not fueled");
                    }
                    return;
                }
            }
            Console.WriteLine("Vehicle not found in the garage.");
            Console.ReadKey();
        }

        //ניפוח גלגלים
        private void InflateWheels()
        {
            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine();
            foreach (GarageVehicle garageVehicle in m_GarageVehicles)
            {
                if (garageVehicle.Vehicle.LicenseNumber == licenseNumber)
                {
                    foreach (Wheel wheel in garageVehicle.Vehicle.Wheels)
                    {
                        wheel.InflationTire(wheel.MaxAirPressure - wheel.CurrentAirPressure);
                    }
                    Console.WriteLine("Wheels inflated to max successfully");
                    return;
                }
            }
        }

        //שינוי סטטוס רכב
        private void ChangeVehicleStatus()
        {
            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine();
            foreach (GarageVehicle garageVehicle in m_GarageVehicles)
            {
                if (garageVehicle.Vehicle.LicenseNumber == licenseNumber)
                {
                    Console.WriteLine("Enter new status: 1 for InRepair, 2 for Repaired, 3 for Paid");
                    eStatus eStatus;
                    switch (Console.ReadLine())
                    {
                        case "1":
                            eStatus = eStatus.InRepair;
                            break;
                        case "2":
                            eStatus = eStatus.Repaired;
                            break;
                        case "3":
                            eStatus = eStatus.Paid;
                            break;
                        default:
                            return;
                    }
                    garageVehicle.VehicleStatus = eStatus;
                    Console.WriteLine("Vehicle status updated successfully");
                    return;
                }
            }
            Console.WriteLine("Vehicle not found in the garage.");
        }

        //הצגת מספרי רישוי
        private void ShowLicenseNumbers()
        {
            Console.WriteLine("Do you want to filter by status? 'y' or 'n'");
            string filterChoice = Console.ReadLine().ToLower();
            List<GarageVehicle> vehiclesToShow = new List<GarageVehicle>();
            if (filterChoice == "y")
            {
                Console.WriteLine("Enter status to filter by: 1 for InRepair, 2 for Repaired, 3 for Paid");
                eStatus eStatus;
                switch (Console.ReadLine())
                {
                    case "1":
                        eStatus = eStatus.InRepair;
                        break;
                    case "2":
                        eStatus = eStatus.Repaired;
                        break;
                    case "3":
                        eStatus = eStatus.Paid;
                        break;
                    default:
                        return;
                }
                foreach (GarageVehicle garageVehicle in m_GarageVehicles)
                {
                    if (garageVehicle.VehicleStatus == eStatus)
                    {
                        vehiclesToShow.Add(garageVehicle);
                    }
                }
            }
            else
            {
                vehiclesToShow = m_GarageVehicles;
            }
            Console.WriteLine("License Numbers:");
            foreach (GarageVehicle garageVehicle in vehiclesToShow)
            {
                Console.WriteLine(garageVehicle.Vehicle.LicenseNumber);
            }
        }

        //הוספת רכב חדש
        private void InsertVehicle()
        {
            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine();
            foreach (GarageVehicle garageVehicle in m_GarageVehicles)
            {
                if (garageVehicle.Vehicle.LicenseNumber == licenseNumber)
                {
                    Console.WriteLine("Vehicle already exists in the garage.");
                    garageVehicle.VehicleStatus = eStatus.InRepair;
                    return;
                }
            }
            Console.WriteLine("Choose vehicle type:");
            Console.WriteLine("1. Fuel Car");
            Console.WriteLine("2. Electric Car");
            Console.WriteLine("3. Fuel Motorcycle");
            Console.WriteLine("4. Electric Motorcycle");
            Console.WriteLine("5. Truck");
            string choice = Console.ReadLine();

            Console.Write("Enter model name: ");
            string modelName = Console.ReadLine();

            Vehicle newVehicle = null;

            switch (choice)
            {
                case "1":
                    newVehicle = VehicleCreator.CreateVehicle("FuelCar" ,licenseNumber ,modelName);
                    break;
                case "2":
                    newVehicle = VehicleCreator.CreateVehicle("ElectricCar", licenseNumber, modelName);
                    break;
                case "3":
                    newVehicle = VehicleCreator.CreateVehicle("FuelMotorcycle", licenseNumber, modelName);
                    break;
                case "4":
                    newVehicle = VehicleCreator.CreateVehicle("ElectricMotorcycle", licenseNumber, modelName);
                    break;
                case "5":
                    newVehicle = VehicleCreator.CreateVehicle("Truck", licenseNumber, modelName);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            Console.Write("Enter owner name: ");
            string ownerName = Console.ReadLine();
            Console.Write("Enter owner phone: ");
            string ownerPhone = Console.ReadLine();

            GarageVehicle newGarageVehicle = new GarageVehicle(newVehicle, ownerName, ownerPhone);
            m_GarageVehicles.Add(newGarageVehicle);

            Console.WriteLine("Vehicle inserted successfully.");
            Console.ReadKey();

        }

        //טעינת רכבים מקובץ
        private void LoadVehiclesFromFile()
        {
            string filePath = @"C:\Users\roish\Desktop\Ex03 Roi 212052047 Linoy 315378182\VehiclesDB.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return;
            }
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim() == "*****" || line.Trim().StartsWith("VehicleType"))
                {
                    continue;
                }
                string[] parts = line.Split(',');
                if (parts.Length < 8)
                {
                    continue;
                }

                string vehicleType = parts[0].Trim();
                string licenseNumber = parts[1].Trim();
                string modelName = parts[2].Trim();
                float energyPercentage = float.Parse(parts[3].Trim());
                string tireModel = parts[4].Trim();
                float currentAirPressure = float.Parse(parts[5].Trim());
                string ownerName = parts[6].Trim();
                string ownerPhone = parts[7].Trim();

                Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licenseNumber, modelName);
                if (newVehicle == null)
                {
                    Console.WriteLine($"Unsupported vehicle type: {vehicleType}");
                    continue;
                }

                foreach (Wheel wheel in newVehicle.Wheels)
                {
                    wheel.ManufacturerName = tireModel;
                    wheel.CurrentAirPressure = currentAirPressure;
                }

                newVehicle.EnergyPercentage = energyPercentage;

                GarageVehicle garageVehicle = new GarageVehicle(newVehicle, ownerName, ownerPhone);

                switch (vehicleType)
                {
                    case "FuelMotorcycle":
                        ((FuelMotorcycle)newVehicle).LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), parts[8].Trim());
                        ((FuelMotorcycle)newVehicle).EngineCapacity = int.Parse(parts[9].Trim());
                        break;

                    case "ElectricMotorcycle":
                        ((ElectricMotorcycle)newVehicle).LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), parts[8].Trim());
                        ((ElectricMotorcycle)newVehicle).EngineCapacity = int.Parse(parts[9].Trim());
                        break;

                    case "FuelCar":
                        ((FuelCar)newVehicle).CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), parts[8].Trim());
                        ((FuelCar)newVehicle).CarDoorNumber = (eCarDoorNumber)Enum.Parse(typeof(eCarDoorNumber), parts[9].Trim());
                        break;

                    case "ElectricCar":
                        ((ElectricCar)newVehicle).CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), parts[8].Trim());
                        ((ElectricCar)newVehicle).CarDoorNumber = (eCarDoorNumber)Enum.Parse(typeof(eCarDoorNumber), parts[9].Trim());
                        break;

                    case "Truck":
                        ((Truck)newVehicle).IsCarryingCoolingMaterials = bool.Parse(parts[8].Trim());
                        ((Truck)newVehicle).CargoVolume = float.Parse(parts[9].Trim());
                        break;
                }
                m_GarageVehicles.Add(garageVehicle);
            }
            Console.WriteLine("Vehicles loaded successfully from file.");
        }
    }
}