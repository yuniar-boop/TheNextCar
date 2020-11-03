using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccuBatteryController accuBatteryController;
        private OnCarEngineStateChanged callback;

        public Car(DoorController doorController, AccuBatteryController accuBatteryController, OnCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accuBatteryController = accuBatteryController;
            this.callback = callback;
        }

        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        private bool  powerIsReady()
        {
            return this.accuBatteryController.accubatteryIsOn();
        }

        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "close the door");
                return;
            }

            if (!doorIsLocked())
            {
                this.callback.onCarEngineStateChanged("STOPED", "lock the door");
                return;
            }

            if (!powerIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "no power available");
                return;
            }
            this.callback.onCarEngineStateChanged("STARTED", "Egine Started");
        }

        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            } 
            else
            {
                this.doorController.unlock();
            }
        }

        public void toggleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }

        public void togglePowerDoorButton()
        {
            if (!powerIsReady())
            {
                this.accuBatteryController.turnOn();
            }
            else
            {
                this.accuBatteryController.turnOff();
            }
        }
    }

    interface OnCarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }
}
