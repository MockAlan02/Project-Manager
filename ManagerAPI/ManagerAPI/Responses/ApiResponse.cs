﻿namespace ManagerAPI.Responses
{
    public class ApiResponse<T>(T data)
    {
        public T Data { get; set; } = data;
    }

}
