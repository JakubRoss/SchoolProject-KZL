namespace School.Application
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() { }
        public ResourceNotFoundException(string? message) : base(message)
        {
        }
    }
}