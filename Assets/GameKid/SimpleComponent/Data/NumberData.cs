public class NumberData : CustomData<float>
{
    public bool clamp = false;
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
        return clamp ? data.ToString().Split(".")[0] : data.ToString();
    }
}