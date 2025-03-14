using System;
using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private string interactionName;
    [SerializeField] private float interactionDuration = 3f;
    
    private TextMeshProUGUI _interactionName;
    private Image _ProgressBar;
    
    private bool isInteracting = false;
    private float holdTime = 0f;

    private void Start()
    {
        _interactionName = GameObject.FindWithTag("InteractionName").GetComponent<TextMeshProUGUI>();
        _ProgressBar = GameObject.FindWithTag("ProgressBar").GetComponent<Image>();
    }
    
    public void OnHover(GameObject player)
    {
        _interactionName.rectTransform.position = Input.mousePosition + new Vector3(0.0f, 10.0f, 0.0f);
        _interactionName.text = interactionName;
    }

    public void OnLeaverHover()
    {
        _interactionName.text = "";
    }

    public void OnInteractStart(PlayerMovement player)
    {
    player.Move(transform.position, () =>
    {
        if (CurrentTool != null)
        {
            if (CurrentTool.toolCategory == ToolCategory.Axe)
            {
                print("Abattage de l'arbre...");
                StartCoroutine(BeginInteractDelay(3f, OnInteract));
            }
            else if (CurrentTool.toolCategory == ToolCategory.Notebook)
            {
                print("Prise de note...");
                StartCoroutine(BeginInteractDelay(10f, OnNoteTaken)); 
            }
        }
    });
}

private IEnumerator BeginInteractDelay(float duration, Action onComplete)
{
    isInteracting = true;
    holdTime = 0f;
    _ProgressBar.gameObject.SetActive(true);

    while (holdTime < duration)
    {
        if (!isInteracting)
        {
            _ProgressBar.fillAmount = 0;
            _ProgressBar.gameObject.SetActive(false);
            yield break;
        }
        _ProgressBar.rectTransform.position = Input.mousePosition;
        holdTime += Time.deltaTime;
        _ProgressBar.fillAmount = holdTime / duration;
        yield return null;
    }

    onComplete();
    CancelInteraction();
}

protected virtual void OnNoteTaken()
{
    Debug.Log("Note prise !");
}


    public void CancelInteraction()
    {
        _ProgressBar.gameObject.SetActive(false);
        isInteracting = false;
    }

    public abstract void OnInteract(GameObject player);
}
