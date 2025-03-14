using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Notebook UI")]
    [SerializeField] private GameObject notebookUI;
    [SerializeField] private TextMeshProUGUI notebookText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowNotebookPage(string treeType)
    {
        notebookUI.SetActive(true);
        notebookText.text = $"Type d'arbre : {treeType}\n\nCet arbre semble robuste et intéressant.";
    }

    public void CloseNotebook()
    {
        notebookUI.SetActive(false);
    }
}
