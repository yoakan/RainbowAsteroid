using UnityEngine;
using UnityEngine.UI;

public class ShipElementUI : MonoBehaviour
{
    [SerializeField]
    private Text addText;
    [SerializeField]
    private Text removeText;
    [SerializeField]
    private Text lifeText;

    [SerializeField] private Image image;

    private bool exisTShip = false;

    public void addStatShip(int life,Color color)
    {
        exisTShip = true;
        addText.gameObject.SetActive(false);
        lifeText.gameObject.SetActive(true);
        lifeText.color = color;
        removeText.color = color;
        image.color = color;
        lifeText.text = "" + life;
    }
    public void restart()
    {
        exisTShip = true;
        addText.gameObject.SetActive(false);
        lifeText.gameObject.SetActive(true);
        lifeText.color = Color.white;
        removeText.color = Color.white;
        image.color = Color.white;
        lifeText.text = "" ;
    }

    public void overrideUI(bool upMouse)
    {
        changeText(upMouse);
    }

    private void changeText(bool activeRemove)
    {
        if (exisTShip)
        {
            lifeText.gameObject.SetActive(!activeRemove);
        }
        else
        {
            addText.gameObject.SetActive(!activeRemove);
        }
        
        removeText.gameObject.SetActive(activeRemove);
    }

    public void onClick()
    {
        
        GameManager.Instance.PlayerManager.ShipUI.changeColor(this);
    }
}
