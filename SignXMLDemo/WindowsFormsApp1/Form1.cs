using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static string VerifyXML(string xmlstring)
        {
            string strRe = "";
            try
            {
                byte[] bytesconver = Encoding.UTF8.GetBytes(xmlstring);
                string filexmlexport = System.Text.Encoding.UTF8.GetString(bytesconver);
                XmlDocument doc = new XmlDocument();

                // Format the document to ignore white spaces.
                doc.PreserveWhitespace = true;

                // Load the passed XML file using it's name.
                doc.LoadXml(filexmlexport);

                bool b = CheckSignature(doc);
                strRe = b.ToString();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            Console.WriteLine("===============");
            Console.WriteLine(strRe);
            return strRe;
        }

       public static bool CheckSignature(XmlDocument xmlDoc)
        {
            SignedXml signedXml = new SignedXml(xmlDoc);
            XmlNodeList elementsByTagName = xmlDoc.GetElementsByTagName("Signature");
            signedXml.LoadXml((XmlElement)elementsByTagName[0]);


            bool sigCheck = signedXml.CheckSignature();

            return sigCheck;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VerifyXML("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><SalaryDeposit>    <Organisation>        <Name>DDLab Inc</Name>        <AccountNo>SBC-12345789</AccountNo>    </Organisation>    <Employees>        <Emp>            <Name>John Abraham</Name>            <AccountNo>SB-001</AccountNo>            <Amount>1234</Amount>        </Emp>        <Emp>            <Name>Bipasha Basu</Name>            <AccountNo>SB-002</AccountNo>            <Amount>2334</Amount>        </Emp>        <Emp>            <Name>Vidya Balan</Name>            <AccountNo>SB-003</AccountNo>            <Amount>3465</Amount>        </Emp>        <Emp>            <Name>Debadatta Mishra</Name>            <AccountNo>SB-007</AccountNo>            <Amount>5789</Amount>        </Emp>        <Emp>            <Name>Priti Zinta</Name>            <AccountNo>SB-009</AccountNo>            <Amount>1234</Amount>        </Emp>    </Employees><Signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\"><SignedInfo><CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"/><SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"/><Reference URI=\"\"><Transforms><Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\"/></Transforms><DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"/><DigestValue>bHS+6uf8KbJV4AGzoHNHLfnXvKM=</DigestValue></Reference></SignedInfo><SignatureValue>VissfFSpP7KipHYnVZa32wx5Od1Dw7sxb/bqv9fOSlATkcVK1uhGSbZKtZH9xRT75/s34tCPk1pA5lVcuxgNFi/v3lQuRORJqmt/hYWt2mRPnpbVE9yjv3WT9aOpMb09AHrLb4pHFFzcDWNKiu7QMJtcIBi///QeVi+Fl2M/FzU=</SignatureValue><KeyInfo><KeyValue><RSAKeyValue><Modulus>oFblPT/vyZrSgn6WNxO82kLYNbRMq45Hr7SV0G+ko/1wRtTMlrrZcbRZ0o6Mmx7IlWKXUsRTq3IiNXxNeyI99oMNW92yaoHRoC/c9M63JPfT+gG9hvMXqcTsvGKF1BdAj1Zxh7FTgnFTJrI3+B9JxW7boDMPyDbKL35L956DNbs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue></KeyValue></KeyInfo></Signature></SalaryDeposit>");
            //VerifyXML("<?xml version=\"1.0\" encoding=\"utf-8\"?><HDon Id=\"19KHCT\"><DLHDon Id=\"DLHDon\"><TTChung><PBan>1.0.0</PBan><THDon>Hóa đơn giá trị gia tăng</THDon><KHMSHDon>01GTKT0/001</KHMSHDon><KHHDon>VN/21E</KHHDon><SHDon>0000169</SHDon><TDLap>2021-05-28T15:05:22</TDLap><TChat>1</TChat><DVTTe>USD</DVTTe><TGia>23000.000000</TGia><TTKhac><TTin><TTruong>IvoiceCode</TTruong><KDLieu>String</KDLieu><DLieu>21HS000305N1</DLieu></TTin><TTin><TTruong>ConvertDate</TTruong><KDLieu>DateTime</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>GuideId</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>GuideCode</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>InvoiceType</TTruong><KDLieu>Int32</KDLieu><DLieu>1</DLieu></TTin><TTin><TTruong>InvoiceTypeType</TTruong><KDLieu>Int32</KDLieu><DLieu>1</DLieu></TTin></TTKhac></TTChung><NDHDon><NBan><Ten>TEST HÓA ĐƠN ĐIỆN TỬ VI NA</Ten><MST>0313032391</MST><DChi>Số 41A Nguyễn Phi Khanh, Phường Tân Định, Quận 1, TP Hồ Chí Minh</DChi><TTKhac><TTin><TTruong>SellerName</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerFax</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerPhoneNumber</TTruong><KDLieu>String</KDLieu><DLieu>19006676</DLieu></TTin><TTin><TTruong>SellerEmail</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerWebsite</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerBank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerAccBank</TTruong><KDLieu>String</KDLieu><DLieu>19006676 - TEST HÓA ĐƠN ĐIỆN TỬ VI NA</DLieu></TTin></TTKhac></NBan><NMua><Ten>CÔNG TY CỔ PHẦN CHỮ KÝ SỐ VI NA</Ten><MST>0309612872</MST><DChi>Số 41A Nguyễn Phi Khanh, Phường Tân Định, Quận 1, TP Hồ Chí Minh</DChi><TTKhac><TTin><TTruong>Email</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>ContractName</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Phone</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Fax</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>AccBank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Bank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin></TTKhac></NMua><DSHHDVu><HHDVu><TChat>1</TChat><STT>1</STT><Ten>Sản phẩm hàng hóa 1</Ten><DVTinh>cái</DVTinh><SLuong>10</SLuong><DGia>10000.000000</DGia><TLCKhau>0</TLCKhau><STCKhau>0</STCKhau><ThTien>100000.000000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu><HHDVu><TChat>2</TChat><Ten>Sản phẩm khuyến mãi 2</Ten><DVTinh>cái</DVTinh><SLuong>1</SLuong><DGia>0.000000</DGia><TLCKhau>0</TLCKhau><STCKhau>0</STCKhau><ThTien>0.000000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu><HHDVu><TChat>3</TChat><Ten>chiết khấu 10%</Ten><DVTinh>cái</DVTinh><SLuong>1</SLuong><DGia>10000.000000</DGia><TLCKhau>0</TLCKhau><STCKhau>0</STCKhau><ThTien>10000.000000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu><HHDVu><TChat>4</TChat><Ten>Ghi chú 1</Ten><DVTinh></DVTinh><DGia>0.000000</DGia><TLCKhau>0</TLCKhau><STCKhau>0</STCKhau><ThTien>0.000000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu></DSHHDVu><TToan><THTTLTSuat><LTSuat><ThTien>100000.000000</ThTien><TThue>10000.000000</TThue></LTSuat><LTSuat><ThTien>0.000000</ThTien><TThue>0.000000</TThue></LTSuat><LTSuat><ThTien>10000.000000</ThTien><TThue>1000.000000</TThue></LTSuat><LTSuat><ThTien>0.000000</ThTien><TThue>0.000000</TThue></LTSuat></THTTLTSuat><TgTCThue>90000.000000</TgTCThue><TgTThue>9000.000000</TgTThue><TgTTTBSo>99000.000000</TgTTTBSo><TgTTTBChu>Chín mươi chín nghìn đô la Mỹ</TgTTTBChu><TTKhac></TTKhac></TToan></NDHDon><TTKhac><TTin><TTruong>PaymentTerm</TTruong><KDLieu>String</KDLieu><DLieu>Tiền mặt/Chuyển khoản</DLieu></TTin></TTKhac></DLHDon><DSCKS><NBan><Signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\" Id=\"NBan1\"><SignedInfo><CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"></CanonicalizationMethod><SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"></SignatureMethod><Reference URI=\"#DLHDon\"><Transforms><Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\"></Transform></Transforms><DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"></DigestMethod><DigestValue>FtL5nsdZLhAHkP2ucn6n+GXUHgM=</DigestValue></Reference><Reference URI=\"#nguoiban\"><Transforms><Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\"></Transform></Transforms><DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"></DigestMethod><DigestValue>Mk148XpiZpo1/vzYlviuvrKhb/M=</DigestValue></Reference></SignedInfo><SignatureValue>ZcnWdB7G5hhas7xHBtpGYMJHr/5kJyU6jkf8tQ8NE5AgcbLBlPtaBXsjQeOHXDJMdp1JpEc+cHbY+GjfYU1J8wqTHkahjHgaB4bYyCBBc/CvadsQ+ioJN/UH3PaJUCWvAcayNsZVH2MLQo7K9UaFUn5jpnys6k18lxdqar0ok/w=</SignatureValue><KeyInfo><X509Data><X509Certificate>MIIE5TCCA82gAwIBAgIQVAEBB0A8XWHiz9fsHsm9OjANBgkqhkiG9w0BAQsFADB1MQswCQYDVQQGEwJWTjEoMCYGA1UECgwfQ29uZyB0eSBjbyBwaGFuIGNodSBreSBzbyBWSSBOQTEoMCYGA1UECwwfQ29uZyB0eSBjbyBwaGFuIGNodSBreSBzbyBWSSBOQTESMBAGA1UEAwwJU21hcnRTaWduMB4XDTIxMDExODA4MTkwOFoXDTI0MDExODA4MTkwOFowgYMxHjAcBgoJkiaJk/IsZAEBDA5NU1Q6MDMxMzAzMjM5MTE7MDkGA1UEAwwyQ8OUTkcgVFkgQ+G7lCBQSOG6pk4gQ8OUTkcgTkdI4buGIEFTQVAgLSBRdcOtIFRlc3QxFzAVBgNVBAcMDkjhu5MgQ2jDrSBNaW5oMQswCQYDVQQGEwJWTjCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEApM23KVGiEtEKsFJp+QJc1B3L/pzXvDzMCxuFCH8OBYGD/HoObjtEf62fWfoWyckOD3O5z0JY2A7YlXYBjjKfLoP0/z1igVOySCotF8l3nVgZnwrUkFOmvt6TPdSBOa1XwDbfo1lkZktlkRu0Eo5DNNk3R13vfPSEEOW+osVnOEMCAwEAAaOCAeQwggHgMHIGCCsGAQUFBwEBBGYwZDA1BggrBgEFBQcwAoYpaHR0cHM6Ly9zbWFydHNpZ24uY29tLnZuL3NtYXJ0c2lnbjI1Ni5jcnQwKwYIKwYBBQUHMAGGH2h0dHA6Ly9vY3NwMjU2LnNtYXJ0c2lnbi5jb20udm4wHQYDVR0OBBYEFHXyZgS5B+4iHBPLC60nxXnPL+9YMAwGA1UdEwEB/wQCMAAwHwYDVR0jBBgwFoAU0ApZUhzKisAJ0gQokuqT++NChh8wKAYIKwYBBQUHAQMEHDAaMBgGCCsGAQUFBwsBMAwGCisGAQQBge0DAQcwgZEGA1UdIASBiTCBhjCBgwYKKwYBBAGB7QMBBzB1MEoGCCsGAQUFBwICMD4ePABUAGgAaQBzACAAaQBzACAAYQBjAGMAcgBlAGQAaQB0AGUAZAAgAGMAZQByAHQAaQBmAGkAYwBhAHQAZTAnBggrBgEFBQcCARYbaHR0cDovL3NtYXJ0c2lnbi5jb20udm4vY3BzMC8GA1UdHwQoMCYwJKAioCCGHmh0dHA6Ly9jcmwyNTYuc21hcnRzaWduLmNvbS52bjAOBgNVHQ8BAf8EBAMCA8gwHQYDVR0lBBYwFAYIKwYBBQUHAwIGCCsGAQUFBwMEMA0GCSqGSIb3DQEBCwUAA4IBAQAvCTHfUznkl3H250uKdH7fUrt3MQI73MG/YHKKtjse3nBtJ4WbLx+sgHYEPLu52B/kGu18YbO8M55Fv1hvkzhBskICOe6x0CihD6YBY11ehY52W4px+ELmKAwcDPzRgvo3L9AuhvH+ZIPasw7uBsqIuyu44b7FpcqkJA1D3oybqnCUrsE2c3i7b8/1qA9fXhfsyOpcdx3WB7Nwik9kLJ0il8Ws7moe50SK8PELY+gVwocQf6N4Y9XJxMtawNDQcB+DPU9Fs7SgKqo4fcPA012fAEKQyJSGwlf6XKpW5BpfPTD0QJjXjpsYlvJXwjuAHtpUNEWmXQk2z/y/cIKp9CPb</X509Certificate></X509Data></KeyInfo><Object><SignatureProperties><SignatureProperty Id=\"nguoiban\" Target=\"#NBan1\"><SigningTime>2021-05-28T15:05:22</SigningTime></SignatureProperty></SignatureProperties></Object></Signature></NBan></DSCKS></HDon>");
            //VerifyXML("<library><book Id=\"_0\"><name>Harry Potter</name></book><Signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\"><SignedInfo><CanonicalizationMethod Algorithm=\"http://www.w3.org/2001/10/xml-exc-c14n#\"/><SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"/><Reference URI=\"#_0\"><Transforms><Transform Algorithm=\"http://www.w3.org/2001/10/xml-exc-c14n#\"/></Transforms><DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"/><DigestValue>cdiS43aFDQMnb3X8yaIUej3+z9Q=</DigestValue></Reference></SignedInfo><SignatureValue>U6svAj7fcN6rx4GvJagbYnRj36JmuMUClQ5UTDro1AKBMSNhSk6ARgREc0HzYEeG8xbk4M0C0J2OqRbKRzYIBVPpvATtldNjzc3eM3KFAAONIurWhin56NJcGNAKkVSnWjhcNXO1yayeRv4PSVtgIxwfuckT+g9qXPhxcArDmOPZXsFhDe4I5ZH1xL3U5Tg+UO6jOXhRyMQAAJHD77SHAD785dkSSKYKnaGqBVlXFs8rhPEOM7i/Kxy/4aR33nRxwF7kShghJ21MdtLBymOx5bBvlRZlHfvABdZEP6/B1ZXOYl/VmOOEfix2bp7HzvmkxauCQ4XKmQ3ASzkSbGfhLQ==</SignatureValue><KeyInfo><X509Data><X509Certificate/>MIIDajCCAlKgAwIBAgIJAPPUzc0s8j/HMA0GCSqGSIb3DQEBBQUAMGwxCzAJBgNVBAYTAlZOMQwwCgYDVQQLDANNIDIxDDAKBgNVBAoMA0JDWTEXMBUGA1UEAwwOUGhhbiBRdXkgUXV5bmgxKDAmBgkqhkiG9w0BCQEWGXF1eXF1eW5oLm0yLmJjeUBnbWFpbC5jb20wHhcNMjAxMjI0MDYzMTU4WhcNMjUxMjIzMDYzMTU4WjBsMQswCQYDVQQGEwJWTjEMMAoGA1UECwwDTSAyMQwwCgYDVQQKDANCQ1kxFzAVBgNVBAMMDlBoYW4gUXV5IFF1eW5oMSgwJgYJKoZIhvcNAQkBFhlxdXlxdXluaC5tMi5iY3lAZ21haWwuY29tMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAxHjIj0KuAln/Ao7Ntc5gbzaWJVfm+Aeq9LVci+uN4BlLQB63KSUIFYfeOF44NUucMa8sihKLLa8ZvmPQxb+eqSzR6Ql2wDAYiH/XiM8Ti4W9y/HewZbIX+u7Tk6qG5Sb3Iy9bd1zSiL5kRgZ4NfQgIn+qzm8j8BC2CIzjOLpjMXd7JKnBaYvRzd7U928nx+8B+WmdxS5S3lK5qdWtoTQKuC4MMnMw0eNs6GceuS411kxtHs+WjmG93iT4pblMHQRgM7ZE4LhRUUTd0PSApe5h34NZ/q+r2EVSorhRw7h93ZSxoz8WRYP1/XPTk0dA6tk2IIIqeu6V9Bn7fbpMMqtswIDAQABow8wDTALBgNVHQ8EBAMCBJAwDQYJKoZIhvcNAQEFBQADggEBAHdl/jP/6cYvAul+XyXNIQHtJjBeyq0GdMU3g7GJed0ECxsmBC37N0YupdXJ7Olmf0epCSreXyptse9yP9E/TsNCLMS6q1l6bbjqz5blh8Pl30YjUvizxkGmFvCjAtvs0IEX+VegqQiLEo7vpAH9CqocagbyX69zkbMw36hjdQ1UOILIXlZfjgK5gjqVp1Xzadw0z3jtbesInWNe0LkzIhvg1oD3L9F0Ie2ETj3yD4rVbaXTMgH+ie+RnN4XHeRV6GJa0Xo4ECSqsNYCwx7856qyFnqIQPdEjdzHapsUs7ym0B5M2TwG3K9PxH+IZ+J1JNrnypsvAFHwooU95jMqUys=<X509Certificate/></X509Data></KeyInfo></Signature></library>");
            //string xmlstr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SalaryDeposit>    <Organisation>        <Name>DDLab Inc</Name>        <AccountNo>SBC-12345789</AccountNo>    </Organisation>    <Employees>        <Emp>            <Name>John Abraham</Name>            <AccountNo>SB-001</AccountNo>            <Amount>1234</Amount>        </Emp>        <Emp>            <Name>Bipasha Basu</Name>            <AccountNo>SB-002</AccountNo>            <Amount>2334</Amount>        </Emp>        <Emp>            <Name>Vidya Balan</Name>            <AccountNo>SB-003</AccountNo>            <Amount>3465</Amount>        </Emp>        <Emp>            <Name>Debadatta Mishra</Name>            <AccountNo>SB-007</AccountNo>            <Amount>5789</Amount>        </Emp>        <Emp>            <Name>Priti Zinta</Name>            <AccountNo>SB-009</AccountNo>            <Amount>1234</Amount>        </Emp>    </Employees></SalaryDeposit>";
            string xmlstr2 = "<?xml version=\"1.0\" encoding=\"utf-8\"?><HDon Id=\"19KHCT\"><DLHDon Id=\"DLHDon\"><TTChung><PBan>1.0.0</PBan><THDon>Hóa đơn giá trị gia tăng</THDon><KHMSHDon>01GTKT0/001</KHMSHDon><KHHDon>VN/21E</KHHDon><SHDon>0000169</SHDon><TDLap>2021-05-28T15:05:22</TDLap><TChat>1</TChat><DVTTe>USD</DVTTe><TGia>23000.000000</TGia><TTKhac><TTin><TTruong>IvoiceCode</TTruong><KDLieu>String</KDLieu><DLieu>21HS000305N1</DLieu></TTin><TTin><TTruong>ConvertDate</TTruong><KDLieu>DateTime</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>GuideId</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>GuideCode</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>InvoiceType</TTruong><KDLieu>Int32</KDLieu><DLieu>1</DLieu></TTin><TTin><TTruong>InvoiceTypeType</TTruong><KDLieu>Int32</KDLieu><DLieu>1</DLieu></TTin></TTKhac></TTChung><NDHDon><NBan><Ten>TEST HÓA ĐƠN ĐIỆN TỬ VI NA</Ten><MST>0313032391</MST><DChi>Số 41A Nguyễn Phi Khanh, Phường Tân Định, Quận 1, TP Hồ Chí Minh</DChi><TTKhac><TTin><TTruong>SellerName</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerFax</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerPhoneNumber</TTruong><KDLieu>String</KDLieu><DLieu>19006676</DLieu></TTin><TTin><TTruong>SellerEmail</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerWebsite</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerBank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerAccBank</TTruong><KDLieu>String</KDLieu><DLieu>19006676 - TEST HÓA ĐƠN ĐIỆN TỬ VI NA</DLieu></TTin></TTKhac></NBan><NMua><Ten>CÔNG TY CỔ PHẦN CHỮ KÝ SỐ VI NA</Ten><MST>0309612872</MST><DChi>Số 41A Nguyễn Phi Khanh, Phường Tân Định, Quận 1, TP Hồ Chí Minh</DChi><TTKhac><TTin><TTruong>Email</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>ContractName</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Phone</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Fax</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>AccBank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Bank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin></TTKhac></NMua><DSHHDVu><HHDVu><TChat>1</TChat><STT>1</STT><Ten>Sản phẩm hàng hóa 1</Ten><DVTinh>cái</DVTinh><SLuong>10</SLuong><DGia>10000.000000</DGia><TLCKhau>0</TLCKhau><STCKhau>0</STCKhau><ThTien>100000.000000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu><HHDVu><TChat>2</TChat><Ten>Sản phẩm khuyến mãi 2</Ten><DVTinh>cái</DVTinh><SLuong>1</SLuong><DGia>0.000000</DGia><TLCKhau>0</TLCKhau><STCKhau>0</STCKhau><ThTien>0.000000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu><HHDVu><TChat>3</TChat><Ten>chiết khấu 10%</Ten><DVTinh>cái</DVTinh><SLuong>1</SLuong><DGia>10000.000000</DGia><TLCKhau>0</TLCKhau><STCKhau>0</STCKhau><ThTien>10000.000000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu><HHDVu><TChat>4</TChat><Ten>Ghi chú 1</Ten><DVTinh></DVTinh><DGia>0.000000</DGia><TLCKhau>0</TLCKhau><STCKhau>0</STCKhau><ThTien>0.000000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu></DSHHDVu><TToan><THTTLTSuat><LTSuat><ThTien>100000.000000</ThTien><TThue>10000.000000</TThue></LTSuat><LTSuat><ThTien>0.000000</ThTien><TThue>0.000000</TThue></LTSuat><LTSuat><ThTien>10000.000000</ThTien><TThue>1000.000000</TThue></LTSuat><LTSuat><ThTien>0.000000</ThTien><TThue>0.000000</TThue></LTSuat></THTTLTSuat><TgTCThue>90000.000000</TgTCThue><TgTThue>9000.000000</TgTThue><TgTTTBSo>99000.000000</TgTTTBSo><TgTTTBChu>Chín mươi chín nghìn đô la Mỹ</TgTTTBChu><TTKhac></TTKhac></TToan></NDHDon><TTKhac><TTin><TTruong>PaymentTerm</TTruong><KDLieu>String</KDLieu><DLieu>Tiền mặt/Chuyển khoản</DLieu></TTin></TTKhac></DLHDon></HDon>";
            string xmlstr3 = "<?xml version=\"1.0\" encoding=\"utf-8\"?><HDon><DLHDon Id=\"DLHDon\"><TTChung><PBan>1.0.0</PBan><THDon>Hóa đơn giá trị gia tăng</THDon><KHMSHDon>01GTKT0/001</KHMSHDon><KHHDon>VN/21E</KHHDon><SHDon>0000192</SHDon><TDLap>2021-05-12T09:17:08.92</TDLap><TChat>1</TChat><DVTTe>VND</DVTTe><TGia>100.000000</TGia><TTKhac><TTin><TTruong>IvoiceCode</TTruong><KDLieu>String</KDLieu><DLieu>21HC003749PO</DLieu></TTin><TTin><TTruong>ConvertDate</TTruong><KDLieu>DateTime</KDLieu><DLieu>12/05/2021 09:17:08</DLieu></TTin><TTin><TTruong>GuideId</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>GuideCode</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>InvoiceType</TTruong><KDLieu>Int32</KDLieu><DLieu>1</DLieu></TTin><TTin><TTruong>InvoiceTypeType</TTruong><KDLieu>Int32</KDLieu><DLieu>1</DLieu></TTin></TTKhac></TTChung><NDHDon><NBan><Ten>TEST HÓA ĐƠN ĐIỆN TỬ VI NA - TDTT</Ten><MST>0313032391</MST><DChi>Số 41A Nguyễn Phi Khanh, Phường Tân Định, Quận 1, TP Hồ Chí Minh</DChi><TTKhac><TTin><TTruong>SellerName</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerFax</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerPhoneNumber</TTruong><KDLieu>String</KDLieu><DLieu>19006676</DLieu></TTin><TTin><TTruong>SellerEmail</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerWebsite</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerBank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerAccBank</TTruong><KDLieu>String</KDLieu><DLieu>19006676 - TEST HÓA ĐƠN ĐIỆN TỬ VI NA</DLieu></TTin></TTKhac></NBan><NMua><Ten>CÔNG TY CP CHỮ KÝ SỐ VI NA</Ten><MST>0309612872</MST><DChi>Số 41A Nguyễn Phi Khanh, Phường Tân Định, Quận 1, TP Hồ Chí Minh</DChi><TTKhac><TTin><TTruong>Email</TTruong><KDLieu>String</KDLieu><DLieu>locnp@smartsign.com.vn</DLieu></TTin><TTin><TTruong>ContractName</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Phone</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Fax</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>AccBank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Bank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin></TTKhac></NMua><DSHHDVu><HHDVu><TChat>1</TChat><STT>1</STT><Ten>Chuột 4</Ten><DVTinh>cái</DVTinh><SLuong>1</SLuong><DGia>77000.480000</DGia><TLCKhau>False</TLCKhau><STCKhau>0</STCKhau><ThTien>77000.480000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu></DSHHDVu><TToan><THTTLTSuat><LTSuat><TSuat>10%</TSuat><ThTien>77000.480000</ThTien><TThue>7700.048000</TThue></LTSuat></THTTLTSuat><TgTCThue>77000.000000</TgTCThue><TgTThue>7700.000000</TgTThue><TgTTTBSo>84700.000000</TgTTTBSo><TgTTTBChu>Tám mươi bốn nghìn bảy trăm đồng</TgTTTBChu><TTKhac></TTKhac></TToan></NDHDon><TTKhac><TTin><TTruong>PaymentTerm</TTruong><KDLieu>String</KDLieu><DLieu>Tiền mặt</DLieu></TTin></TTKhac></DLHDon></HDon>";
            string xmlstr4 = "<?xml version=\"1.0\" encoding=\"utf-8\"?><HDon><DLHDon Id=\"DLHDon\"><test>thuan</test></DLHDon></HDon>";
            string xmlStandard = "<?xml version=\"1.0\" encoding=\"utf-8\"?><HDon><DLHDon Id=\"DLHDon\"><TTChung><PBan>1.0.0</PBan><THDon>Hóa đơn giá trị gia tăng</THDon><KHMSHDon>01GTKT0/001</KHMSHDon><KHHDon>VN/21E</KHHDon><SHDon>0000192</SHDon><TDLap>2021-05-12T09:17:08.92</TDLap><TChat>1</TChat><DVTTe>VND</DVTTe><TGia>100.000000</TGia><TTKhac><TTin><TTruong>IvoiceCode</TTruong><KDLieu>String</KDLieu><DLieu>21HC003749PO</DLieu></TTin><TTin><TTruong>ConvertDate</TTruong><KDLieu>DateTime</KDLieu><DLieu>12/05/2021 09:17:08</DLieu></TTin><TTin><TTruong>GuideId</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>GuideCode</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>InvoiceType</TTruong><KDLieu>Int32</KDLieu><DLieu>1</DLieu></TTin><TTin><TTruong>InvoiceTypeType</TTruong><KDLieu>Int32</KDLieu><DLieu>1</DLieu></TTin></TTKhac></TTChung><NDHDon><NBan><Ten>TEST HÓA ĐƠN ĐIỆN TỬ VI NA - TDTT</Ten><MST>0313032391</MST><DChi>Số 41A Nguyễn Phi Khanh, Phường Tân Định, Quận 1, TP Hồ Chí Minh</DChi><TTKhac><TTin><TTruong>SellerName</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerFax</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerPhoneNumber</TTruong><KDLieu>String</KDLieu><DLieu>19006676</DLieu></TTin><TTin><TTruong>SellerEmail</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerWebsite</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerBank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>SellerAccBank</TTruong><KDLieu>String</KDLieu><DLieu>19006676 - TEST HÓA ĐƠN ĐIỆN TỬ VI NA</DLieu></TTin></TTKhac></NBan><NMua><Ten>CÔNG TY CP CHỮ KÝ SỐ VI NA</Ten><MST>0309612872</MST><DChi>Số 41A Nguyễn Phi Khanh, Phường Tân Định, Quận 1, TP Hồ Chí Minh</DChi><TTKhac><TTin><TTruong>Email</TTruong><KDLieu>String</KDLieu><DLieu>locnp@smartsign.com.vn</DLieu></TTin><TTin><TTruong>ContractName</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Phone</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Fax</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>AccBank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin><TTin><TTruong>Bank</TTruong><KDLieu>String</KDLieu><DLieu></DLieu></TTin></TTKhac></NMua><DSHHDVu><HHDVu><TChat>1</TChat><STT>1</STT><Ten>Chuột 4</Ten><DVTinh>cái</DVTinh><SLuong>1</SLuong><DGia>77000.480000</DGia><TLCKhau>False</TLCKhau><STCKhau>0</STCKhau><ThTien>77000.480000</ThTien><TSuat>10%</TSuat><TTKhac></TTKhac></HHDVu></DSHHDVu><TToan><THTTLTSuat><LTSuat><TSuat>10%</TSuat><ThTien>77000.480000</ThTien><TThue>7700.048000</TThue></LTSuat></THTTLTSuat><TgTCThue>77000.000000</TgTCThue><TgTThue>7700.000000</TgTThue><TgTTTBSo>84700.000000</TgTTTBSo><TgTTTBChu>Tám mươi bốn nghìn bảy trăm đồng</TgTTTBChu><TTKhac></TTKhac></TToan></NDHDon><TTKhac><TTin><TTruong>PaymentTerm</TTruong><KDLieu>String</KDLieu><DLieu>Tiền mặt</DLieu></TTin></TTKhac></DLHDon></HDon>";
            SignXML("00F3D4CDCD2CF23FC7", xmlStandard, "DLHDon", "NBan", "NBan1", "nguoiban", "2021-05-28T15:05:22");
        }

        public static string SignXML(string serialnum, string xmlstring, string tag, string id, string signatureid, string signaturepropertyid, string signingtime)
        {
            string strRe = "";
            try
            {

                //var certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser); // LocalMachine
                //certStore.Open(OpenFlags.ReadWrite);
               // X509Certificate2Collection certificates = certStore.Certificates;
                X509Certificate2 certificate = new X509Certificate2(@"D:\Working\ChuKySo\SmartSignAnhHai\cert\VinaCA_TokenID_TemporaryKey.pfx", "");
                //X509Certificate2Collection certificates2 = new X509Certificate2Collection();
                string issuername = certificate.Subject; ;
                //for (int i = 0; i < certificates.Count; i++)
                //{
                    //certificate = certificates[i];
                   // issuername = certificate.Subject;
                    if (certificate.HasPrivateKey)
                    {
                        try
                        {
                            // MessageBox.Show(certificate.SerialNumber +"   " +serial);
                            //if (certificate.SerialNumber == serialnum)
                            {

                                Console.WriteLine("certificate.SerialNumber===");
                                Console.WriteLine(certificate.SerialNumber);
                                Console.WriteLine(issuername);

                                byte[] bytesconver = Encoding.UTF8.GetBytes(xmlstring);
                                string filexmlexport = System.Text.Encoding.UTF8.GetString(bytesconver);
                                XmlDocument doc = new XmlDocument();

                                // Format the document to ignore white spaces.
                                doc.PreserveWhitespace = false;

                                // Load the passed XML file using it's name.
                                doc.LoadXml(filexmlexport);


                                XmlNodeList elemList = doc.GetElementsByTagName("DSCKS");

                                Console.WriteLine("Certificate Verified?: {0}{1}", certificate.Verify(), Environment.NewLine);

                                if (elemList.Count != 0)
                                {
                                    for (int e = 0; e < elemList.Count; e++)
                                    {
                                        strRe = SignXmlFile3(doc, "#" + tag, certificate, id, signatureid, signaturepropertyid, signingtime);
                                    }
                                }
                                else
                                {
                                    XmlNode root = doc.DocumentElement;

                                    //Create a new node DSCKS
                                    XmlElement elem = doc.CreateElement("DSCKS");
                                    elem.InnerXml = "";
                                    root.InsertAfter(elem, root.FirstChild);
                                    for (int e = 0; e < elemList.Count; e++)
                                    {
                                        strRe = SignXmlFile3(doc, "#" + tag, certificate, id, signatureid, signaturepropertyid, signingtime);
                                    }
                                };
                            }
                        }
                        catch (CryptographicException e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Information could not be written out for this certificate.");
                        }
                    }

                //}
            }
            catch (Exception) { }
            return strRe;
        }

        public static string SignXmlFile3(XmlDocument doc, string SignedFileName, X509Certificate2 cert, string tag, string signatureid, string signaturepropertyid, string signingtime)
        {
            string strreturn = "";
            SignaturePropertiesSignedXml signer = new SignaturePropertiesSignedXml(doc, signatureid, signaturepropertyid);

            //X509Certificate2 cert = GetCertificate();

            RSA key = (RSACryptoServiceProvider)cert.PrivateKey;
            signer.SigningKey = key;
            signer.SignedInfo.CanonicalizationMethod = "http://www.w3.org/2001/10/xml-exc-c14n#";
            signer.SignedInfo.SignatureMethod = @"http://www.w3.org/2000/09/xmldsig#rsa-sha1";

            // create a timestamp property
            XmlElement timestamp = doc.CreateElement("SigningTime", SignedXml.XmlDsigNamespaceUrl);
            //timestamp.InnerText = DateTimeToCanonicalRepresentation();
            timestamp.InnerText = signingtime;
            signer.AddProperty(timestamp);


            var certificateKeyInfo = new KeyInfo();
            certificateKeyInfo.Id = "idKeyInfo";
            certificateKeyInfo.AddClause(new KeyInfoX509Data(cert));
            signer.KeyInfo = certificateKeyInfo;

            Reference reference = new Reference(SignedFileName);
            //reference.DigestMethod = @"http://www.w3.org/2001/04/xmlenc#sha256";
            reference.AddTransform(new XmlDsigExcC14NTransform());
            signer.AddReference(reference);

            //Reference propertiesRefki = new Reference();
           // propertiesRefki.Uri = "#idKeyInfo";
            //propertiesRefki.DigestMethod = @"http://www.w3.org/2001/04/xmlenc#sha256";
           // propertiesRefki.AddTransform(new XmlDsigExcC14NTransform());
           // signer.AddReference(propertiesRefki);

            //Reference reference2 = new Reference();
            //reference2.Uri = "#" + signaturepropertyid;
            //reference2.DigestMethod = @"http://www.w3.org/2001/04/xmlenc#sha256";
            //reference2.AddTransform(new XmlDsigExcC14NTransform());
            //signer.AddReference(reference2);

            Console.WriteLine(signer);
            //Console.WriteLine(reference2);
           // Console.WriteLine(propertiesRefki);

            signer.ComputeSignature();

            XmlNodeList elemList = doc.GetElementsByTagName("DSCKS");

            for (int i = 0; i < elemList.Count; i++)
            {
                //Console.WriteLine(elemList[i].InnerXml);
                XmlElement elem = doc.CreateElement(tag);
                elem.AppendChild(signer.GetXml());
                elemList[i].InsertAfter(elem, elemList[i].FirstChild);
            }

            Console.WriteLine("===xml sau khi ky====");
            Console.WriteLine(doc.OuterXml);

            File.WriteAllText(@"D:\Working\ChuKySo\SmartSignAnhHai\xmls\test1\daky_win_1Reference_1.xml", doc.OuterXml);
            strreturn = Base64Encode(doc.OuterXml);

            return strreturn;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }


    public sealed class SignaturePropertiesSignedXml : SignedXml
    {
        private XmlDocument doc;
        private XmlElement signaturePropertiesRoot;
        private XmlElement qualifyingPropertiesRoot;

        private string signaturePropertiesId;

        public SignaturePropertiesSignedXml(XmlDocument doc)
            : base(doc)
        {
            return;
        }

        public SignaturePropertiesSignedXml(XmlDocument doc, string signatureId, string propertiesId)
            : base(doc)
        {
            this.signaturePropertiesId = propertiesId;
            this.doc = null;
            this.signaturePropertiesRoot = null;
            if (string.IsNullOrEmpty(signatureId))
            {
                throw new ArgumentException("signatureId cannot be empty", "signatureId");
            }
            if (string.IsNullOrEmpty(propertiesId))
            {
                throw new ArgumentException("propertiesId cannot be empty", "propertiesId");
            }

            this.doc = doc;
            base.Signature.Id = signatureId;

            this.qualifyingPropertiesRoot = doc.CreateElement("QualifyingProperties", "http://www.w3.org/2000/09/xmldsig#");
            this.qualifyingPropertiesRoot.SetAttribute("Target", "#" + signatureId);

            this.signaturePropertiesRoot = doc.CreateElement("SignedProperties", "http://www.w3.org/2000/09/xmldsig#");
            this.signaturePropertiesRoot.SetAttribute("Id", propertiesId);


            qualifyingPropertiesRoot.AppendChild(signaturePropertiesRoot);
            System.Security.Cryptography.Xml.DataObject dataObject = new System.Security.Cryptography.Xml.DataObject
            {
                Data = qualifyingPropertiesRoot.SelectNodes("."),
                Id = "idObject"
            };
            AddObject(dataObject);


        }

        public void AddProperty(XmlElement content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            XmlElement newChild = this.doc.CreateElement("SignedSignatureProperties", "http://www.w3.org/2000/09/xmldsig#");

            newChild.AppendChild(content);
            this.signaturePropertiesRoot.AppendChild(newChild);
        }

        public override XmlElement GetIdElement(XmlDocument doc, string id)
        {
            if (String.Compare(id, signaturePropertiesId, StringComparison.OrdinalIgnoreCase) == 0)
                return this.signaturePropertiesRoot;

            if (String.Compare(id, this.KeyInfo.Id, StringComparison.OrdinalIgnoreCase) == 0)
                return this.KeyInfo.GetXml();

            return base.GetIdElement(doc, id);
        }
    }

}
