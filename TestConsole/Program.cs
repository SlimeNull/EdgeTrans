using EdgeTrans;
using System.Globalization;

while (true)
{
    var input = Console.ReadLine();
    if (input == null)
        return;

    var rst = await Trans.GoAsync(input, new CultureInfo("qwq"));
    Console.WriteLine(rst.DefaultTranslation);
}