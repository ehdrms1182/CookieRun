using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBAccess : MonoBehaviour
{
    void Awake()
    {
        // conn = "URI=file:" + Application.dataPath + "/DB Browser�� ���� �����ͺ��̽� �̸�.s3db";
        string conn = "URI=file:" + Application.dataPath + "/BoxDB.db";

        // IDbConnection
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        // IDbCommand
        IDbCommand dbcmd = dbconn.CreateCommand();
        // sql���� = "SELECT ��ȸ�� �÷� FROM ��ȸ�� ���̺�";
        string sqlQuery = "SELECT Box_id,Box_name FROM BOX";
        dbcmd.CommandText = sqlQuery;

        // IDataReader
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            // ����Ÿ���� �÷� ������ Ÿ�Կ� ���߸� �ȴ�.
            int Box_id = reader.GetInt32(0);
            string Box_name = reader.GetString(1);

            Debug.Log("Box_id= " + Box_id + " Box_name =" + Box_name);
        }
        // �ݾ��ְ� �ʱ�ȭ �����ִ� ��
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }   
}

