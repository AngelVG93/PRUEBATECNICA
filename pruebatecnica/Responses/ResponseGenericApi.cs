namespace pruebatecnica.Responses
{
    public class ResponseGenericApi<T>
    {
        public T Data { get; set; }

        public ResponseGenericApi(T data)
        {
            Data = data;
        }
    }
}
