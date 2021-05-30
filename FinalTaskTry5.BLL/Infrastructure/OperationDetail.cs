namespace FinalTaskTry5.BLL.Infrastructure
{
    /// <summary>
    /// OperationDetail class
    /// </summary>
    public class OperationDetail
    {
        public OperationDetail(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
        /// <summary>
        /// Succedeed
        /// </summary>
        public bool Succedeed { get; private set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Property
        /// </summary>
        public string Property { get; private set; }
    }
}
