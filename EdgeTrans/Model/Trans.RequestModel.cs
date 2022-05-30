namespace EdgeTrans
{
    public static partial class Trans
    {
        internal class RequestModel : List<RequestModelElement>
        {
            public RequestModel()
            {
            }

            public RequestModel(IEnumerable<RequestModelElement> collection) : base(collection)
            {
            }

            public RequestModel(int capacity) : base(capacity)
            {
            }

            public RequestModel(string[] texts) : base(texts.Length)
            {
                foreach (var text in texts)
                {
                    Add(new RequestModelElement(text));
                }
            }
        }
    }
}