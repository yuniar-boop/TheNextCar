namespace TheNextCar.Model
{
    class AccuBattery
    {
        private int voltage;
        private bool stateOn = false;

        public AccuBattery(int voltage)
        {
            this.voltage = voltage;
        }
        public void turnOn()
        {
            this.stateOn = true;
        }
        public void turnOff()
        {
            this.stateOn = false;
        }
        public bool isOn()
        {
            return this.stateOn;
        }
    }
}
