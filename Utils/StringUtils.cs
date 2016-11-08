///----------------------------------------------------------------------------------
///   Namespace:      <StringUtils>
///   Class:          <CheckUnwantedConnectedProcess>
///   Description:    <This Class is used to extract the Current Connected process>
///   Author:         <Preetam Ramdhave>                    Date: <7-OCT-2016>
///   Notes:          <This is string utility class. This class is used for 
///                    Refining the data extracted by netstat. >
///   Revision History:
///   Name:           Date:        Description:
///----------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class StringUtils
    {
        /// <summary>
        /// This code is for refining the data form the netstat value. 
        /// this function will refine the text and create a sensable value from the given text. 
        /// </summary>
        /// <param name="TextValue"></param>
        public string GenrateQuamaSeprated(StringBuilder TextValue)
        {
            #region Function Variables
            DataTable NetworkDataTable = new DataTable();
            NetworkDataTable.TableName = "ActiveConnections";
            bool isSpaceFound = false;
            StringBuilder refineString = new StringBuilder();

            #endregion

            isSpaceFound = CreateDataQuamaSeprated(TextValue, isSpaceFound, refineString);
            BuildNetworkDataTable(NetworkDataTable, refineString);

            return TextValue.ToString();
        }
        /// <summary>
        /// This funciton builds Network data table by refining the string data. 
        /// might need to upgrade in case of new network protocol 
        /// currently it supports only tcp and UDP protocol
        /// </summary>
        /// <param name="NetworkDataTable"> by ref variable will use this to populate the data in the table. </param>
        /// <param name="refineString">the string which contain the data about the currect pc model. </param>
        private static void BuildNetworkDataTable(DataTable NetworkDataTable, StringBuilder refineString)
        {
            string completeString = refineString.Replace(" ", "").Replace("TCP", "\nTCP").Replace("UDP", "\nUDP").ToString();
            string[] valu1 = completeString.Split('\n');
            var valu2 = valu1.Where(x => x != "");
            bool colName = true;
            foreach (var item in valu2)
            {
                if (colName)
                {
                    var getColName = item.Split(',');

                    NetworkDataTable.Columns.Add("Proto");
                    NetworkDataTable.Columns.Add("Local Address");
                    NetworkDataTable.Columns.Add("Foreign Address");
                    NetworkDataTable.Columns.Add("State");
                    NetworkDataTable.Columns.Add("PID");
                    colName = false;
                }
                else
                {
                    var getColName = item.Split(',');
                    DataRow drow = NetworkDataTable.NewRow();
                    if (getColName.Length == 6)
                    {
                        drow[0] = getColName[0].ToString();
                        drow[1] = getColName[1].ToString();
                        drow[2] = getColName[2].ToString();
                        drow[3] = getColName[3].ToString();
                        drow[4] = getColName[4].ToString();
                    }
                    if (getColName.Length == 5)
                    {
                        if (getColName[0] == "UDP" && getColName[4] == "")
                        {
                            drow[0] = getColName[0].ToString();
                            drow[1] = getColName[1].ToString();
                            drow[2] = getColName[2].ToString();
                            drow[3] = getColName[4].ToString();
                            drow[4] = getColName[3].ToString();
                        }
                        else
                        {
                            drow[0] = getColName[0].ToString();
                            drow[1] = getColName[1].ToString();
                            drow[2] = getColName[2].ToString();
                            drow[3] = getColName[3].ToString();
                            drow[4] = getColName[4].ToString();
                        }

                    }
                    if (getColName.Length == 4)
                    {
                        drow[0] = getColName[0].ToString();
                        drow[1] = getColName[1].ToString();
                        drow[2] = getColName[2].ToString();
                        drow[4] = getColName[3].ToString();

                    }
                    NetworkDataTable.Rows.Add(drow);
                }

            }
        }

        /// <summary>
        /// When we fetch data it is row string and need to refine the string. 
        /// we remove the space and put quama. then also add the new line charactor. 
        /// by doing this we can get the data properly to convert in the table. 
        /// </summary>
        /// <param name="TextValue"></param>
        /// <param name="isSpaceFound"></param>
        /// <param name="refineString"></param>
        /// <returns></returns>
        private static bool CreateDataQuamaSeprated(StringBuilder TextValue, bool isSpaceFound, StringBuilder refineString)
        {
            foreach (var item in TextValue.ToString())
            {
                if (!isSpaceFound)
                {
                    if (item == ' ')
                    {
                        refineString.Append(',');
                        isSpaceFound = true;
                    }
                    else
                    {
                        refineString.Append(item);
                    }
                }
                else
                {
                    refineString.Append(item);
                }
                if (item != ' ' && isSpaceFound)
                {
                    isSpaceFound = false;
                }
            }

            return isSpaceFound;
        }
    }
}
