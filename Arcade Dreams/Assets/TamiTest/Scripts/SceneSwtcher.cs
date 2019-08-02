using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoLivingRoomScene()
    {
        SceneManager.LoadScene("ApartmentInterior");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}