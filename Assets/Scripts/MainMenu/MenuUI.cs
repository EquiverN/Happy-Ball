using UnityEngine;

public class MenuUI : MonoBehaviour
{
    
    [SerializeField] private GameObject optionsPanel;

    private void Awake()
    {
        optionsPanel.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

}