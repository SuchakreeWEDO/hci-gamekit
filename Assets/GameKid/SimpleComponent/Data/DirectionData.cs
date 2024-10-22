using UnityEngine;

public class DirectionData : CustomData<Vector3>
{
	public override void Add(Vector3 value)
	{
		data += value;
	}
	public override void Sub(Vector3 value)
	{
		data -= value;
	}

	public override void Divide(Vector3 value)
	{
	}

	public override void Muliply(Vector3 value)
	{
	}

    public override string ToText()
    {
		return data.ToString();
    }
}