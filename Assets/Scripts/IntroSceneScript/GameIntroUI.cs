using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class GameIntroUI : MonoBehaviour
{
    private UIDocument _document;

    private Button _button;
    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("PlayButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnPlayClick);
    }

    private void OnPlayClick(ClickEvent evt)
    {
        SceneManager.LoadScene("MainLobby");

        
    }
}
