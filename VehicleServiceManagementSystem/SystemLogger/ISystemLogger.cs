namespace VehicleServiceManagementSystem.SystemLogger
{
    public interface ISystemLogger
    {
        public void Exception(Exception exception);
        public void Information(string source, string description, Exception exc);
        public void Warning(string source, string description, Exception exc);
        public void Error(string source, string description, Exception exc);
    }
}