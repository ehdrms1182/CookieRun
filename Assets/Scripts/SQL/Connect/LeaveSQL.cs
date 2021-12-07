using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class LeaveSQL : MonoBehaviour
{
    [SerializeField]
    public Text id;
    [SerializeField]
    public InputField pw;
    [SerializeField]
    public InputField cpw;

    
    public void IsClicked(){
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/" + "/NetworkProgrammingB.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = null;
        sqlQuery = "SELECT UserID, Password from UserInfo ";// 테이블 이름
        sqlQuery += "WHERE UserID = '"+id.text+"'";

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        string SearchId = null;
        string SearchPW = null;
        while(reader.Read()){
            SearchId = reader.GetString(0);
            SearchPW = reader.GetString(1);
            Debug.Log(SearchId);
            Debug.Log(SearchPW);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        if(SearchId != id.text){
            Debug.Log(id.text+"이(가) 존재하지 않습니다");
        }
        else if(SearchPW != pw.text){
            Debug.Log("비밀번호가 일치하지 않습니다");
        }
        else if(SearchId == id.text && pw.text == cpw.text)
        {
            IDbConnection sql;
            sql = (IDbConnection) new SqliteConnection(conn);
            sql.Open();

            IDbCommand dbcmdd = sql.CreateCommand();
            string Query;
            Query = " DELETE FROM UserInfo ";// 테이블 이름
            Query += " WHERE UserID = '"+id.text+"'";

            dbcmdd.CommandText = Query;
            dbcmdd.ExecuteNonQuery();

            dbcmdd.Dispose();
            dbcmdd = null;
            sql.Close();
            sql = null;
            Debug.Log("계정을 삭제했습니다!");
        }
    } 
}
