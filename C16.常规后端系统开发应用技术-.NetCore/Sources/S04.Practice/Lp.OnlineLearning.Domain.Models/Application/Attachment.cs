namespace Lp.OnlineLearning.Domain.Models.Application
{
    /// <summary>
    /// 承载上传材料的记录器
    ///   Name 上传的文件名
    /// </summary>
    public class Attachment : DomainModel
    {
        /// <summary>
        /// 关联的数据对象的Id
        /// </summary>
        public Guid ObjectId { get; set; }
        /// <summary>
        /// 上传的文件后缀名
        /// </summary>
        public string? FileSuffix { get; set; }
        /// <summary>
        /// 附件的路径
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// 上传的时间
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        public Attachment()
        {
            Id= Guid.NewGuid();
        }
    }
}
