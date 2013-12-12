using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;

/// <summary>
/// Summary description for TunnitDAL
/// </summary>
public class TunnitDAL
{
    string strFileName = string.Empty;

    public TunnitDAL()
    {

        // Getting the XML file name at the initialization
        strFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["LogFilePath3"] );
    }

    /// <summary>
    /// This method is used for creating a new employee information in XML file
    /// </summary>
    /// <param name="employee">employee object</param>
    /// <returns>True - Success, False - Failure</returns>
    public bool Create(BLTunnit tunti)
    {
        try
        {
            // Checking if the file exist
            if (!File.Exists(strFileName))
            {
                // If file does not exist in the database path, create and store an empty tuntit node
                XmlTextWriter textWritter = new XmlTextWriter(strFileName, null);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("Tunnit");
                textWritter.WriteEndElement();
                textWritter.Close();
            }

            // Create the XML document by loading the file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFileName);

            // Creating tunti node
            XmlElement subNode = xmlDoc.CreateElement("Tunti");

            // Getting the maximum Id based on the XML data already stored
            string strId = CommonMethods.GetMaxValue(xmlDoc, "Tunnit" + "/" + "Tunti" + "/" + "id").ToString();

            // Adding Id column. tunti generated column
            subNode.AppendChild(CommonMethods.CreateXMLElement(xmlDoc, "id", strId));
            xmlDoc.DocumentElement.AppendChild(subNode);

            subNode.AppendChild(CommonMethods.CreateXMLElement(xmlDoc, "koodaaja", tunti.koodaaja));
            xmlDoc.DocumentElement.AppendChild(subNode);

            subNode.AppendChild(CommonMethods.CreateXMLElement(xmlDoc, "paivamaara", tunti.paivamaara));
            xmlDoc.DocumentElement.AppendChild(subNode);

            subNode.AppendChild(CommonMethods.CreateXMLElement(xmlDoc, "tuntimaara", tunti.tuntimaara));
            xmlDoc.DocumentElement.AppendChild(subNode);

            subNode.AppendChild(CommonMethods.CreateXMLElement(xmlDoc, "minuutit", tunti.minuutit));
            xmlDoc.DocumentElement.AppendChild(subNode);

            // Saving the file after adding the new tunti node
            xmlDoc.Save(strFileName);

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool Update(BLTunnit tunti)
    {

        try
        {
            if (File.Exists(strFileName))
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.Load(strFileName);

                // Getting a particular tunti by selecting using Xpath query
                XmlNode node = objXmlDocument.SelectSingleNode("//tunti[id='" + tunti.id + "']");

                if (node != null)
                {
                    // Assigning all the values
                    node.SelectNodes("id").Item(0).FirstChild.Value = tunti.id.ToString();
                    node.SelectNodes("koodaaja").Item(0).FirstChild.Value = tunti.koodaaja;
                    node.SelectNodes("paivamaara").Item(0).FirstChild.Value = tunti.paivamaara;
                    node.SelectNodes("tuntimaara").Item(0).FirstChild.Value = tunti.tuntimaara;
                    node.SelectNodes("minuutit").Item(0).FirstChild.Value = tunti.minuutit;
                }
                // Saving the file
                objXmlDocument.Save(strFileName);

                return true;
            }
            else
            {
                Exception ex = new Exception("Database file does not exist in the folder");
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool Delete(string id)
    {
        try
        {
            if (File.Exists(strFileName))
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.Load(strFileName);

                XmlNode node = objXmlDocument.SelectSingleNode("//tunti[id='" + id + "']");

                if (node != null)
                {
                    objXmlDocument.ChildNodes[1].RemoveChild(node);
                }
                objXmlDocument.Save(strFileName);

                return true;
            }
            else
            {
                Exception ex = new Exception("Database file does not exist in the folder");
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public IList<BLTunnit> GetAll()
    {
        try
        {
            if (File.Exists(strFileName))
            {
                // Loading the file into XPath document
                XPathDocument doc = new XPathDocument(strFileName);
                XPathNavigator nav = doc.CreateNavigator();

                XPathExpression exp = nav.Compile("/Tunnit/Tunti"); // Getting all tuntit

                // Sorting the records by id
                exp.AddSort("id", System.Xml.XPath.XmlSortOrder.Ascending, System.Xml.XPath.XmlCaseOrder.None, "", System.Xml.XPath.XmlDataType.Text);

                XPathNodeIterator iterator = nav.Select(exp);
                IList<BLTunnit> objtuntit = new List<BLTunnit>();

                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();

                    BLTunnit objtunti = new BLTunnit();
                    objtunti.id = Convert.ToInt64(nav2.Select("//tunti").Current.SelectSingleNode("id").InnerXml);
                    objtunti.koodaaja = nav2.Select("//tunti").Current.SelectSingleNode("koodaaja").InnerXml;
                    objtunti.paivamaara = nav2.Select("//tunti").Current.SelectSingleNode("paivamaara").InnerXml;
                    objtunti.tuntimaara = nav2.Select("//tunti").Current.SelectSingleNode("tuntimaara").InnerXml;
                    objtunti.minuutit = nav2.Select("//tunti").Current.SelectSingleNode("minuutit").InnerXml;
                   

                    objtuntit.Add(objtunti);
                }
                return objtuntit;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return null;
    }

    public BLTunnit Get(string id)
    {
        try
        {
            if (File.Exists(strFileName))
            {
                BLTunnit objtunti = new BLTunnit();

                XPathDocument doc = new XPathDocument(strFileName);
                XPathNavigator nav = doc.CreateNavigator();
                XPathNodeIterator iterator;

                iterator = nav.Select("//tunti[id='" + id + "']");

                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();

                    objtunti.id = Convert.ToInt64(nav2.Select("//tunti").Current.SelectSingleNode("id").InnerXml);
                    objtunti.koodaaja = nav2.Select("//tunti").Current.SelectSingleNode("koodaaja").InnerXml;
                    objtunti.paivamaara = nav2.Select("//tunti").Current.SelectSingleNode("paivamaara").InnerXml;
                    objtunti.tuntimaara = nav2.Select("//tunti").Current.SelectSingleNode("tuntimaara").InnerXml;
                    objtunti.minuutit = nav2.Select("//tunti").Current.SelectSingleNode("minuutit").InnerXml;
                }
                return objtunti;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return null;
    }
}