using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class �������
{
    public string ��������;
    [Range(0f, 1f)] public float ��������;
    public System.Action ����;
    public void ���鷢��()
    {
        if (���� != null)
        {
            ����();
        }
    }
    public �������(string ��������,float ��������, System.Action ����) 
    {
        this.�������� = ��������;
        this.�������� = ��������;
        this.���� = ����;
    }
}

public class �����ۺ�
{
    public string �ܾ�����;
    public bool �Ƿ�������������;
    public float �������������;
    public List<�������> ���о���;
    public �����ۺ�(string name, bool type, float ����, List<�������>���о���)
    {
        �ܾ����� = name;    �Ƿ������������� = type; ������������� = ����; this.���о��� = ���о���;
    }
}

public class �������
{
    #region ����ģʽ
    public static ������� instance;
    public static ������� Instance
    {
        get
        {
            //��֤�����Ψһ��
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new �������();//������Ϸ����
                }
            }
            return instance;
        }
    }
    #endregion
    public Dictionary<string,bool>������� = new Dictionary<string, bool>();
    public int ̫��گ�� = -1;
    public int ������������ = 0;
    public int ���Ļ��굤 = 0;
    void ������鷢��(�����ۺ� �ۺϾ���)
    {
        float ��� = Random.Range(0f, 1f);
        if (��� <= �ۺϾ���.�������������) return;
        float �ܺ͸��� = 0;
        for (int i = 0; i < �ۺϾ���.���о���.Count; i++)
        {
            �ܺ͸��� += �ۺϾ���.���о���[i].��������;
        }
        ��� = Random.Range(0f, �ܺ͸���);
        float kk = 0f;
        for (int i = 0; i < �ۺϾ���.���о���.Count; i++)
        {
            kk += �ۺϾ���.���о���[i].��������;
            if (��� <= kk)
            {
                �ۺϾ���.���о���[i].���鷢��();
                return;
            }
        }
    }

    #region ��ȡ�����ۺ�
    public �����ۺ� ��ȡ�𹬽������()
    {
        �����ۺ� �𹬽������ = new �����ۺ�("�𹬽������", true, 0.5f, new List<�������>() {
        new �������("�����Ӵ��Ե�����",1f,��������.Instance.�����Ӵ��Ե�����),
        new �������("�����Ӵ��Ե�����",0.3f,��������.Instance.ι����),
        new �������("�����밲",0.3f,��������.Instance.�����밲),
        });
        return �𹬽������;
    }

    public �����ۺ� ��ȡ���ӹ�Ů����()
    {
        �����ۺ� ���ӹ�Ů���� = new �����ۺ�("���ӹ�Ů����", false, 0f, new List<�������>()
        {
            
        });
        return ���ӹ�Ů����;
    }
    #endregion
    #region ���鷢��
    public void �𹬽������()
    {
        ������鷢��(��ȡ�𹬽������());
    }
    #endregion

}