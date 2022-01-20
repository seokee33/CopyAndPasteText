using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAndPasteText
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //폴더내 파일 이름 리스트 가져오기
            List<string> textNameList = new List<string>();
            
            Console.Write("폴더 경로 : ");
            string folderDir = Console.ReadLine();
            
            DirectoryInfo di = new DirectoryInfo(folderDir);
            foreach (System.IO.FileInfo file in di.GetFiles())
            {
                textNameList.Add(file.Name);
            }

            // 제대로 가져왔는지 확인하는 부분
            //foreach(string name in textNameList)
            //{
            //    Console.WriteLine(name);
            //}

            //텍스트 파일을 가져와서 합치는 부분
            string result = "result.txt";
            StreamWriter sw = new StreamWriter(new FileStream(result, FileMode.Append));
            foreach (string name in textNameList)
            {
                sw.WriteLine("**********" + name+ "**********");
                StreamReader sr = new StreamReader(new FileStream(folderDir+"\\"+name, FileMode.Open));
                while(sr.EndOfStream == false)
                {
                    sw.WriteLine(sr.ReadLine());
                }
                sw.WriteLine("\n\n\n");
                sr.Close();
            }

            sw.Close();
            
        }
    }
}
