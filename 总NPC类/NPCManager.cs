using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC
{
    // Start is called before the first frame update
    //NPC����Ҫ�Ĺ�����Ϣ
    #region ��������
    public string �ƺ� = "";
    public int ��ϵ=50;
    public string ����;
    public bool �����ж� = false;
    public string ����;
    public string ��;
    public string ��;
    public string �Ա�;
    public int ����;
    public string ����;
    public string ����="";
    public int ����;
    public int ��������;
    public int ����;
    public int ����;
    public int ����;
    public int ����;
    public int ͳ˧;
    public int ����;
    public int Ұ��;
    public int ������;
    public int ��=0;
    public int ����;
    public int ����;
    public int ������;
    public string ����;
    public List<string> ϲ�� = new List<string>();
    public int ������;
    public string ����;
    public string ��;
    public string ��;
    public int �� = -1;
    public int ����ϵ = 0;
    public int ��ȡ��;
    public int ����=-1;
    public int ��������=-1;
    public int �ߴ�=-1;
    public int ��Χ=-1;

    [NonSerialized]public Sprite ����;
    public string �����ַ;
    public int ���� = -1;
    public int ��ĸ = -1;
    public int ����=-1;
    public int ĸ��=-1;
    public int ���游 = -1;
    public int ����ĸ = -1;
    public int �游 = -1;
    public int ��ĸ = -1;
    public int ����=-1;
    public int ���޶���ֵ = 50;
    public string ס��;
    public int ���;
    public int Ů������=0;
    public int ��������=0;
    public int ��Ů����=0;
    public int ��������=0;
    public int ���� = 0;
    public double ��Ǯ = 0;
    public string ��� = "";
    public string ���� = "��";
    public List<int> ���� = new List<int>();
    public List<����> ���� = new List<����>();
    public List<int> ��� = new List<int>();
    public int ѡ���� = 0;
    public int ���� = 89;
    public string ����="";
    public string �ǳ�;
    public int ״̬;
    public int �� = 0;
    public int ���Ӹ��� = -1;
    public int ������ = 50;
    public int �� = 0;
    public int �󹬹����� = 0;
    public int �󳼹����� = 0;
    public int ���ù����� = 0;
    public int ������ = 0;
    public int ��͢���� = 0;
    public int �������� = -1;
    public int ɥ�޶������ֵ = 0;
    public string ɥ�޶��� = "";
    public int ʫ = 0;

    #endregion
    public virtual void �鿴����()
    {
        GameObject instance = UI���.ʵ����(Resources.Load<GameObject>("Ԥ����/��ϢչʾԤ����/����һ��������"));
        instance.GetComponent<���������һ��UI����>().npc = this;
    }
    public virtual void ��������Ϣ���()
    {
    }
    public virtual void �������()
    {

    }
    public virtual void �򿪼Ҿ����()
    {
        List<KeyValuePair<int, string>> �������� = new List<KeyValuePair<int, string>>();
        Dictionary<int, string> ���� = ��ȡ����();
        List<int> npcsid = new List<int>();
        List<string> ��ϵ = new List<string>();
        foreach (KeyValuePair<int, string> kv in ����)
        {
            npcsid.Add(kv.Key);
            ��ϵ.Add(kv.Value);
        }
        ��Ϣ�б�UI���� UI = UI���.ʵ����(Resources.Load<GameObject>("Ԥ����/����Ԥ����/�����б�/�Ҿ��б�/�Ҿ��ϵ�б�")).GetComponent<��Ϣ�б�UI����>();
        //Debug.Log(��������.Count);
        UI.type = "�Ҿ�";
        UI.npcsid = npcsid;
        UI.��ϵ = ��ϵ;
        UI.ˢ��npcs();
        UI.�б�չʾ();
        //Debug.Log("�򿪼Ҿ����");
    }
    public void ��������()
    {
        ���� = UI���.���ر���ͼƬ(�����ַ);
    }
    public virtual void Initialize(string ����,string type,int id)
    {
        this.���� = ����;
        �� = ȡ�����ֿ�.Instance.��ȡ��();
        if (type == "��")
        {
            �� = ȡ�����ֿ�.Instance.��ȡ��(UnityEngine.Random.Range(1, 3), "��");
        }
        else if (type == "Ů")
        {
            �� = ȡ�����ֿ�.Instance.��ȡ��(UnityEngine.Random.Range(1, 3), "Ů");
        }
        �ǳ� = ��;
        ���� = UnityEngine.Random.Range(20, 600);
        ���� = UnityEngine.Random.Range(1, 13);
        ���� = ���ݿ�.����[UnityEngine.Random.Range(0, ���ݿ�.����.Length)];
        ���� = ���� + �� + "��";
        �Ա� = type;
        ���� = UnityEngine.Random.Range(1, 13);
        if (�Ա� == "Ů")
        {
            ������ = UnityEngine.Random.Range(0, ���ݿ�.Ů����.Count);
            ���� = ���ݿ�.Ů����[������][UnityEngine.Random.Range(0, ���ݿ�.Ů����[������].Count)];
        }
        else if(�Ա�=="��")
        {
            ������ = UnityEngine.Random.Range(0, ���ݿ�.�и���.Count);
            ���� = ���ݿ�.�и���[������][UnityEngine.Random.Range(0, ���ݿ�.�и���[������].Count)];
        }
        ���� = new List<����>();
        ���� = UnityEngine.Random.Range(0, 101);
        ���� = UnityEngine.Random.Range(0, 101);
        ���� = UnityEngine.Random.Range(0, 101);
        ͳ˧ = UnityEngine.Random.Range(0, 101);
        ���� = UnityEngine.Random.Range(0, 101);
        ʫ = UnityEngine.Random.Range(0, 101);
        ���� = �� + ��;
        if (type == "Ů") ���� = UnityEngine.Random.Range(80, 120);
        else ���� = UnityEngine.Random.Range(120, 180);
        ���� = -1;
        ��� = id;
        �� = 0;
        ������ = UnityEngine.Random.Range(0, 100);
        if(�Ա�=="��")
            ϲ��.Add(���ݿ�.�а���[������][UnityEngine.Random.Range(0,���ݿ�.�а���[������].Count)]);
        else if(�Ա�=="Ů") ϲ��.Add(���ݿ�.�а���[������][UnityEngine.Random.Range(0, ���ݿ�.�а���[������].Count)]);
        Ұ�� = UnityEngine.Random.Range(50, 100);
    }
    public void ͨ�����ݸ���(NPC npc)
    {
        �ƺ� = npc.�ƺ�;
        �� = npc.��;
        �� = npc.��;
        �Ա� = npc.�Ա�;
        ���� = npc.����;
        ���� = npc.����;
        ���� = npc.����;
        ���� = npc.����;
        �������� = npc.��������;
        ���� = npc.����;
        ���� = npc.����;
        ���� = npc.����;
        ���� = npc.����;
        ͳ˧ = npc.ͳ˧;
        ���� = npc.����;
        Ұ�� = npc.Ұ��;
        ������ = npc.������;
        �� = npc.��;
        ���� = npc.����;
        ���� = npc.����;
        ������ = npc.������;
        ���� = npc.����;
        ϲ�� = npc.ϲ��;
        ������ = npc.������;
        ���� = npc.����;
        �� = npc.��;
        �� = npc.��;
        �� = npc.��;
        ��ȡ�� = npc.��ȡ��;
        ����ϵ = npc.����ϵ ;
        ���� = npc.����;
        �������� = npc.��������;
        �ߴ� = npc.�ߴ�;
        ��Χ = npc.��Χ;
        ���� = npc.����;
        ��ĸ = npc.��ĸ;
        ���� = npc.����;
        ĸ�� = npc.ĸ��;
        ���游 = npc.���游;
        ����ĸ = npc.����ĸ;
        �游 = npc.�游;
        ��ĸ = npc.��ĸ;
        ���� = npc.����;
        ��ϵ = npc.��ϵ;
        ���޶���ֵ = npc.���޶���ֵ;
        ס�� = npc.ס��;
        Ů������ = npc.Ů������;
        �������� = npc.��������;
        ��Ů���� = npc.��Ů����;
        �������� = npc.��������;
        ���� = npc.����;
        ��Ǯ = npc.��Ǯ;
        ��� = npc.���;
        ���� = npc.����;
        ���� = npc.����;
        ���� = npc.����;
        ��� = npc.���;
        ���� = npc.����;
        ���� = npc.����;
        ���Ӹ��� = npc.���Ӹ���;
        ������ = npc.������;
        �� = npc.��;
    }

    public virtual void �����ж�()
    {

    }
    public void ��ѡ��������()
    {
        string[] ���ܰ�ť���� = { "�׾�", "����", "", "", "", "", "", "", "�޸�", "����" };
        string[] �鿴��Ϣ��ť���� = { "����", "��ΪŮ��", "�����" };
        GameObject instance = UI���.ʵ����(Resources.Load<GameObject>("Ԥ����/��ϢչʾԤ����/������Ϣչʾ"));
        Transform �鿴��Ϣ��� = instance.transform.Find("������Ϣ���/�鿴��Ϣ���");
        Transform ������� = instance.transform.Find("�������");
        Image image = instance.transform.Find("������Ϣ���/��������").GetComponent<Image>();
        image.sprite = ����;
        TextMeshProUGUI text = instance.transform.Find("������Ϣ���/�������").GetComponent<TextMeshProUGUI>();
        //text.text = ��ȡ�������().ToString();
        Button[] �鿴��Ϣ��ť = �鿴��Ϣ���.GetComponentsInChildren<Button>();
        Button[] buttons = �������.GetComponentsInChildren<Button>();
        #region ���İ�ť������ɼ��̶�
        for (int i = 0; i < buttons.Length; i++)
        {
            if (���ܰ�ť����[i].Length == 0)
            {
                buttons[i].GetComponent<CanvasGroup>().interactable = false;
                buttons[i].GetComponent<CanvasGroup>().alpha = 0.0f;
            }
            else
            {
                buttons[i].GetComponent<CanvasGroup>().interactable = true;
                buttons[i].GetComponent<CanvasGroup>().alpha = 1.0f;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = ���ܰ�ť����[i];
            }
        }
        for (int i = 0; i < �鿴��Ϣ��ť.Length; i++)
        {
            �鿴��Ϣ��ť[i].GetComponentInChildren<TextMeshProUGUI>().text = �鿴��Ϣ��ť����[i];
        }
        #endregion
        #region ��Ӱ�ť����¼�
        buttons[0].onClick.AddListener(() => �򿪼Ҿ����());
        //buttons[1].onClick.AddListener(() => жְ());
        //buttons[2].onClick.AddListener(() => ����ū�());
        //buttons[3].onClick.AddListener(() => �鿴����());
        //buttons[7].onClick.AddListener(() => �ߴ�());
        //buttons[8].onClick.AddListener(() => �޸�());
        buttons[9].onClick.AddListener(() => �鿴����());
        �鿴��Ϣ��ť[0].onClick.AddListener(() => ����());
        �鿴��Ϣ��ť[1].onClick.AddListener(() => ��ΪŮ��());
        �鿴��Ϣ��ť[2].onClick.AddListener(() => ѡ��(instance));
        #endregion
    }
    public void ��ΪŮ��()
    {
        Debug.Log("��ΪŮ��");
    }
    public void ����()
    {
        Debug.Log("����");
    }
    public void ѡ��(GameObject instance)
    {
        UI���.���ٳ���(instance);
        ���� ���� = new ����();
        if (��� == -1)
        {
            ���� = (����)NPCManager.Instance.�����������("����", "Ů");
        }
        else
        {
            ����.Initialize("����", this.�Ա�, this.���);
            NPCManager.Instance.�����б�.Add(����.���);
        }
        ����.����Ʒ�� = ���ݿ�.����λ��.Count;
        ����.λ�� = "��Ů";
        ����.ͨ�����ݸ���(this);
        ����.���� = ����.Instance.���;
        ����.���� = "����";
        NPCManager.Instance.��������[����.���] = ����;
        ����.ѡ���� = 1;
        this.ѡ���� = 1;
        ����.���("ѡ��", null);
    }
    public virtual void �ݷ�()
    {

    }
    public virtual void ɾ������(GameObject instance)
    {
        GameObject ɾ��ȷ�� = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Ԥ����/UIԤ����/��ʾ�����2"),instance.transform);
        ��ʾ�����UI���� UI = ɾ��ȷ��.GetComponent<��ʾ�����UI����>();
        UI.���� = "ɾ������";
        UI.instance = instance;
        UI.��� = this.���;
        UI.��ʾ�� = "ȷ��ɾ����������";
    }
    public virtual Dictionary<int,string> ��ȡ����()
    {
        Dictionary<int,string> ���� = new Dictionary<int,string>();
        if(����!="����"&&����!="����"&&����!="�ʵ�")
        {
            if (this.�游 != -1) �ݹ��ȡ����(this.�游, ����, "�游", 0);
            else if (this.���� != -1) �ݹ��ȡ����(this.����, ����, "����", 1);
        }
        if (this.���游 != -1) �ݹ��ȡ����(this.���游, ����, "���游", 0);
        else if (this.ĸ�� != -1) �ݹ��ȡ����(this.ĸ��, ����, "ĸ��", 1);
        if (���� == -1 && ĸ�� == -1)
            �ݹ��ȡ����(this.���, ����, "�Լ�", 2);
        return ����;
    }
    private void �ݹ��ȡ����(int id, Dictionary<int,string>����,string ��ϵ,int depth)
    {
        //Debug.Log(NPCManager.Instance.��������[id] + "  " + ��ϵ + "  " + depth);
        if (id != this.��� && NPCManager.Instance.��������[id].�����ж�==false)
            ����[id] = ��ϵ;
        if (NPCManager.Instance.��������[id].���� == "�ʵ�" || NPCManager.Instance.��������[id].���� == "�Ȼ�") return;
        if (depth > 4) return;
        if (��ϵ == "�游" && NPCManager.Instance.��������[id].���� != -1) ����[NPCManager.Instance.��������[id].����] = "��ĸ";
        if (��ϵ == "���游" && NPCManager.Instance.��������[id].���� != -1) ����[NPCManager.Instance.��������[id].����] = "����ĸ";
        if(��ϵ=="�Լ�")
        {
            if (NPCManager.Instance.��������[id].���� != -1 && NPCManager.Instance.��������[id].�Ա�=="��") ����[NPCManager.Instance.��������[id].����] = "����";
            else if (NPCManager.Instance.��������[id].���� != -1 && NPCManager.Instance.��������[id].�Ա�=="Ů") ����[NPCManager.Instance.��������[id].����] = "����";
            for (int i = 0; i < NPCManager.Instance.��������[id].���.Count; i++)
            {
                int ��ұ�� = NPCManager.Instance.��������[id].���[i];
                ����[��ұ��] = "���";
            }
        }
        else if(��ϵ=="����")
        {
            for (int i = 0; i < NPCManager.Instance.��������[id].���.Count; i++)
            {
                int ��ұ�� = NPCManager.Instance.��������[id].���[i];
                ����[��ұ��] = "��ĸ";
            }
        }
        int Ů������ = 1, ���Ӽ��� = 1;
        //Debug.Log(NPCManager.Instance.��������[id].����.Count);
        if(��ϵ=="�Լ�")
        {
            NPCManager.Instance.��������[id].����.Sort((a, b) => NPCManager.Instance.��������[b].����.CompareTo(NPCManager.Instance.��������[a].����));
        }
        for (int i = 0; i <NPCManager.Instance.��������[id].����.Count; i++)
        {
            int cid = NPCManager.Instance.��������[id].����[i];
            //if (NPCManager.Instance.��������[cid].�����ж� == true) continue;
            string �Ա� = NPCManager.Instance.��������[cid].�Ա�;
            int ���� = NPCManager.Instance.��������[cid].����;
            #region ��ϵ�ж�
            if (cid == this.���) �ݹ��ȡ����(cid,����,"�Լ�",depth+1);
            if (����.ContainsKey(cid)) continue;
            if (��ϵ == "�游")
            {
                int �������� = NPCManager.Instance.��������[����].����;
                if (cid == this.����) �ݹ��ȡ����(cid,����,"����",depth+1); 
                else if (�Ա� == "Ů") �ݹ��ȡ����(cid, ����, "�ù�", depth + 1);
                else if (�Ա� == "��" && ���� < ��������) �ݹ��ȡ����(cid, ����, "����", depth + 1);
                else if (�Ա� == "��" && ���� >= ��������) �ݹ��ȡ����(cid, ����, "����", depth + 1);
            }
            else if(��ϵ=="���游")
            {
                int ĸ������ = NPCManager.Instance.��������[ĸ��].����;
                if (cid == this.ĸ��) ����[cid] = "ĸ��";
                else if (�Ա� == "Ů") �ݹ��ȡ����(cid, ����, "����", depth + 1);
                else if (�Ա� == "��") �ݹ��ȡ����(cid, ����, "�˾�", depth + 1);
            }
            else if(��ϵ=="����")
            {
                if (�Ա� == "Ů" && ���� > this.����) �ݹ��ȡ����(cid, ����, "���", depth + 1);
                else if (�Ա� == "Ů" && ���� <= this.����) �ݹ��ȡ����(cid, ����, "����", depth + 1);
                else if (�Ա� == "��" && ���� >=this.����) �ݹ��ȡ����(cid, ����, "���", depth + 1);
                else if (�Ա� == "��") �ݹ��ȡ����(cid, ����, "�ܵ�", depth + 1);
            }
            else if(��ϵ=="�ù�"||��ϵ=="����"||��ϵ=="����")
            {
                if (�Ա� == "Ů" && ���� > this.����) �ݹ��ȡ����(cid, ����, "�ý�", depth + 1);
                else if (�Ա� == "Ů" && ���� <= this.����) �ݹ��ȡ����(cid, ����, "����", depth + 1);
                else if (�Ա� == "��" && ���� >= this.����) �ݹ��ȡ����(cid, ����, "����", depth + 1);
                else if (�Ա� == "��") �ݹ��ȡ����(cid, ����, "�õ�", depth + 1);
            }
            else if(��ϵ=="����"||��ϵ=="�˾�")
            {
                if (�Ա� == "Ů" && ���� > this.����) �ݹ��ȡ����(cid, ����, "���", depth + 1);
                else if (�Ա� == "Ů" && ���� <= this.����) �ݹ��ȡ����(cid, ����, "����", depth + 1);
                else if (�Ա� == "��" && ���� >= this.����) �ݹ��ȡ����(cid, ����, "���", depth + 1);
                else if (�Ա� == "��") �ݹ��ȡ����(cid, ����, "���", depth + 1);
            }
            else if (��ϵ[0]=='��')
            {
                if (�Ա� == "Ů") �ݹ��ȡ����(cid, ����, "ֶŮ", depth + 1);
                else �ݹ��ȡ����(cid, ����, "ֶ��", depth + 1);
            }
            else if (��ϵ[0]=='��')
            {
                if (�Ա� == "Ů") �ݹ��ȡ����(cid, ����, "����", depth + 1);
                else �ݹ��ȡ����(cid, ����, "����Ů", depth + 1);
            }
            else if(��ϵ=="�Լ�")
            {
                Debug.Log("������");
                string str = "";
                str += NPCManager.Instance.��������[cid].����;
                if(�Ա�=="Ů")
                {
                    if (Ů������ == 1) str += "��";
                    else if (Ů������ == 2) str += "��";
                    else str += ���ݿ�.��д����[Ů������];
                    str += "Ů";
                    Ů������++;
                }
                else if(�Ա�=="��")
                {
                    if (���Ӽ��� == 1) str += "��";
                    else if (���Ӽ��� == 2) str += "��";
                    else str += ���ݿ�.��д����[���Ӽ���];
                    str += "��";
                    ���Ӽ���++;
                }
                if (NPCManager.Instance.��������[cid].���� != -1 && NPCManager.Instance.��������[cid].����!=����.Instance.���)
                {
                    int ���� = NPCManager.Instance.��������[cid].����;
                    if (�Ա� == "Ů")
                    {
                        ����[����] = "Ů��";
                    }
                    else ����[����] = "��ϱ";
                }
                �ݹ��ȡ����(cid, ����, str, depth + 1);
            }
            else if (��ϵ[0] == '��' || ��ϵ[0]=='��')
            {
                string str = "";
                if (��ϵ[2] == 'Ů') str += "��";
                if (�Ա� == "Ů") str+= "��Ů";
                else str+= "����";
                if (��ϵ[2]=='��'&&NPCManager.Instance.��������[cid].����!=-1)
                {
                    int ���� = NPCManager.Instance.��������[cid].����;
                    if (�Ա� == "��") ����[����] = "��ϱ";
                    else ����[����] = "��Ů��";
                }
                ����[cid] = str;
            }
            #endregion
        }


    }

    public void ���ӳ���()
    {

    }
}
public class NPCManager
{
    #region ��������б�
    // Start is called before the first frame update
    public List<int> �����б� = new List<int>();
    public List<int> ���б� = new List<int>();
    public List<int> ̫���б� = new List<int>();
    public List<int> �����б� = new List<int>();
    public List<int> �����б� = new List<int>();
    public Dictionary<int,NPC> ��������= new Dictionary<int,NPC>();
    //public List<NPC> �������� = new List<NPC>();
    public List<int> �ʵ��б� = new List<int>();
    public List<int> �й��б� = new List<int>();
    public List<int> ��Ů�б� = new List<int>(); 
    public int all_people_count = 0;
    #endregion
    #region ����ģʽ
    public static NPCManager instance;
    public static NPCManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NPCManager();
            }
            return instance;
        }
    }
    #endregion
    public void �������(NPC npc)
    {
        if (npc.���� != -1||npc.����<18) return;
        string type = npc.�Ա� == "��" ? "Ů" : "��";
        �Ҿ� ���� = (�Ҿ�)�����������("�Ҿ�", type);
        ����.���� = Math.Max(npc.���� + UnityEngine.Random.Range(-10, 10),UnityEngine.Random.Range(16,20));
        ����.�������();
        ����.���� = npc.���;
        npc.���� = ����.���;
    }
    public void �������(NPC npc)
    {
        if (npc.���� < 18 || (npc.���� == -1&&npc.���.Count==0)) return;
        ���� ���� = �������.Instance.���м���[npc.����];
        int �������� = UnityEngine.Random.Range(0, 6);
        for(int i = 0; i < ��������; i++)
        {
            �Ҿ� ���� = (�Ҿ�)NPCManager.Instance.�����������("�Ҿ�",UnityEngine.Random.Range(0,2)==0?"��":"Ů");
            NPC ĸ�� = new NPC();
            if (npc.���� == -1) { ĸ�� = NPCManager.Instance.��������[npc.���[UnityEngine.Random.Range(0, npc.���.Count)]]; ����.���� = "��"; }
            else if (npc.���.Count <= 0) ĸ�� = NPCManager.Instance.��������[npc.����];
            else if (UnityEngine.Random.Range(0, 100) < 60) ĸ�� = NPCManager.Instance.��������[npc.����];
            else
            {
                ĸ�� = NPCManager.Instance.��������[npc.���[UnityEngine.Random.Range(0, npc.���.Count)]];
                ����.���� = "��";
            }
            ����.���� = Math.Max(1, ĸ��.���� - UnityEngine.Random.Range(18, 30));
            ����.�� = npc.��;
            ����.���� = npc.����;
            ����.���� = npc.����;
            ����.�������();
            ����.���� = npc.���;
            ����.ĸ�� = ĸ��.���;
            ����.�����Ա.Add(����.���);
            ĸ��.����.Add(����.���);
            npc.����.Add(����.���);
            if (����.�Ա� == "Ů") npc.Ů������++;
            else npc.��������++;

        }
    }
    public NPC ������ʱ����(string type, string �Ա�)
    {
        NPC npc = new NPC();
        if(type=="����")
        {
            npc = new ����();
        }
        else if(type=="��")
        {
            npc = new ��();
        }
        npc.Initialize(type, �Ա�, -1);
        return npc;
    }
    public NPC �����������(string type,string �Ա�)
    {
        NPC npc = new NPC();
        int id = all_people_count++;
        if (type == "����")
        {
            npc = new ����();
            npc.���� = ����.Instance.���;
            �����б�.Add(id);
        }
        else if(type=="�Ҿ�")
        {
            npc = new �Ҿ�();
        }
        else if (type == "��")
        {
            npc = new ��();
            ���б�.Add(id);
        }
        else if (type == "̫��")
        {
            npc = new ̫��();
            ̫���б�.Add(id);
        }
        else if(type =="����")
        {
            npc = new ����();
            �����б�.Add(id);
        }
        else if(type=="����")
        {
            npc = new ����();
            �����б�.Add(id);
        }
        else if (type == "�Ȼ�")
        {
            npc = new �ʵ�();
            �ʵ��б�.Add(id);
        }
        ��������[id] = npc;
        npc.Initialize(type,�Ա�,id);
        return npc;
    }
    public void ��ʼ������(int num)
    {
        for(int i=0;i<num;i++)
        {
            �� �� = (��)�����������("��", "��");
            ��ְ����.Instance.��ʼ��ְ����(��,2,12);
            ���� �󳼼���;
            if (!�������.Instance.���м���.ContainsKey(��.����))
            {
                �󳼼��� = new ����(��.����);
                �󳼼���.�峤��� = ��.���;
                �������.Instance.���м���.Add(��.����,�󳼼���);
                //�󳼼���.����Ա.Add(��.���);
            }
            else
            {
                �󳼼��� = �������.Instance.���м���[��.����];   
            }

            �󳼼���.�����Ա.Add(��.���);
            �󳼼���.��͢���� += ��ϵ����.��ȡ��Ա����ֵ(��);
            int ������� = UnityEngine.Random.Range(0, 3);
            for(int j=1;j<=�������;j++)
            {
                �Ҿ� ��� = (�Ҿ�)NPCManager.Instance.�����������("�Ҿ�", "Ů");
                ���.���� = ��.���� + UnityEngine.Random.Range(-5, 5);
                ��.���.Add(���.���);
            }
            int ��� = UnityEngine.Random.Range(0, 10);
            if(���<5)
            {
                NPCManager.Instance.�������(��);
                NPCManager.Instance.�������(��);
            }
        }
    }
    public void ��ʼ������̫��()
    {
        for (int i = 0; i < 4; i++)
            NPCManager.Instance.�����������("����", "Ů");
        int len = NPCManager.Instance.�����б�.Count;
        ���� ���� = (����)NPCManager.Instance.��������[NPCManager.Instance.�����б�[len - 4]];
        ����.����Ʒ�� = UnityEngine.Random.Range(1, ���ݿ�.����λ��.Count/5*2);
        ����.Сλ�� = 0;
        ����.λ�� = ���ݿ�.����λ��[����.����Ʒ��].����Сλ��[0];
        ���ݿ�.����λ��[����.����Ʒ��].��������++;
        int �������� = UnityEngine.Random.Range(0, ���ݿ�.���弮��.Length / 3);
        ����.�� = ���ݿ�.������[��������];
        ����.���� = ���ݿ�.���弮��[��������];
        ����.���� = ����.���� + ����.�� + "��";
        ����.ס�� = �������.Instance.���Ź���(����, 0);
        ����.���� = ����.Instance.���;

        ���� ��� = (����)NPCManager.Instance.��������[NPCManager.Instance.�����б�[len - 3]];
        ���.����Ʒ�� = UnityEngine.Random.Range(���ݿ�.����λ��.Count/5*2,���ݿ�.����λ��.Count/5*3);
        ���.λ�� = ���ݿ�.����λ��[���.����Ʒ��].����Сλ��[0];
        ���ݿ�.����λ��[���.����Ʒ��].��������++;
        int ��淼��� = UnityEngine.Random.Range(���ݿ�.���弮��.Length / 3, ���ݿ�.���弮��.Length/3*2);
        ���.�� = ���ݿ�.������[��淼���];
        ���.���� = ���ݿ�.���弮��[��淼���];
        ���.���� = ���.���� + ���.�� + "��";
        ���.ס�� = �������.Instance.���Ź���(���, 0);
        ���.���� = ����.Instance.���;

        ���� ���� = (����)NPCManager.Instance.��������[NPCManager.Instance.�����б�[len - 2]];
        ����.����Ʒ�� = UnityEngine.Random.Range(���ݿ�.����λ��.Count/5*3, ���ݿ�.����λ��.Count/5*4);
        ����.λ�� = ���ݿ�.����λ��[����.����Ʒ��].����Сλ��[0];
        ���ݿ�.����λ��[����.����Ʒ��].��������++;
        int ���ּ��� = UnityEngine.Random.Range(���ݿ�.���弮��.Length / 3 * 2, ���ݿ�.���弮��.Length);
        ����.�� = ���ݿ�.������[���ּ���];
        ����.���� = ���ݿ�.���弮��[���ּ���];
        ����.���� = ����.���� + ����.�� + "��";
        ����.ס�� = �������.Instance.���Ź���(����, 0);
        ����.���� = ����.Instance.���;

        ���� ���� = (����)NPCManager.Instance.��������[NPCManager.Instance.�����б�[len - 1]];
        ����.����Ʒ�� = UnityEngine.Random.Range(���ݿ�.����λ��.Count/5*4, ���ݿ�.����λ��.Count);
        ����.λ�� = ���ݿ�.����λ��[����.����Ʒ��].����Сλ��[0];
        ���ݿ�.����λ��[����.����Ʒ��].��������++;
        ����.���� = ���ݿ�.����[UnityEngine.Random.Range(0, ���ݿ�.����.Length)];
        ����.���� = ����.���� + ����.�� + "��";
        ����.ס�� = �������.Instance.���Ź���(����, 0);
        ����.���� = ����.Instance.���;

        int ̫������ = UnityEngine.Random.Range(0, 10);
        for (int i = 0; i <= ̫������; i++)
        {
            NPCManager.Instance.�����������("̫��", "Ů");
            ̫�� ̫�� = (̫��)NPCManager.Instance.��������[NPCManager.Instance.̫���б�[i]];
            ̫��.���� = NPCManager.Instance.�ʵ��б�[0];
            if (i == 0)
            {
                ̫��.���� = UnityEngine.Random.Range(35, 45);
                ̫��.����Ʒ�� = 0;
                ̫��.λ�� = ���ݿ�.����λ��[0].����Сλ��[0];
                int ��� = UnityEngine.Random.Range(0, 100);
                if (��� > 80)
                {
                    ���� ���� = (����)NPCManager.Instance.��������[NPCManager.Instance.�����б�[UnityEngine.Random.Range(0, math.min(5, NPCManager.Instance.�����б�.Count))]];
                    �м����.Instance.̫�����Ӽ���ͳһ = ����.���;
                    ̫��.���� = ����.����;
                    ̫��.�� = ����.��;
                    ̫��.���� = ����.����;
                    ��Ϸ�趨.Instance.̫�� = ̫��.���;
                    ̫����������();
                }
            }
            ̫��.���Ӻ���();
        }
    }
    public void ̫����������()
    {
        int ̫���� = NPCManager.Instance.̫���б�[0];
        int ���ӱ�� = �м����.Instance.̫�����Ӽ���ͳһ;
        int �������� = 4;
        if (NPCManager.Instance.��������.ContainsKey(���ӱ��) == false) return;
        ���� ���� = (����)NPCManager.Instance.��������[���ӱ��];
        ̫�� ̫�� = (̫��)NPCManager.Instance.��������[̫����];
        �� үү = (��)NPCManager.Instance.�����������("��", "��");
        �� �ְ� = (��)NPCManager.Instance.�����������("��", "��");
        ���� ̫�����;
        ̫��.�� = ����.��; ̫��.���� = ����.����; ̫��.���� = ����.����; 
        if (!�������.Instance.���м���.ContainsKey(̫��.����)) 
        { 
            ̫����� = new ����(̫��.����);
            �������.Instance.���м���[̫��.����] = ̫�����;
        }
        else ̫����� = �������.Instance.���м���[̫��.����];

        ̫�����.�峤��� = үү.���;
        ̫�����.������ = ̫��.����;
        ̫�����.�����Ա.Add(̫��.���);
        ̫�����.�����Ա.Add(үү.���);
        ̫�����.�����Ա.Add(�ְ�.���);
        ̫�����.�����Ա.Add(����.���);
        ̫�����.�󹬳�Ա.Add(����.���);
        ̫�����.�󹬳�Ա.Add(̫��.���);
        ̫�����.��͢��Ա.Add(�ְ�.���);
        ̫�����.��͢��Ա.Add(үү.���);
        үү.���� = ̫��.���� + UnityEngine.Random.Range(18, 25);
        �ְ�.���� = ̫��.���� + UnityEngine.Random.Range(3, 5);
        үү.�� = ̫��.��; үү.���� = ̫��.����; үү.���� = ̫��.����;
        �ְ�.�� = ̫��.��; �ְ�.���� = ̫��.����; �ְ�.���� = ̫��.����;

        if (�ְ�.��.Length >= 2) ̫�����.���ֱ�.Add(1, new �ֱ�(�ֱ�����.��һ����,�ְ�.��.Substring(0, 1)));
        if (̫��.��.Length >= 2) ̫�����.Ů�ֱ�.Add(1, new �ֱ�(�ֱ�����.��һ����, ̫��.��.Substring(0, 1)));
        if (үү.��.Length >= 2) ̫�����.���ֱ�.Add(0, new �ֱ�(�ֱ�����.��һ����, үү.��.Substring(0, 1)));
        if (����.��.Length >= 2) ̫�����.Ů�ֱ�.Add(2, new �ֱ�(�ֱ�����.��һ����, ����.��.Substring(0, 1)));

        үү.Ů������ = 1;
        үү.�������� = 1;
        ��ְ����.Instance.��ʼ��ְ����(үү, 1, 5);
        ��ְ����.Instance.��ʼ��ְ����(�ְ�, 3, 7);
        үү.����.Add(�ְ�.���);
        үү.����.Add(̫��.���);
        �ְ�.����.Add(����.���);
        �ְ�.Ů������ = 1;
        �ְ�.���� = үү.���; ̫��.���� = үү.���;
        ����.���� = �ְ�.���;
        ����.�游 = үү.���;
        ����.��ĸ = үү.���;
        if (үү.���� == -1)
        {
            NPCManager.Instance.�������(үү);
            NPCManager.Instance.��������[үү.����].����.Add(�ְ�.���);
            NPCManager.Instance.��������[үү.����].����.Add(̫��.���);
        }
        if (�ְ�.���� == -1)
        {
            NPCManager.Instance.�������(�ְ�);
            NPCManager.Instance.��������[�ְ�.����].����.Add(����.���);
        }
        ̫��.ĸ�� = үү.����;
        �ְ�.ĸ�� = үү.����;
        ����.ĸ�� = �ְ�.����;
        string[] �����Ա� = { "��", "Ů" };
        int ������� = UnityEngine.Random.Range(0, 3);
        for(int i=1;i<=�������;i++)
        {
            �Ҿ� ��� = (�Ҿ�)NPCManager.Instance.�����������("�Ҿ�", "Ů");
            ���.���� = �ְ�.���� + UnityEngine.Random.Range(-5, 0);
            �ְ�.���.Add(���.���);
        }
        int �������� = UnityEngine.Random.Range(0, 5);
        for (int i = 0; i < ��������; i++)
        {
            ��������++;
            string �Ա� = �����Ա�[UnityEngine.Random.Range(0, 2)];
            �Ҿ� �Ҿ� = (�Ҿ�)NPCManager.Instance.�����������("�Ҿ�", �Ա�);
            �Ҿ�.���� = ����.���� + UnityEngine.Random.Range(-5, 5);
            �Ҿ�.�� = �ְ�.��;
            if (�Ҿ�.�Ա� == "Ů" && ̫�����.Ů�ֱ�.ContainsKey(2))
            {
                if (�Ҿ�.��.Length < 2) �Ҿ�.�� = ̫�����.Ů�ֱ�[2].�� + �Ҿ�.��.Substring(0);
                else �Ҿ�.�� = ̫�����.Ů�ֱ�[2].�� + �Ҿ�.��.Substring(1);
            }
            else if (�Ҿ�.�Ա� == "��" && ̫�����.���ֱ�.ContainsKey(2))
            {
                if (�Ҿ�.��.Length < 2) �Ҿ�.�� = ̫�����.���ֱ�[2].�� + �Ҿ�.��.Substring(0);
                else �Ҿ�.�� = ̫�����.���ֱ�[2].�� + �Ҿ�.��.Substring(1);
            }
            else if(�Ҿ�.�Ա�=="��"&&!̫�����.���ֱ�.ContainsKey(2))
            {
                if (�Ҿ�.��.Length < 2)
                {
                    string �� = ���ݿ�.�ֱ�[UnityEngine.Random.Range(0,���ݿ�.�ֱ�.Length)];
                    �Ҿ�.�� = �� + �Ҿ�.��;
                    ̫�����.���ֱ�.Add(2, new �ֱ�(�ֱ�����.��һ����,��));
                }
                else ̫�����.���ֱ�.Add(2,new �ֱ�(�ֱ�����.��һ����,�Ҿ�.��.Substring(0,1)));
            }
            �Ҿ�.���� = �ְ�.����;
            �Ҿ�.���� = �ְ�.����;
            �Ҿ�.�������();
            �Ҿ�.���� = �ְ�.���;
            �ְ�.����.Add(�Ҿ�.���);
            �Ҿ�.�游 = үү.���;
            �Ҿ�.��ĸ = үү.���;
            if (�ְ�.���.Count > 0 && UnityEngine.Random.Range(0, 100) > 60)
            {
                int ��ұ�� = �ְ�.���[UnityEngine.Random.Range(0, �ְ�.���.Count)];
                �Ҿ�.ĸ�� = ��ұ��;
                NPCManager.Instance.��������[��ұ��].����.Add(�Ҿ�.���);
                �Ҿ�.���� = "��";
            }
            else
            {
                �Ҿ�.ĸ�� = �ְ�.����;
                NPCManager.Instance.��������[�ְ�.����].����.Add(�Ҿ�.���);
            }
            ̫�����.�����Ա.Add(�Ҿ�.���);

            �ְ�.����.Add(�Ҿ�.���);
            NPCManager.Instance.��������[�ְ�.����].����.Add(�Ҿ�.���);
            if (�Ҿ�.�Ա� == "Ů")
            {
                �ְ�.Ů������++;
                үү.��Ů����++;
            }
            else if (�Ҿ�.�Ա� == "��")
            {
                �ְ�.��������++;
                үү.��������++;
            }
        }
        ̫�����.������ += ��ϵ����.��ȡ��������ֵ(����);
        ̫�����.������ += UnityEngine.Random.Range(50,80);//̫������ֵ
        ̫�����.��͢���� += ��ϵ����.��ȡ��Ա����ֵ(�ְ�);
        ̫�����.��͢���� += ��ϵ����.��ȡ��Ա����ֵ(үү);
        ̫�����.������ֵ += ̫�����.��͢���� + ̫�����.������;
    }
    #region δʵװ
    public void ��ʼ��������()
    {
        if (�м����.Instance.̫�����Ӽ���ͳһ != -1)
        {
            ̫����������();
        }
        #region ���Ӽ�������
        for (int i = 0; i < 4; i++)
        {
            string[] �����Ա� = { "��", "Ů" };
            int �������� = UnityEngine.Random.Range(0, 5);
            int ���ӱ�� = NPCManager.Instance.�����б�[i];
            ���� ���� = (����)NPCManager.Instance.��������[���ӱ��];
            if (���ӱ�� == �м����.Instance.̫�����Ӽ���ͳһ) continue;

            �� �ְ� = (��)NPCManager.Instance.�����������("��", "��");
            �ְ�.�� = ����.��; �ְ�.���� = ����.����; �ְ�.���� = ����.����;
            �ְ�.����.Add(����.���);
            �ְ�.Ů������ = 1;
            ��ְ����.Instance.��ʼ��ְ����(�ְ�, 1, 7);
            if (�ְ�.���� == -1)
            {
                �Ҿ� ĸ�� = (�Ҿ�)NPCManager.Instance.�����������("�Ҿ�", "Ů");
                ĸ��.���� = �ְ�.���� - UnityEngine.Random.Range(0, 3);
                ĸ��.�������();
                �ְ�.���� = ĸ��.���;
            }
            ����.ĸ�� = �ְ�.����;
            ����.���� = �ְ�.���;
            �������� = UnityEngine.Random.Range(0, 3);
            for (int j = 0; j < ��������; j++)
            {
                string �Ա� = �����Ա�[UnityEngine.Random.Range(0, 2)];
                �Ҿ� �Ҿ� = (�Ҿ�)NPCManager.Instance.�����������("�Ҿ�", �Ա�);
                �Ҿ�.���� = ����.���� + UnityEngine.Random.Range(-5, 5);
                �Ҿ�.�������();
                �Ҿ�.�� = �ְ�.��;
                �Ҿ�.���� = �ְ�.����;
                �Ҿ�.���� = �ְ�.����;
                �Ҿ�.���� = �ְ�.���;
                �Ҿ�.ĸ�� = �ְ�.����;
                �ְ�.����.Add(�Ҿ�.���);
                NPCManager.Instance.��������[�ְ�.����].����.Add(�Ҿ�.���);
                if (�Ҿ�.�Ա� == "Ů")
                {
                    �ְ�.Ů������++;
                }
                else if (�Ҿ�.�Ա� == "��")
                {
                    �ְ�.��������++;
                }
            }
            if (!�������.Instance.���м���.ContainsKey(����.����))
            {
                ���� ���Ӽ��� = new ����(����.����);
                ���Ӽ���.����Ա.Add(�ְ�.���);
                ���Ӽ���.������ = ����.����;
                �������.Instance.���м���[����.����] = ���Ӽ���;
            }
            #endregion
        }
    }

    #endregion
    public void ɾ������(int ���)
    {
        if (��� < 0 || ��� > NPCManager.Instance.��������.Count) return;
        NPC npc = NPCManager.Instance.��������[���];
        if (npc.���� == "��") ���б�.RemoveAll(x => x == ���);
        else if (npc.���� == "����") {
            if (npc.��� == ��Ϸ�趨.Instance.Э��������) ��Ϸ�趨.Instance.Э�������� = -1;
            �����б�.RemoveAll(x => x == ���);
        }
        else if (npc.���� == "̫��") ̫���б�.RemoveAll(x => x == ���);
        else if (npc.���� == "����") �����б�.RemoveAll(x => x == ���);
        if(npc.����!=-1)
        {
            NPCManager.Instance.��������[npc.����].���� = -1;
        }
        if(npc.����!=-1)
        {
            NPCManager.Instance.��������[npc.����].����.RemoveAll(x => x == ���);
            if (npc.�Ա� == "Ů") NPCManager.Instance.��������[npc.����].Ů������--;
            else NPCManager.Instance.��������[npc.����].��������--;
            if (NPCManager.Instance.��������[npc.����].����!=-1)
            {
                int �游��� = NPCManager.Instance.��������[npc.����].����;
                if(npc.�Ա�=="Ů") NPCManager.Instance.��������[�游���].��Ů����--;
                else if (npc.�Ա� == "��") NPCManager.Instance.��������[�游���].��������--;
            }
        }
        if(npc.ĸ��!=-1)
        {
            NPCManager.Instance.��������[npc.ĸ��].����.RemoveAll(x => x == ���);
            if (npc.�Ա� == "Ů") NPCManager.Instance.��������[npc.ĸ��].Ů������--;
            else NPCManager.Instance.��������[npc.ĸ��].��������--;
        }
        for(int i = 0; i < npc.����.Count; i++)
        {
            NPC ���� = NPCManager.Instance.��������[npc.����[i]];
            if (npc.�Ա� == "Ů") ����.ĸ�� = -1;
            else ����.���� = -1;
        }
        if (�������.Instance.���м���.ContainsKey(npc.����))
        {
            ���� ���� = �������.Instance.���м���[npc.����];
            if(npc.����=="��")
            {

            }
            else if(npc.����=="̫��"||npc.����=="����")
            {
                ����.�󹬳�Ա.Remove(npc.���);
            }
            ����.�����Ա.Remove(npc.���);
        }
        if (��� == �м����.Instance.̫�����Ӽ���ͳһ) �м����.Instance.̫�����Ӽ���ͳһ = -1;
        if(��� == ��Ϸ�趨.Instance.̫��)  ��Ϸ�趨.Instance.̫�� = -1;
        ��������.Remove(���);
        �м����.Instance.dl(npc.���);
    }

    public void ���ڼ���()
    {
        for (int i = 0; i < NPCManager.Instance.��������.Count; ++i)
        {
            NPC npc = NPCManager.Instance.��������[i];
            if (npc.�����ж� == true) continue;
            if (npc.�� > 1)
                npc.�� -= 1;
            else if (npc.�� == 1) npc.���ӳ���();
        }
    }
}
