using UnityEngine;
public abstract class CustomData<T>: GameKitObject{
    public string key;
    public T data;

    public void Set(T data) {
        this.data = data;
    }

    public T Get() {
        return data;
    }
    public abstract void Add(T value); 
    public abstract void Sub(T value); 
    public abstract void Muliply(T value); 
    public abstract void Divide(T value); 
    public abstract string ToText();

    public static void SetFromKey(string key) {}
    public static T GetFromKey(string key) {
        return FindAnyObjectByType<CustomData<T>>().Get() ?? default;
    }
}

