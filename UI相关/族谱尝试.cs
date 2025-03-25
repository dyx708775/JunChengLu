using UnityEngine;
using UnityEngine.UI;

public class FamilyTree : MonoBehaviour
{
    public GameObject prefabToInstantiate; // 要实例化的预制体
    public RectTransform panelRectTransform; // Panel的RectTransform组件引用
    public GameObject lineRendererPrefab; // LineRenderer预制体

    private Vector2 rightSpeed = new Vector2(-500, 0); // 移动速度和方向
    private Vector2 leftSpeed = new Vector2(500, 0);

    void Start()
    {
        // 实例化预制体
        InstantiatePrefabAtPosition(prefabToInstantiate, new Vector2(2000, 1000),"haha");
        InstantiatePrefabAtPosition(prefabToInstantiate, Vector2.zero,"heihei");

        // 连接节点
        ConnectNodes();
    }

    void Update()
    {
        HandleKeyboardInput();
        HandleMouseInput();
    }

    void HandleKeyboardInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovePanel(rightSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovePanel(leftSpeed * Time.deltaTime);
        }
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CenterPrefabOnPanel("haha");
        }
    }

    GameObject InstantiatePrefabAtPosition(GameObject prefab, Vector2 position,string name)
    {
        GameObject instance = Instantiate(prefab, position, Quaternion.identity);
        instance.transform.SetParent(panelRectTransform, false);
        instance.name = name;

        return instance;
    }

    void MovePanel(Vector2 deltaPosition)
    {
        panelRectTransform.anchoredPosition += deltaPosition;
    }

    void CenterPrefabOnPanel(string prefabName)
    {
        GameObject targetPrefab = GameObject.Find(prefabName);
        if (targetPrefab == null)
        {
            Debug.LogError("找不到指定的预制体实例: " + prefabName);
            return;
        }

        RectTransform targetRect = targetPrefab.GetComponent<RectTransform>();

        Vector2 currentPrefabPosition = targetRect.anchoredPosition;
        Vector2 panelCenter = panelRectTransform.sizeDelta / 2;
        Vector2 moveToCenterOffset = panelCenter - currentPrefabPosition;

        MovePanel(moveToCenterOffset);
    }

    void ConnectNodes()
    {
        // 示例节点位置
        Vector2[] positions = new Vector2[]
        {
            new Vector2(1500, 0),
            new Vector2(2000, 0)
        };

        // 连接节点
        for (int i = 0; i < positions.Length - 1; i++)
        {
            GameObject lineInstance = Instantiate(lineRendererPrefab, positions[i], Quaternion.identity);
            lineInstance.transform.SetParent(panelRectTransform, false);
            LineRenderer lineRenderer = lineInstance.GetComponent<LineRenderer>();
            lineRenderer.useWorldSpace = false;
            lineRenderer.SetPosition(0, positions[i]);
            lineRenderer.SetPosition(1, positions[i + 1]);
        }
    }
}