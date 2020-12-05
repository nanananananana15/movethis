using UnityEngine;

public class WeaponDialog : MonoBehaviour
{
    [SerializeField] private int buttonNumber = 15;
    [SerializeField] private ItemButton itemButton;

    private ItemButton[] _itemButtons;

    private void Start()
    {
        // 初期状態は非表示
        gameObject.SetActive(false);
    }

    /// <summary>
    /// アイテム欄の表示/非表示を切り替えます。
    /// </summary>
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        if (gameObject.activeSelf)
        {
            // 表示された場合はアイテム欄をリフレッシュする
            for (var i = 0; i < buttonNumber; i++)
            {
                // 各アイテムボタンに所持アイテム情報をセット
                _itemButtons[i].OwnedItem = OwnedItemsData.Instance.OwnedItems.Length > i
                    ? OwnedItemsData.Instance.OwnedItems[i]
                    : null;
            }
        }
    }
}