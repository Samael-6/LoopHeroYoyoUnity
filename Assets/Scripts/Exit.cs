using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _Player)
        {
            GetComponent<SceneLoader>().isActive = true;
            GetComponent<SceneLoader>().LoadNewScene();
        }
    }
}
