using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemStack : MonoBehaviour
{
 
    private Image _icon;
    private TextMeshProUGUI _textCount;
    
    [SerializeField] private Resource resource;
    [SerializeField] private uint amount;

    public Resource Resource
    {
        get => resource;
        set
        {
            resource = value;
            _icon.sprite = value.resourceSprite;
        }
    }

    public uint Amount
    {
        get => amount;
        set
        {
            amount = value;
            _textCount.text = amount.ToString();
        }
    }

    private void Awake()
    {
        _icon = GetComponentInChildren<Image>();
        _textCount = GetComponentInChildren<TextMeshProUGUI>();
    }
}
