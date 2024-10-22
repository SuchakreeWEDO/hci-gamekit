using System;
using UniRx;
using UnityEngine;

public static class Obs {
	public static IDisposable Interval(this MonoBehaviour obj, float sec, Action observer) {
		return Observable.Interval(TimeSpan.FromSeconds(sec)).Subscribe((_) => observer()).AddTo(obj);
	}
}