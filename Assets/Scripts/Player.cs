using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    [SerializeField] public GameObject _Monster;
    [SerializeField] public GameObject _LooseScreen;

    public IEnumerator LooseScreen()
    {
        _LooseScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }

    public void Update()
    {
        if (_Monster.GetComponent<VampireAIController>().GetState() == StateType.Attack)
        {
            StartCoroutine(LooseScreen());
        }
    }
}
