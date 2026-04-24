using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Pawn _pawn;

    public void LoadNewScene()
    {
        if (_pawn != null)
        {
            Debug.Log("Ajout de 1 au numéro de cellule du joueur.");
            _pawn._playerData._cellNumber += 1;
            _pawn._saveManager.SaveGame();
            Debug.Log("Nouveau numéro de cellule du joueur : " + _pawn._playerData._cellNumber);
        }
        SceneManager.LoadScene(sceneName);
    }
}