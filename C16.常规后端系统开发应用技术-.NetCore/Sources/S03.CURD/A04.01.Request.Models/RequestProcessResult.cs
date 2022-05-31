namespace DataCURD.A04._01.Request.Models
{
    /// <summary>
    /// 请求数据对象处理结果
    /// </summary>
    public class RequestProcessResult
    {
        public bool Success { get; set; }     // 处理结果状态
        public string? Message { get; set; }  // 处理结果消息
        public object? Result { get; set; }   // 处理好的数据，根据实际情况使用
    }
}
