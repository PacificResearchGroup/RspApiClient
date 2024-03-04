namespace PRG.Clients.RSP.Dtos
{
    public class ResponseDto
    {
        public string Message { get; set; }
    }

    public class ResponseDto<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
