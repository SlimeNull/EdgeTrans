namespace EdgeTrans
{
    public static partial class Trans
    {
        internal class RequestModelElement
        {
            public string Text { get; set; }

            public RequestModelElement(string text) => Text = text;
        }
    }
}