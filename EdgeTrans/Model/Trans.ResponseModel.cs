namespace EdgeTrans
{
    public static partial class Trans
    {
        internal class ResponseSuccessModel : List<ResponseModelElement>
        {
            public ResponseSuccessModel()
            {
            }

            public ResponseSuccessModel(IEnumerable<ResponseModelElement> collection) : base(collection)
            {
            }

            public ResponseSuccessModel(int capacity) : base(capacity)
            {
            }
        }
    }
}