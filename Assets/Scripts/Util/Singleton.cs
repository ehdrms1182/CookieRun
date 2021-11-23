using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �̱��� ���̽� Ŭ����
/// </summary>
/// <typeparam name="T">Singleton<T>�� ��ӹ޴� Ÿ��</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    /// <summary>
    /// �̱��� �ν��Ͻ��� ã�ų� �����ϴ� ���� �� �ٸ� �����忡�� ��������� �Ǵ��� ��ü
    /// </summary>
    private static object syncObject = new object();

    /// <summary>
    /// T Ÿ�� �ν��Ͻ� ��ü
    /// </summary>
    protected static T instance;

    /// <summary>
    /// �ܺο��� �ν��Ͻ� ��ü�� �����ϱ� ���� ������Ƽ
    /// </summary>
    public static T Instance
    {
        get
        {
            // �ν��Ͻ��� ���ٸ�
            if (instance == null)
            {
                // lock�� ���� ����ȭ ������ �Ϲ������� ����Ƽ�� �̱� ������ ȯ�濡���� ���������, 
                // ��Ƽ ������ ȯ�濡�� �̱��� �ʱ�ȭ ������ ������ �������ϰ� �ϱ� ���� 
                // (�� ���� �� �ʱ�ȭ ������ �����ϰ� �� ���Ĵ� ������ ���������� �ʴٴ� ��)
                // �ν��Ͻ��� ã�ų� �����ϴ� ������ ���� ���� �� �ٸ� �����忡��
                // ������ ������ ������ �� ���� ���� �Ǵ� (��� ���̶�� ���� ������ ����ϰ� ��)
                lock (syncObject)
                {
                    // �ν��Ͻ��� ã�´�
                    instance = FindObjectOfType<T>();
                    // �˻������� �ν��Ͻ��� ���ٸ�
                    if (instance == null)
                    {
                        // �ν��Ͻ��� ���� ����
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
            }
            // ���� ������ ���� �ν��Ͻ��� �ִٸ� �״�� ��ȯ
            // ���ٸ� ã�ų� ���� �����ؼ� ��ȯ
            return instance;
        }
    }

    protected virtual void Awake()
    {
        lock (syncObject)
        {
            // ��븦 ��ӹ޾����Ƿ� ��� ��ü�� �ʱ�ȭ�� ������ ��
            // Awake�� �ڵ������� ȣ��Ǵµ� �� �� �˻縦 ���� �ν��Ͻ��� ���ٸ� �̸� �־�д�
            // �̷��� ������� Instance ������Ƽ ���� �� ���ʿ��� �˻� ������ �ִ��� �����Ѵ�
            if (instance == null)
            {
                instance = this as T;
            }
            // ���� �� �� �ν��Ͻ��� �����Ѵٸ� ��ü�� �ʱ�ȭ �Ǳ����� �ش� �ν��Ͻ��� �����Ͽ��ٴ� ��
            // �ش� Ŭ������ ��븦 ��ӹ޾Ұ� �Ϲ������� ��(���̾��Ű)�� �÷��� �����
            // �׷� �� �� �ν��Ͻ��� �����Ѵٴ� ���� ���� �÷��� �ν��Ͻ��� �ʱ�ȭ�Ǳ� ����
            // Ÿ Ŭ�������� �̱������� �ش� Ŭ������ �����Ͽ� ������ �ν��Ͻ��� �߰������� �����Ǿ��ٴ� �ǹ�
            // ����, �߰��� ������ �ν��Ͻ��� �����ϰ� ���� ���� ��ġ�� �̱����� �۵��� �� �ֵ��� �Ѵ�
            else
            {
                Destroy(instance);
            }
        }
    }

    private void OnDestroy()
    {
        lock (syncObject)
        {
            if (instance != this)
                return;

            instance = null;
        }
    }
}