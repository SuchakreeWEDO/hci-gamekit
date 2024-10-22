public class TextData : CustomData<float>
{
    public override void Add(float value)
    {
        data += value;
    }

    public override void Divide(float value)
    {
        data /= value;
    }

    public override void Muliply(float value)
    {
        data *= value;
    }

    public override void Sub(float value)
    {
        data -= value;
    }

    public override string ToText()
    {
        return data.ToString();
    }
}