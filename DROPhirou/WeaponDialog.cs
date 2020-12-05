using UnityEngine;

public class WeaponDialog : MonoBehaviour
{
    [SerializeField] private int buttonNumber = 15;
    [SerializeField] private ItemButton itemButton;

    private ItemButton[] _itemButtons;

    private void Start()
    {
        // ������Ԃ͔�\��
        gameObject.SetActive(false);
    }

    /// <summary>
    /// �A�C�e�����̕\��/��\����؂�ւ��܂��B
    /// </summary>
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        if (gameObject.activeSelf)
        {
            // �\�����ꂽ�ꍇ�̓A�C�e���������t���b�V������
            for (var i = 0; i < buttonNumber; i++)
            {
                // �e�A�C�e���{�^���ɏ����A�C�e�������Z�b�g
                _itemButtons[i].OwnedItem = OwnedItemsData.Instance.OwnedItems.Length > i
                    ? OwnedItemsData.Instance.OwnedItems[i]
                    : null;
            }
        }
    }
}