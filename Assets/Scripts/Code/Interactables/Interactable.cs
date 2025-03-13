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

    public virtual void OnInteractStart(GameObject player)
    {
        StartCoroutine(BeginInteractDelay(player));
    }

    private IEnumerator BeginInteractDelay(GameObject player)
    {
        isInteracting = true;
        holdTime = 0f;
        _ProgressBar.gameObject.SetActive(true);

        while (holdTime < interactionDuration)
        {
            if (!isInteracting)
            {
                _ProgressBar.fillAmount = 0;
                _ProgressBar.gameObject.SetActive(false);
                yield break;
            }
            _ProgressBar.rectTransform.position = Input.mousePosition;
            holdTime += Time.deltaTime;
            _ProgressBar.fillAmount = holdTime / interactionDuration;
            yield return null;
        }

        OnInteract(player);
        _interactionName.text = "";
        CancelInteraction();
    }

    public void CancelInteraction()
    {
        _ProgressBar.gameObject.SetActive(false);
        isInteracting = false;
    }

    public abstract void OnInteract(GameObject player);
}
