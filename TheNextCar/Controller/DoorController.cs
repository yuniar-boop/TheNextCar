using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callbackOnDoorChanged;

        public DoorController(OnDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }

        public void close()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "door closed");
        }

        public void open()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPENED", "door opened");
        }

        public void  activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("LOCKED", "door locked");
        }

        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("UNLOCK", "door unlocked");
        }

        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }

        
    }

    interface OnDoorChanged
    {
        void onLockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
}
