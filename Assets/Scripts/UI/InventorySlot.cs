using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Item item;
    public float WaitInfo;

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.001f);
        if (item.weapon != null)
            switch (item.weapon.Element)
            {
                case 0:
                    transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                    break;
                case 1:
                    transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 0.282353f, 0.1921569f);
                    break;
                case 2:
                    transform.GetChild(0).GetComponent<Image>().color = new Color(0.3176471f, 0.9607843f, 0.9607843f);
                    break;
                case 3:
                    transform.GetChild(0).GetComponent<Image>().color = new Color(0.145098f, 0.7843137f, 0.1137255f);
                    break;
                case 4:
                    transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 0);
                    break;
                case 5:
                    transform.GetChild(0).GetComponent<Image>().color = new Color(0.9215686f, 1f, 0.4941176f);
                    break;
                case 6:
                    transform.GetChild(0).GetComponent<Image>().color = new Color(0.7294118f, 0.05882353f, 0.4862745f);
                    break;
            }
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(item.sprite);
    }
    public void Start()
    {
        StartCoroutine(Timer());
    }
    public void Click()
    {
        if (CharacterWindow.isEquipment && item.weapon != null)
        {
            if (item.weapon.type == 0)
            {
                if (CharacterWindow.ch.Equipment[0] == null)
                {
                    CharacterWindow.ch.Equipment[0] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();
                }
                else if (CharacterWindow.ch.Equipment[1] == null)
                {
                    if (!CharacterWindow.ch.Equipment[0].DoubleWeapon)
                    {
                        CharacterWindow.ch.Equipment[1] = item.weapon;
                        StartGame.game.Inventory.Remove(item);
                        Destroy(gameObject);
                        CharacterWindow.ch.UpdateCharacteristic();

                    }
                    else { print("У вас заняты оба слота"); }
                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 1)
            {
                if (CharacterWindow.ch.Equipment[0] == null)
                {
                    CharacterWindow.ch.Equipment[0] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 2)
            {
                if (CharacterWindow.ch.Equipment[2] == null)
                {
                    CharacterWindow.ch.Equipment[2] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 3)
            {
                if (CharacterWindow.ch.Equipment[3] == null)
                {
                    CharacterWindow.ch.Equipment[3] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 4)
            {
                if (CharacterWindow.ch.Equipment[4] == null)
                {
                    CharacterWindow.ch.Equipment[4] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 5)
            {
                if (CharacterWindow.ch.Equipment[5] == null)
                {
                    CharacterWindow.ch.Equipment[5] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 6)
            {
                if (CharacterWindow.ch.Equipment[6] == null)
                {
                    CharacterWindow.ch.Equipment[6] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 7)
            {
                if (CharacterWindow.ch.Equipment[7] == null)
                {
                    CharacterWindow.ch.Equipment[7] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 8)
            {
                if (CharacterWindow.ch.Equipment[8] == null)
                {
                    CharacterWindow.ch.Equipment[8] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else { print("Слоты заняты"); }
            }


            else if (item.weapon.type == 9)
            {
                if (CharacterWindow.ch.Equipment[9] == null)
                {
                    CharacterWindow.ch.Equipment[9] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                    CharacterWindow.ch.UpdateCharacteristic();

                }
                else if (CharacterWindow.ch.Equipment[10] == null)
                {
                    CharacterWindow.ch.Equipment[10] = item.weapon;
                    StartGame.game.Inventory.Remove(item);
                    Destroy(gameObject);
                }
                else { print("Слоты заняты"); }
            }
        }
    }
    bool isPressed=false;
    public void OnPointerDown(PointerEventData eventData)

    {
        isPressed = true;
        StartCoroutine(InvW());
    }
    public void OnPointerUp(PointerEventData eventData)

    {
        isPressed = false;
        InventoryWindow.Info.SetActive(false);
    }

    IEnumerator InvW()
    {
        yield return new WaitForSeconds(WaitInfo);
        if (isPressed)
        {
            InventoryWindow.Info.SetActive(true);
            InventoryWindow.Info.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = item.weapon.Name;
            if (item.weapon.type == 0 || item.weapon.type == 1)
                InventoryWindow.Info.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Урон: " + item.weapon.MIN_Damage.ToString() + "-" + item.weapon.MAX_Damage.ToString() + "\nЭлемент: " + item.weapon.ElementName;
            else
                InventoryWindow.Info.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Элемент: " + item.weapon.ElementName;


            InventoryWindow.Info.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "Тип: " + item.weapon.typeName + "\nСтоимость: " + item.weapon.cost.ToString();

            if (!CharacterWindow.isEquipment)
            { 
                InventoryWindow.Info.transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = Resources.Load<Sprite>(item.sprite);
                if(item.weapon!=null)
                switch (item.weapon.Element)
                {
                    case 0:
                            InventoryWindow.Info.transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                        break;
                    case 1:
                            InventoryWindow.Info.transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color(1f, 0.282353f, 0.1921569f);
                        break;
                    case 2:
                            InventoryWindow.Info.transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color(0.3176471f, 0.9607843f, 0.9607843f);
                        break;
                    case 3:
                            InventoryWindow.Info.transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color(0.145098f, 0.7843137f, 0.1137255f);
                        break;
                    case 4:
                            InventoryWindow.Info.transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color(1f, 1f, 0);
                        break;
                    case 5:
                            InventoryWindow.Info.transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color(0.9215686f, 1f, 0.4941176f);
                        break;
                    case 6:
                            InventoryWindow.Info.transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color(0.7294118f, 0.05882353f, 0.4862745f);
                        break;
                }
            }
            isPressed = false;
        }
    }
}
