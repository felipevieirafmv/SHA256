using System.Text;

Encode("aaa");

uint[] GenerateChunk(string input)
{
    byte[] bytes = Encoding.UTF8.GetBytes(input);
    string resultString = "";
    int size = 0;
    foreach (var item in bytes)
    {
        resultString += Convert.ToString(item, 2).PadLeft(8, '0');
    }
    size = resultString.Length;
    resultString += '1';
    for(int i=0; i<448-size-1; i++)
    {
        resultString += '0';
    }
    resultString += Convert.ToString(size, 2).PadLeft(64, '0');

    uint[] resultMatrix = new uint[16];

    for(int i=0; i<16; i++)
    {
        string oneByte = resultString.Substring(i*32, 32);
        resultMatrix[i] = Convert.ToUInt32(oneByte, 2);
    }

    return resultMatrix;
}

uint RotateRight(uint value, int count)
{
    return (value >> count) | (value << (32 - count));
}

void Calculate(uint[] chunk)
{
    uint[] allChunks = new uint[64];
    Array.Copy(chunk, allChunks, 16);

    for(int i = 0; i<48; i++)
    {
        uint w1 = allChunks[i+1];
        uint sigma0temp1 = RotateRight(w1, 7);
        uint sigma0temp2 = RotateRight(w1, 18);
        uint sigma0temp3 = w1 >> 3;
        uint sigma0 = sigma0temp1 ^ sigma0temp2 ^ sigma0temp3;
        
        uint w14 = allChunks[i+14];
        uint sigma1temp1 = RotateRight(w14, 17);
        uint sigma1temp2 = RotateRight(w14, 19);
        uint sigma1temp3 = w14 >> 10;
        uint sigma1 = sigma1temp1 ^ sigma1temp2 ^ sigma1temp3;

        allChunks[i+16] = allChunks[i] + sigma0 + allChunks[i+9] + sigma1;

        System.Console.WriteLine(Convert.ToString(allChunks[i+16], 2).PadLeft(32, '0'));
    }
}

void Encode(string input)
{
    uint[] chunk = GenerateChunk(input);
    Calculate(chunk);
}
