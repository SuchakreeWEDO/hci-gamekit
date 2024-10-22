using UnityEngine;
using UnityEngine.Events;

public class ObjectEvent : MonoBehaviour
{
    public UnityEvent onStart;
    public UnityEvent onUpdate;
    void Start()
    {
        onStart?.Invoke();
    }

    void Update()
    {
        onUpdate?.Invoke();
    }
}
