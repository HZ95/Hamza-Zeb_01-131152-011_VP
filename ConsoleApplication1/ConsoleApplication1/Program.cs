using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace ConsoleApplication8
{
    class Student
    {
        private String ID;
        private String name;
        private String semester;
        private String cgpa;
        private String dept;
        private String uni;
        public void setData()
        {
            Console.WriteLine("Enter Student Id : ");
            ID = Console.ReadLine();
            Console.WriteLine("Enter Student Name : ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Semester : ");
            semester = Console.ReadLine();
            Console.WriteLine("Enter CGPA : ");
            cgpa = Console.ReadLine();
            Console.WriteLine("Enter Departmnt :");
            dept = Console.ReadLine();
            Console.WriteLine("Enter University : ");
            uni = Console.ReadLine();
        }
        public void writeData(string path)
        {
            Program prog = new Program();
            if (prog.checkId(path, ID) == false)
            {
                FileStream writefile = new FileStream(path, FileMode.Append);
                StreamWriter sw = new StreamWriter(writefile);
                sw.WriteLine(ID);
                sw.WriteLine(name);
                sw.WriteLine(semester);
                sw.WriteLine(cgpa);
                sw.WriteLine(dept);
                sw.WriteLine(uni);
                sw.Close();
            }
            else
            {
                Console.WriteLine("Can't Register");
                Console.WriteLine("This id already exists.");
            }
        }
    }
    class Program
    {
        void searchById(String path, String id)
        {
            FileStream readfile = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(readfile);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == id)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        System.Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }

        }
        void searchByName(string path, string name)
        {
            Stack mystack = new Stack();
            FileStream readfile = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(readfile);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == name)
                {
                    System.Console.WriteLine(mystack.Pop());
                    for (int i = 0; i < 5; i++)
                    {
                        System.Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
                mystack.Push(line);
            }
            sr.Close();
        }
        public bool checkId(String path, String id)
        {
            bool flag = false;
            if(File.Exists(path))
            {
                FileStream readfile = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(readfile);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == id)
                        flag = true;
                }
                
            }
            else
            {
               
            }
            return flag;
        }

        void searchBySemester(String path, String semester)
        {
            Stack mystack = new Stack();
            FileStream readfile = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(readfile);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == semester)
                {
                    System.Console.WriteLine(mystack.Pop());
                    System.Console.WriteLine(mystack.Pop());
                    for (int i = 0; i < 4; i++)
                    {
                        System.Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
                mystack.Push(line);
                line = sr.ReadLine();
                mystack.Push(line);
            }

        }

        static void Main(string[] args)
        {
            String path = "Student_record.txt";
            String attendance = "attendence.txt";
            Program p = new Program();
            bool flag = true;
            while (flag == true)
            {
                Console.Clear();
                Console.WriteLine("Press 1 for Creating Student Profiles");
                Console.WriteLine("      2 for Searching  ");
                Console.WriteLine("      3 for Deleting a Record");
                Console.WriteLine("      4 for Listing Top 3 Students");
                Console.WriteLine("      5 for Marking Attendance");
                Console.WriteLine("      6 for Viewing Attendance");
                String choice = Console.ReadLine();
                if (choice == "1")
                {
                    Student obj = new Student();
                    obj.setData();
                    obj.writeData(path);
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Press 1 to Search by ID   ");
                    Console.WriteLine("      2 to Search by Name ");
                    Console.WriteLine("      3 to Search by Semester");
                    Console.WriteLine("Total Num of Students Are :");
                    String searchchoice = Console.ReadLine();
                    if (searchchoice == "1")
                    {
                        Console.WriteLine("Enter ID :");
                        string id = Console.ReadLine();
                        p.searchById(path, id);
                    }
                    else if (searchchoice == "2")
                    {
                        Console.WriteLine("Enter Name :");
                        string name = Console.ReadLine();
                        p.searchByName(path, name);
                    }
                    else if (searchchoice == "3")
                    {
                        Console.WriteLine("Enter Semester :");
                        string semester = Console.ReadLine();
                        p.searchBySemester(path, semester);
                    }
                    else { Console.WriteLine("Invalid choice"); }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Enter the Enrolment of Student you want to delete Record :");
                    String num = Console.ReadLine();

                }
                else if (choice == "4")
                {
                    // top 3
                }
                else if (choice == "5")
                {
                    FileStream readfile = new FileStream(path, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(readfile);
                    String name;
                    FileStream writefile = new FileStream(attendance, FileMode.OpenOrCreate);
                    StreamWriter sw = new StreamWriter(writefile);
                    while (sr.ReadLine() != null)
                    {
                        name = sr.ReadLine();
                        for (int i = 0; i < 4; i++)
                            sr.ReadLine();
                        sw.WriteLine(name);
                        Console.WriteLine("Press p for present and a for absent for : " + name);
                        sw.WriteLine(Console.ReadLine());
                    }
                    sr.Close();
                    sw.Close();
                }
                else if (choice == "6")
                {
                    FileStream readfile = new FileStream(attendance, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(readfile);
                    String name, att;
                    while ((name = sr.ReadLine()) != null)
                    {
                        att = sr.ReadLine();
                        Console.WriteLine(name);
                        if (att == "a")
                            Console.WriteLine("-Absent");
                        else if (att == "p")
                            Console.WriteLine("-Present");
                        else
                            Console.WriteLine("-" + att);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
                Console.WriteLine("Press Y If you want to perform an other option or any other key to exit:");
                String loop = Console.ReadLine();
                if (loop == "Y" || loop == "y")
                {

                }
                else
                    flag = false;
            }
        }
    }
}
