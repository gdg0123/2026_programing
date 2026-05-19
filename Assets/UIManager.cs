using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Toggle bgmToggle;
    public Toggle fxToggle;

    public Slider bgmSlider;
    public Slider fxSlider;

    public Button openButton;
    public Button exitButton;

    public GameObject optionPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmToggle.onValueChanged.AddListener(SoundManager.instance.OnOffBGM);
        fxToggle.onValueChanged.AddListener(SoundManager.instance.OnOffFx);

        bgmSlider.onValueChanged.AddListener(SoundManager.instance.ChangeBGMVolume);
        fxSlider.onValueChanged.AddListener(SoundManager.instance.ChangeFxVolume);

        openButton.onClick.AddListener(OpenPanel);
        exitButton.onClick.AddListener(ClosePanel);
    }

    private void OpenPanel()
    {
        optionPanel.SetActive(true);
    }

    private void ClosePanel()
    {
        optionPanel.SetActive(false);
    }
}
