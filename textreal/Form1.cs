using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static Org.BouncyCastle.Math.Primes;

namespace textreal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = ".txt";
            savefile.Filter = "Test files|*.txt";
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName, true))
                {
                    sw.WriteLine(textBox1.Text);
                    sw.Close();
                }

            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = ".pdf";
            savefile.Filter = "PDF files|*.pdf";

            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)
            {
                Document doc = new Document();
                using (FileStream fileStream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    PdfWriter.GetInstance(doc, fileStream);
                    doc.Open();
                    doc.Add(new Paragraph(textBox1.Text));
                    doc.Close();
                }
            }
        }
    }
}
