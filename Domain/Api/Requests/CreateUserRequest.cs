namespace Api.Requests
{
    public class CreateUserRequest
    {
        public string NativeUserName { get; set; }

        public string Provider { get; set; }

        public string ProviderUserName { get; set; }

        public string UserFullName { get; set; }
    }
}
