using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBAccess : MonoBehaviour
{
    void Start()
    {
        DBCalling();
    }
    void DBCalling()
    {
        Debug.Log("����");
        // conn = "URI=file:" + Application.dataPath + "/DB Browser�� ���� �����ͺ��̽� �̸�.db";
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/" + "/NetworkProgrammingB.db";
        // IDbConnection
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        // IDbCommand
        IDbCommand dbcmd = dbconn.CreateCommand();
        // sql���� = "SELECT ��ȸ�� �÷� FROM ��ȸ�� ���̺�";
        string sqlQuery = "SELECT UserId, Password FROM UserInfo";
        dbcmd.CommandText = sqlQuery;

        // IDataReader
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            // ����Ÿ���� �÷� ������ Ÿ�Կ� ���߸� �ȴ�.
            string UserID = reader.GetString(0);
            string Password = reader.GetString(1);
            Debug.Log("���� ����");
            Debug.Log($"UserID = {UserID} + Password = {Password}");
        }
        // �ݾ��ְ� �ʱ�ȭ �����ִ� ��
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        Debug.Log("�ʱ�ȭ ����");
    }
}