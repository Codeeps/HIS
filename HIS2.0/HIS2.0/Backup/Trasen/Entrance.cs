using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.IO.Compression;


namespace TraSen
{
    /// <summary>
    /// 系统入口
    /// </summary>
    public class Entrance
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main( string[] args )
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler( CurrentDomain_AssemblyResolve );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            //TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog( new string[] { string.Format("********************************************** Local Time : {0} **********************************************",DateTime.Now.ToString() ) }, false );

           // string clientConfigFile = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini";

            string[] ss = System.Windows.Forms.Application.ExecutablePath.Split( "\\".ToCharArray() );
           // TrasenClasses.GeneralClasses.ApiFunction.WriteIniString( "HIS_StARTUP_EXE" , "NAME" , ss[ss.Length - 1] , clientConfigFile );
            
            string serverName = "";

           // serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", clientConfigFile);
            if (serverName == "")
            {
                System.Windows.Forms.MessageBox.Show("ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器", "错误");
                return;
            }
            
           // string connectionString = TrasenFrame.Classes.WorkStaticFun.GetConnnectionString_Default(TrasenFrame.Classes.ConnectionType.SQLSERVER);//.GetConnnectionString(ConnectionType.SQLSERVER, serverName);


            if ( args != null && args.Length > 0 && args[0] == "IsFormUpdate" )
            {

               // TrasenMainWindow.FrmMdiMainWindow.StartupMain( "创星科技信息系统" , TrasenFrame.Classes.ConnectionType.SQLSERVER , connectionString , "Trasen" , true , true );
                return;
            }
            
            //TrasenMainWindow.FrmMdiMainWindow.StartupMain( "创星科技信息系统" , TrasenFrame.Classes.ConnectionType.SQLSERVER , connectionString , "Trasen" , true );
        }

  

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve( object sender , ResolveEventArgs args )
        {
            string[] info = args.Name.Split( ",".ToCharArray() );
            string dllName = string.Format( "{0}.dll" , info[0] );
            string strTempAssmbPath = "";
            string systemFolder = @"D:\公司代码\TrasenHISv2.0\标准版\Output\";
            strTempAssmbPath = System.IO.Path.Combine( systemFolder , dllName );
            return string.IsNullOrEmpty( strTempAssmbPath ) ? null : System.Reflection.Assembly.LoadFrom( strTempAssmbPath );
        }
    }
}
