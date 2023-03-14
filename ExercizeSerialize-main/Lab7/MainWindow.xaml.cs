using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;



namespace Lab7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    [Serializable]
    public class Student {
        [JsonPropertyName("NazwiskoStudenta")]
        [XmlElement("NazwiskoStudenta")]
        public string Nazwisko { get; set; }
        [XmlAttribute]
        public double Ocena { get; set; }
    }
    [Serializable]
    public class Grupa { 
        [XmlElement("NAzwaGrupy")]
        [JsonPropertyName("NazwiskoStudenta")]
        public string Nazwa { get; set; }
        
        public List<Student> Students { get; set; }
        [JsonIgnore]
        [XmlAttribute]
        public int LiczbaStudentow { get => Students.Count(); }
        public double? SredniaOcen { get { if (Students.Count == 0) return null; else { return Students.Average(s=>s.Ocena); } } }
        public override string ToString()
        {
            string wynik = null;
            wynik += "Grupa: "+this.Nazwa+"\n";
            foreach (Student student in Students) { 
                wynik+=student.Nazwisko + " "+ student.Ocena+"\n";
            }
            wynik += "Liczba studentow: " + LiczbaStudentow+"\nSrednia ocen: "+SredniaOcen;

            return wynik;
        }
        public void Wyswietl(ListBox list) { 
        list.Items.Clear();
            list.Items.Add(this);
        }
        public void ZapiszDoPliku(string nazwaPliku) { 
            FileStream fs = new FileStream($@"C:\{nazwaPliku}.txt", FileMode.Create,FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(this.ToString());
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
    public partial class MainWindow : Window
    {

        Grupa grupa = new Grupa();
        public MainWindow()
        {
            InitializeComponent();
            Student student1 = new Student() { Nazwisko = "Majdan", Ocena = 4.0 },student2 = new Student() { Nazwisko = "Wajdan", Ocena = 5.0 }, student3 = new Student() { Nazwisko = "Kajdan", Ocena = 3.0 };
            List<Student> studenci = new List<Student>() { student1,student2,student3 };
            grupa.Nazwa = "I12";
            grupa.Students = studenci;
        }

        private void btnIO_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("..//..//Wynik.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd/ HH:mm"));
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void btnCzytaj_Click(object sender, RoutedEventArgs e)
        {
            lblMaksMin.Content = "";
            lstLiczby.Items.Clear();
            FileStream fs = new FileStream("..//..//Wynik.txt", FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            List<double> liczby = new List<double>();
            while (sw.Peek() != -1) {
                var liczba = Convert.ToDouble(sw.ReadLine());
                liczby.Add(liczba);
                lstLiczby.Items.Add($"{liczba:F3}");
            }
            fs.Close();
            var min = liczby.Min();
            var max = liczby.Max();
            var sred = liczby.Average();
            lblMaksMin.Content += "Min:" + min + " Max:" + max + " Avg:" + sred;
            
        }



        private void btnZapiszXml_Click(object sender, RoutedEventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;    //If RestoreDirectory property is set to true that means the open file dialog box restores the current directory before closing.
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Browse Text Files";
            saveFileDialog1.DefaultExt = "xml"; //DefaultExtn property represents the default file name extension.
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;    // FilterIndex property represents the index of the filter currently selected in the file dialog box.
            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(Grupa));
                serializer.Serialize(fs, grupa);
                fs.Close();
            }

        }

        private void btnWyswietlGrupy_Click(object sender, RoutedEventArgs e)
        {
            lstLiczby.Items.Clear();
            lstLiczby.Items.Add(grupa);
        }

        private void btnWczytXml_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("..//..//Grupy.xml", FileMode.Open);
            XmlSerializer ser = new XmlSerializer(typeof(Grupa));
            Grupa g1=(Grupa) ser.Deserialize(fs);
            fs.Close();
            grupa = g1;
        }

        private void btnSaveBin_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;    //If RestoreDirectory property is set to true that means the open file dialog box restores the current directory before closing.
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Browse Text Files";
            saveFileDialog1.DefaultExt = "bin"; //DefaultExtn property represents the default file name extension.
            saveFileDialog1.Filter = "bin files (*.bin)|*.bin";
            saveFileDialog1.FilterIndex = 2;    // FilterIndex property represents the index of the filter currently selected in the file dialog box.
            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, grupa);
                fs.Close();
            }
        }

        private void btnWczytBin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;    //If RestoreDirectory property is set to true that means the open file dialog box restores the current directory before closing.
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "bin"; //DefaultExtn property represents the default file name extension.
            openFileDialog1.Filter = "bin files (*.bin)|*.bin";
            openFileDialog1.FilterIndex = 2;    // FilterIndex property represents the index of the filter currently selected in the file dialog box.
            if (openFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                Grupa g1 = (Grupa)bf.Deserialize(fs);
                fs.Close();
                grupa = g1;
            }
        }

        private void btnSaveJson_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog zapisz = new SaveFileDialog();
            zapisz.Filter = "json files (*.json)|*.json";
            if (zapisz.ShowDialog() == true)
            {
                string json = JsonSerializer.Serialize<Grupa>(grupa);
                File.WriteAllText(zapisz.FileName, json);
            }

        }

        private void btnWczytJson_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "json files (*.json)|*.json";
            if (openFileDialog1.ShowDialog() == true)
            {
                String json = File.ReadAllText(openFileDialog1.FileName);
                var g2 = JsonSerializer.Deserialize<Grupa>(json);
                grupa = g2;
            }
        }

        private void btnSaveRecznie_Click(object sender, RoutedEventArgs e)
        {
            grupa.ZapiszDoPliku("Zapis reczny");
        }

        private void btnWczytajExe_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "exe files (*.exe)|*.exe"; 
            if (openFileDialog1.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                {
                    using (BinaryReader r = new BinaryReader(fs,Encoding.UTF8))
                    {
                        byte[] b = new byte[10];
                        r.Read(b, 0, 10);
                        foreach(byte b2 in b)
                        {
                            lstLiczby.Items.Add(b2);
                        }
                        lstLiczby.Items.Add("Zawartosc pliku: "+System.Text.Encoding.Default.GetString(b));

                    }
                }
            }
        }
    }
}
