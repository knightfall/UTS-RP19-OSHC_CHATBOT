using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ScheduleParser
{
    class Program
    {
       /// <summary>
       /// Parse XML FILE, DESERIALIZE it
       /// parallel foreach stores the data into a mysqldb table. Shouldn't take more than 90 seconds with 1.5mbps up
       /// IF Department of Health changes the structure of the xml file, use xsd.exe to generate a new ScheduleClass.cs based on the updated xml file
       /// </summary>
       /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            XElement file = XElement.Load(@"../../../../schedule/201905-XML.xml");
            XElement.Parse(file.ToString());
            XmlSerializer serializer  = new XmlSerializer(typeof(MBS_XML));
            MBS_XML reMbsXml = (MBS_XML) serializer.Deserialize(new XmlTextReader(@"../../../../schedule/201905-XML.xml"));
            Program p = new Program();
            Stopwatch stopwatch = new Stopwatch();
            MBS_XMLData[] td = reMbsXml.Items;
            stopwatch.Start();
            Parallel.ForEach(td, data =>
            {
                p.InserData(data);
                Console.WriteLine($"{stopwatch.Elapsed.ToString()} has elapsed");
            });

            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine($"{stopwatch.Elapsed.ToString()} has elapsed");
            stopwatch.Stop();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        public string NullCheck(string x)
        {
            return (x == null)||(x.Length ==0) ? "0" : x;
        }

        public string DConvert(string y)
        {
            return (y=="")|| (y==null) ? "1970-01-01" : Convert.ToDateTime(y).ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// Parameterized query. Reduces risk of SQL injection.
        /// Not relevant but still it is good to know
        /// you can use ENTITY FRAMEWORK to reduce code size
        /// </summary>
        /// <param name="mBS_XMLData"></param>
        /// <returns></returns>
        public int InserData(MBS_XMLData mBS_XMLData)
        {

            string _servername = "xx.xx.xx.xx";
            string _id = "root";
            string _password = "*****";
            string _catalog = "mbs";

            string constring = String.Format(@"server={0};
    userid={1};
    password={2};
    database={3}", _servername, _id, _password, _catalog);
            MySqlConnection c = new MySqlConnection(constring);

            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO `mbs`.`schedule`(`ItemNum`,`SubItemNum`,`ItemStartDate`,`ItemEndDate`,`Category`,`Group`,`SubGroup`,`SubHeading`,`ItemType`,`FeeType`,`ProviderType`,`NewItem`,`ItemChange`,`AnaesChange`,`DescriptorChange`,`FeeChange`,`EMSNChange`,`EMSNCap`,`BenefitType`,`BenefitStartDate`,`FeeStartDate`,`ScheduleFee`,`Benefit75`,`Benefit85`,`Benefit100`,`Basic Units`,`EMSNStartDate`,`EMSNEndDate`,`EMSNFixedCapAmount`,`EMSNPercentageCap`,`EMSNMaximumCap`,`EMSNDescription`,`EMSNChangeDate`,`DerivedFeeStartDate`,`DerivedFee`,`Anaes`,`DescriptionStartDate`,`Description`,`QFEStartDate`,`QFEEndDate`)VALUES(@ItemNum,@SubItemNum,@ItemStartDate,@ItemEndDate,@Category,@Group,@SubGroup,@SubHeading,@ItemType,@FeeType,@ProviderType,@NewItem,@ItemChange,@AnaesChange,@DescriptorChange,@FeeChange,@EMSNChange,@EMSNCap,@BenefitType,@BenefitStartDate,@FeeStartDate,@ScheduleFee,@Benefit75,@Benefit85,@Benefit100,@BasicUnits,@EMSNStartDate,@EMSNEndDate,@EMSNFixedCapAmount,@EMSNPercentageCap,@EMSNMaximumCap,@EMSNDescription,@EMSNChangeDate,@DerivedFeeStartDate,@DerivedFee,@Anaes,@DescriptionStartDate,@Description,@QFEStartDate,@QFEEndDate)");
            MySqlParameter p1 = new MySqlParameter("@ItemNum", MySqlDbType.VarChar);
            p1.Value = NullCheck(mBS_XMLData.ItemNum);
            MySqlParameter p2 = new MySqlParameter("@SubItemNum", MySqlDbType.VarChar);
            p2.Value = NullCheck(mBS_XMLData.SubItemNum);
            MySqlParameter p3 = new MySqlParameter("@ItemStartDate", MySqlDbType.VarChar);
            p3.Value = DConvert(mBS_XMLData.ItemStartDate);
            MySqlParameter p4 = new MySqlParameter("@ItemEndDate", MySqlDbType.VarChar);
            p4.Value = DConvert(mBS_XMLData.ItemEndDate);
            MySqlParameter p5 = new MySqlParameter("@Category", MySqlDbType.VarChar);
            p5.Value = mBS_XMLData.Category;
            MySqlParameter p6 = new MySqlParameter("@Group", MySqlDbType.VarChar);
            p6.Value = mBS_XMLData.Group;
            MySqlParameter p7 = new MySqlParameter("@SubGroup", MySqlDbType.VarChar);
            p7.Value = mBS_XMLData.SubGroup;
            MySqlParameter p8 = new MySqlParameter("@SubHeading", MySqlDbType.VarChar);
            p8.Value = mBS_XMLData.SubHeading;
            MySqlParameter p9 = new MySqlParameter("@ItemType", MySqlDbType.VarChar);
            p9.Value = mBS_XMLData.ItemType;
            MySqlParameter p10 = new MySqlParameter("@FeeType", MySqlDbType.VarChar);
            p10.Value = mBS_XMLData.FeeType;
            MySqlParameter p11 = new MySqlParameter("@ProviderType", MySqlDbType.VarChar);
            p11.Value = mBS_XMLData.ProviderType;
            MySqlParameter p12 = new MySqlParameter("@NewItem", MySqlDbType.VarChar);
            p12.Value = mBS_XMLData.NewItem;
            MySqlParameter p13 = new MySqlParameter("@ItemChange", MySqlDbType.VarChar);
            p13.Value = mBS_XMLData.ItemChange;
            MySqlParameter p14 = new MySqlParameter("@AnaesChange", MySqlDbType.VarChar);
            p14.Value = mBS_XMLData.AnaesChange;
            MySqlParameter p15 = new MySqlParameter("@DescriptorChange", MySqlDbType.VarChar);
            p15.Value = mBS_XMLData.DescriptorChange;
            MySqlParameter p16 = new MySqlParameter("@FeeChange", MySqlDbType.VarChar);
            p16.Value = mBS_XMLData.FeeChange;
            MySqlParameter p17 = new MySqlParameter("@EMSNChange", MySqlDbType.VarChar);
            p17.Value = mBS_XMLData.EMSNChange;
            MySqlParameter p18 = new MySqlParameter("@EMSNCap", MySqlDbType.VarChar);
            p18.Value = mBS_XMLData.EMSNCap;
            MySqlParameter p19 = new MySqlParameter("@BenefitType", MySqlDbType.VarChar);
            p19.Value = mBS_XMLData.BenefitType;
            MySqlParameter p20 = new MySqlParameter("@BenefitStartDate", MySqlDbType.VarChar);
           p20.Value = DConvert(mBS_XMLData.BenefitStartDate) ;
            MySqlParameter p21 = new MySqlParameter("@FeeStartDate", MySqlDbType.VarChar);
            p21.Value = DConvert(mBS_XMLData.FeeStartDate);
            MySqlParameter p22 = new MySqlParameter("@ScheduleFee", MySqlDbType.VarChar);
            p22.Value = NullCheck(mBS_XMLData.ScheduleFee);
            MySqlParameter p23 = new MySqlParameter("@Benefit75", MySqlDbType.VarChar);
            p23.Value = NullCheck(mBS_XMLData.Benefit75);
            MySqlParameter p24 = new MySqlParameter("@Benefit85", MySqlDbType.VarChar);
            p24.Value = NullCheck(mBS_XMLData.Benefit85);
            MySqlParameter p25 = new MySqlParameter("@Benefit100", MySqlDbType.VarChar);
            p25.Value = NullCheck(mBS_XMLData.Benefit100);
            MySqlParameter p26 = new MySqlParameter("@BasicUnits", MySqlDbType.VarChar);
            p26.Value = NullCheck(mBS_XMLData.BasicUnits);
            MySqlParameter p27 = new MySqlParameter("@EMSNStartDate", MySqlDbType.VarChar);
            p27.Value = DConvert(mBS_XMLData.EMSNStartDate);
            MySqlParameter p28 = new MySqlParameter("@EMSNEndDate", MySqlDbType.VarChar);
            p28.Value = DConvert(mBS_XMLData.EMSNEndDate);
            MySqlParameter p29 = new MySqlParameter("@EMSNFixedCapAmount", MySqlDbType.VarChar);
            p29.Value = NullCheck(mBS_XMLData.EMSNFixedCapAmount);
            MySqlParameter p30 = new MySqlParameter("@EMSNPercentageCap", MySqlDbType.VarChar);
            p30.Value = NullCheck(mBS_XMLData.EMSNPercentageCap);
            MySqlParameter p31 = new MySqlParameter("@EMSNMaximumCap", MySqlDbType.VarChar);
            p31.Value = NullCheck(mBS_XMLData.EMSNMaximumCap);
            MySqlParameter p32 = new MySqlParameter("@EMSNDescription", MySqlDbType.VarChar);
            p32.Value = mBS_XMLData.EMSNDescription;
            MySqlParameter p33 = new MySqlParameter("@EMSNChangeDate", MySqlDbType.VarChar);
            p33.Value = DConvert(mBS_XMLData.EMSNChangeDate);
            MySqlParameter p34 = new MySqlParameter("@DerivedFeeStartDate", MySqlDbType.VarChar);
            p34.Value = DConvert(mBS_XMLData.DerivedFeeStartDate);
            MySqlParameter p35 = new MySqlParameter("@DerivedFee", MySqlDbType.VarChar);
            p35.Value = mBS_XMLData.DerivedFee;
            MySqlParameter p36 = new MySqlParameter("@Anaes", MySqlDbType.VarChar);
            p36.Value = mBS_XMLData.Anaes;
            MySqlParameter p37 = new MySqlParameter("@DescriptionStartDate", MySqlDbType.VarChar);
            p37.Value = DConvert(mBS_XMLData.DescriptionStartDate);
            MySqlParameter p38 = new MySqlParameter("@Description", MySqlDbType.VarChar);
            p38.Value = mBS_XMLData.Description;
            MySqlParameter p39 = new MySqlParameter("@QFEStartDate", MySqlDbType.VarChar);
            p39.Value = DConvert(mBS_XMLData.QFEStartDate);
            MySqlParameter p40 = new MySqlParameter("@QFEEndDate", MySqlDbType.VarChar);
            p40.Value = DConvert(mBS_XMLData.QFEEndDate);

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
            cmd.Parameters.Add(p8);
            cmd.Parameters.Add(p9);
            cmd.Parameters.Add(p10);
            cmd.Parameters.Add(p11);
            cmd.Parameters.Add(p12);
            cmd.Parameters.Add(p13);
            cmd.Parameters.Add(p14);
            cmd.Parameters.Add(p15);
            cmd.Parameters.Add(p16);
            cmd.Parameters.Add(p17);
            cmd.Parameters.Add(p18);
            cmd.Parameters.Add(p19);
            cmd.Parameters.Add(p20);
            cmd.Parameters.Add(p21);
            cmd.Parameters.Add(p22);
            cmd.Parameters.Add(p23);
            cmd.Parameters.Add(p24);
            cmd.Parameters.Add(p25);
            cmd.Parameters.Add(p26);
            cmd.Parameters.Add(p27);
            cmd.Parameters.Add(p28);
            cmd.Parameters.Add(p29);
            cmd.Parameters.Add(p30);
            cmd.Parameters.Add(p31);
            cmd.Parameters.Add(p32);
            cmd.Parameters.Add(p33);
            cmd.Parameters.Add(p34);
            cmd.Parameters.Add(p35);
            cmd.Parameters.Add(p36);
            cmd.Parameters.Add(p37);
            cmd.Parameters.Add(p38);
            cmd.Parameters.Add(p39);
            cmd.Parameters.Add(p40);
            c.Open();
            cmd.Connection = c;
            var test = cmd.ExecuteNonQuery();
            c.Close();

            //count++;
           // Console.WriteLine("Finished item: ",count);

            return test;
        }
    }

   

}

