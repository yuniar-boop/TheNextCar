using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccuBatteryController
    {
        private AccuBattery accubattery;
        private OnPowerChanged callbackOnPowerChanged;

        public AccuBatteryController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accubattery = new AccuBattery(12);
        }

        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callbackOnPowerChanged.onPowerChangedStatus("ON", "power is on");
        }

        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callbackOnPowerChanged.onPowerChangedStatus("OFF", "power is off");
        }

        public bool accubatteryIsOn()
        {
            return this.accubattery.isOn();
        }
    }

    interface OnPowerChanged
    {
        void onPowerChangedStatus(String value, string message);
    }
}
