using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalAction : MonoBehaviour
{
    public void DestroyAllObjectsWithTag(string tag) {
        var targets = GameObject.FindGameObjectsWithTag(tag);
        foreach (var target in targets)
        {
            Destroy(target);
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
