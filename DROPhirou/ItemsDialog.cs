using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDialog : MonoBehaviour
{
    [SerializeField] private int buttonNumber = 15;
    [SerializeField] private ItemButton itemButton;

    private ItemButton[] _itemButtons;

    private void Start()
    {
        // ������Ԃ͔�\��
        gameObject.SetActive(false);

        // �A�C�e������K�v�ȕ���������
        for (var i = 0; i < buttonNumber - 1; i++)
        {
            Instantiate(itemButton, transform);
        }

        // �q�v�f��ItemButton���ꊇ�擾�A�ێ����Ă���
        _itemButtons = GetComponentsInChildren<ItemButton>();
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