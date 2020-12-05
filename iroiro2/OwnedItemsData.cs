using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OwnedItemsData
{
    /// <summary>
    /// PlayerPrefs�ۑ���L�[
    /// </summary>
    private const string PlayerPrefsKey = "OWNED_ITEMS_DATA";

    /// <summary>
    /// �C���X�^���X��Ԃ��܂��B
    /// </summary>
    public static OwnedItemsData Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = PlayerPrefs.HasKey(PlayerPrefsKey)
                    ? JsonUtility.FromJson<OwnedItemsData>(PlayerPrefs.GetString(PlayerPrefsKey))
                    : new OwnedItemsData();
            }

            return _instance;
        }
    }

    private static OwnedItemsData _instance;

    /// <summary>
    /// �����A�C�e���ꗗ���擾���܂��B
    /// </summary>
    public OwnedItem[] OwnedItems
    {
        get { return ownedItems.ToArray(); }
    }

    /// <summary>
    /// �ǂ̃A�C�e�������������Ă��邩�̃��X�g
    /// </summary>
    [SerializeField] private List<OwnedItem> ownedItems = new List<OwnedItem>();

    /// <summary>
    /// �R���X�g���N�^
    /// �V���O���g���ł͊O������new�ł��Ȃ��悤�R���X�g���N�^��private�ɂ���
    /// </summary>
    private OwnedItemsData()
    {
    }

    /// <summary>
    /// JSON������PlayerPrefs�ɕۑ����܂��B
    /// </summary>
    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerPrefsKey, jsonString);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// �A�C�e����ǉ����܂��B
    /// </summary>
    /// <param name="type"></param>
    /// <param name="number"></param>
    public void Add(Item.ItemType type, int number = 1)
    {
        var item = GetItem(type);
        if (null == item)
        {
            item = new OwnedItem(type);
            ownedItems.Add(item);
        }
        item.Add(number);
    }

    /// <summary>
    /// �A�C�e��������܂��B
    /// </summary>
    /// <param name="type"></param>
    /// <param name="number"></param>
    /// <exception cref="Exception"></exception>
    public void Use(Item.ItemType type, int number = 1)
    {
        var item = GetItem(type);
        if (null == item || item.Number < number)
        {
            throw new Exception("�A�C�e��������܂���");
        }
        item.Use(number);
    }

    /// <summary>
    /// �Ώۂ̎�ނ̃A�C�e���f�[�^���擾���܂��B
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public OwnedItem GetItem(Item.ItemType type)
    {
        return ownedItems.FirstOrDefault(x => x.Type == type);
    }

    /// <summary>
    /// �A�C�e���̏������Ǘ��p���f��
    /// </summary>
    [Serializable]
    public class OwnedItem
    {
        /// <summary>
        /// �A�C�e���̎�ނ�Ԃ��܂��B
        /// </summary>
        public Item.ItemType Type
        {
            get { return type; }
        }

        public int Number
        {
            get { return number; }
        }

        /// <summary>
        /// �A�C�e���̎��
        /// </summary>
        [SerializeField] private Item.ItemType type;

        /// <summary>
        /// ������
        /// </summary>
        [SerializeField] private int number;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="type"></param>
        public OwnedItem(Item.ItemType type)
        {
            this.type = type;
        }

        public void Add(int number = 1)
        {
            this.number += number;
        }

        public void Use(int number = 1)
        {
            this.number -= number;
        }
    }
}
