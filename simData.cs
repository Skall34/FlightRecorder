using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSUIPC;
using Microsoft.VisualBasic.ApplicationServices;

namespace FlightRecorder
{
    internal class simData
    {
        // =====================================
        // DECLARE OFFSETS YOU WANT TO USE HERE
        // =====================================
        //https://www.projectmagenta.com/all-fsuipc-offsets/
        private Offset<uint> airspeed = new Offset<uint>(0x02BC);
        private Offset<string> startSituation = new Offset<string>(0x0024, 256);
        private Offset<uint> avionicsMaster = new Offset<uint>(0x2E80);
        //private Offset<byte> navLights = new Offset<byte>(0x0280);
        //private Offset<byte> beaconStrobe = new Offset<byte>(0x0281);
        //private Offset<byte> landingLights = new Offset<byte>(0x02BC);

        //30C Vertical speed, copy of offset 02C8 whilst airborne, not updated
        //whilst the “on ground” flag(0366) is set.Can be used to check
        //hardness of touchdown(but watch out for bounces which may
        //change this). 
        private Offset<short> onGround = new Offset<short>(0x0366);
        private Offset<int> verticalSpeed = new Offset<int>(0x02C8);
        private Offset<int> landingVerticalSpeed = new Offset<int>(0x30C);

        private Offset<byte> stallWarning = new Offset<byte>(0x036C);
        private Offset<byte> overSpeedWarning = new Offset<byte>(0x036D);
        private Offset<short> crashed = new Offset<short>(0x0840);
        private Offset<short> offRunwayCrashed = new Offset<short>(0x0848);

        private Offset<uint> flapsAvailable = new Offset<uint>(0x778);
        private Offset<uint> flapsPosition = new Offset<uint>(0xBE0);

        private Offset<uint> gearRetractableFlag = new Offset<uint>(0x60C);
        private Offset<uint> gearPosition = new Offset<uint>(0xBF0);



        //private Offset<long> altitude = new Offset<long>(0x0570);
        //private Offset<uint> pitch = new Offset<uint>(0x0578);
        //private Offset<uint> bank = new Offset<uint>(0x057C);
        //private Offset<uint> heading = new Offset<uint>(0x0580);


        private Offset<short> engineNumber = new Offset<short>(0x0AEC);

        private Offset<short> engine1Firing = new Offset<short>(0x0894);
        private Offset<short> engine2Firing = new Offset<short>(0x092C);
        private Offset<short> engine3Firing = new Offset<short>(0x09C4);
        private Offset<short> engine4Firing = new Offset<short>(0x0A5C);

        private Offset<short> fuelWheight = new Offset<short>(0x0AF4); //pounds per gallons * 256

        private Offset<uint> centerTankLevelPercent = new Offset<uint>(0x0B74); // % * 128 * 65536
        private Offset<uint> centerTankGallonsCapacity = new Offset<uint>(0x0B78);

        private Offset<uint> leftTankLevelPercent = new Offset<uint>(0x0B7C); // % * 128 * 65536
        private Offset<uint> leftTankGallonsCapacity = new Offset<uint>(0x0B80);

        private Offset<uint> rightTankLevelPercent = new Offset<uint>(0x0B94); // % * 128 * 65536
        private Offset<uint> rightTankGallonsCapacity = new Offset<uint>(0x0B98);

        private Offset<uint> payloadNumber = new Offset<uint>(0x13FC);
        //private Offset<FsPayloadStation> payloads = new Offset<FsPayloadStation>(0x1400, 48);

        private Offset<string> aircraftModel = new Offset<string>(0x3500, 24);

        private Offset<string> aircraftType = new Offset<string>(0x3D00, 256);
        private Offset<string> flightNumber = new Offset<string>(0x3130, 12);
        private Offset<string> tailNumber = new Offset<string>(0x313C, 12);
        private Offset<string> airlineName = new Offset<string>(0x3148, 24);

        private PayloadServices? payloadServices;
        private PlayerLocationInfo locationInfos = new PlayerLocationInfo();

        //private Offset<short> parkingBrake = new Offset<short>(0x0BC8);
        //FsPositionSnapshot _startPosition;
        //FsPositionSnapshot _endPosition;

        //private bool atLeastOneEngineFiring;

        private bool _isConnected;
        public bool isConnected { get {
                return _isConnected;
            }
            set {
                _isConnected = value;
            }
        }


        public simData()
        {
            _isConnected = false;
        }

        public void openConnection()
        {
            FSUIPCConnection.Open();
            _isConnected = true;
            payloadServices = FSUIPCConnection.PayloadServices;
            FSUIPCConnection.Process();
            payloadServices.RefreshData();
        }

        public void refresh()
        {
            try
            {
                FSUIPCConnection.Process();
                if (null != payloadServices)
                {
                    payloadServices.RefreshData();
                }
            }catch(Exception)
            {
                _isConnected=false;
            }
        }

        public double getFuelWeight()
        {
            double result = 0;
            if (null != payloadServices)
            {
                result = payloadServices.FuelWeightKgs;
            }
            return result;
        }

        public double getPlaneWeight()
        {
            double result = 0;
            if (null != payloadServices)
            {
                result = payloadServices.GrossWeightKgs;
            }
            return result;
        }

        public void setPayload(double newWheight)
        {
            if (null != payloadServices)
            {
                List<FsPayloadStation> stations = payloadServices.PayloadStations;
                double currentPayload = payloadServices.PayloadWeightKgs;

                int nbPayloads = payloadServices.PayloadStations.Count;
                foreach (FsPayloadStation s in stations)
                {
                    //compute the % of this payload regarding the rest : 
                    double percent = s.WeightKgs / currentPayload;
                    s.WeightKgs = percent * newWheight;
                }
                payloadServices.WriteChanges();
            }
        }

        public void setFuelWheight(double newFuelWeight)
        {
            if (null != payloadServices)
            {
                payloadServices.LoadFuelKgs(newFuelWeight, true);
                payloadServices.WriteChanges();
            }
        }

        public double getMaxFuel()
        {
            if (null != payloadServices)
            {
                return payloadServices.FuelCapacityKgs;
            }
            else
            {
                return 0;
            }
        }

        public short getOnground() => onGround.Value;

        public Double getCargoWeight()
        {
            double result = 0;
            if (null != payloadServices)
            {
                result = payloadServices.PayloadWeightKgs;
            }
            return result;
        }

        public double getAirSpeed() => (double)this.airspeed.Value / 128d;

        public double getVerticalSpeed() => ((double)verticalSpeed.Value/256 ) * 60 * 3.28084;

        public double getLandingVerticalSpeed() => ((double)landingVerticalSpeed.Value/256) * 60 * 3.28084;

        public byte getStallWarning() => stallWarning.Value;

        public byte getOverspeedWarning() => overSpeedWarning.Value;

        public short getCrashedFlag() => crashed.Value;

        public short getOffRunwayCrashed() => offRunwayCrashed.Value;

        public uint getGearRetractableFlag() => gearRetractableFlag.Value;

        public bool getIsGearUp() =>
            // gear down = 16383
            gearPosition.Value == 0;

        public uint getFlapsAvailableFlag() => flapsAvailable.Value;

        public uint getFlapsPosition() => flapsPosition.Value;

        public bool isAtLeastOneEngineFiring()
        {
            bool result = false;
            switch (this.engineNumber.Value)
            {
                case (1):
                    {
                        result = (engine1Firing.Value == 1);
                    }; break;
                case (2):
                    {
                        result = (engine1Firing.Value == 1) ||
                                                 (engine2Firing.Value == 1);
                    }; break;
                case (3):
                    {
                        result = (engine1Firing.Value == 1) ||
                                                 (engine2Firing.Value == 1) ||
                                                 (engine3Firing.Value == 1);
                    }; break;
                case (4):
                    {
                        result = (engine1Firing.Value == 1) ||
                                                 (engine2Firing.Value == 1) ||
                                                 (engine3Firing.Value == 1) ||
                                                 (engine4Firing.Value == 1);
                    }; break;
            }
            return result;
        }

        public FsPositionSnapshot getPosition() => FSUIPCConnection.GetPositionSnapshot();

        public string getAircraftType() => aircraftType.Value;
        public string getAircraftModel() => aircraftModel.Value;

        public string getFlightNumber() => flightNumber.Value;


        public string getTailNumber() => tailNumber.Value;

        public double getPayloadWheight()
        {
            if (payloadServices != null)
            {
                return payloadServices.PayloadWeightKgs;
            }
            else
            {
                return 0;
            }
        }


    }
}
