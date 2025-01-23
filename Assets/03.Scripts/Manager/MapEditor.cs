using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapEditor2))]
public class MapEditor : Editor
{
    SerializedProperty prefab; // SerializedProperty로 프리팹 관리

    private void OnEnable()
    {
        // MapEditor2의 prefab 필드와 연결
        prefab = serializedObject.FindProperty("prefab");
    }

    public override void OnInspectorGUI()
    {
        // SerializedObject 업데이트
        serializedObject.Update();

        // Prefab 필드 표시
        EditorGUILayout.PropertyField(prefab);

        // Prefab이 없을 때 경고 메시지 출력
        if (prefab.objectReferenceValue == null)
        {
            EditorGUILayout.HelpBox("Please assign a prefab to use this tool.", MessageType.Warning);
        }

        // SerializedObject 적용
        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        // Event 처리
        Event e = Event.current;

        // 마우스 좌클릭 이벤트 처리
        if (e.type == EventType.MouseDown )
        {
            // Raycast 생성
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                // 프리팹 생성
                CreatePrefab(hit.point);

                // 이벤트 사용 처리 (다른 이벤트 방지)
                e.Use();
            }
        }
    }

    private void CreatePrefab(Vector3 position)
    {
        // Prefab이 설정되지 않은 경우 종료
        if (prefab.objectReferenceValue == null)
        {
            Debug.LogError("Prefab is not assigned.");
            return;
        }

        // Prefab 생성
        GameObject newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab.objectReferenceValue);
        newObject.transform.position = position;

        // Undo 등록
        Undo.RegisterCreatedObjectUndo(newObject, "Create Prefab");

        // 생성된 오브젝트 선택
        Selection.activeGameObject = newObject;
    }
}