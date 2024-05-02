using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace final
{

    public partial class Calculator : Form
    {
        private Stack<double> stack = new Stack<double>();
        private string operation = "";
        public Calculator()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string buttonText = button.Text;
            if (buttonText == "AC")
            {
                Clear();
            }
            else if (buttonText == "=")
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length);

                Calculate();
            }
            else if (buttonText == "DEL")
            {
                if (textBox1.Text.Length > 0)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }
            }
            else
            {
                AddToInput(buttonText);
            }
        }
        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void AddToInput(string text)
        {
            textBox1.Text += text;
        }
        private void Calculate()
        {
            string expression = textBox1.Text;
            try
            {
                double result = EvaluateExpression(expression);
                textBox2.Text = result.ToString();
            }
            catch (FormatException)
            {
                textBox2.Text = ":Lỗi : biểu thức không đúng";
            }
            catch (Exception ex)
            {
                textBox2.Text = "Lỗi: " + ex.Message;
            }
        }

        private double EvaluateExpression(string expression)
        {
            expression = expression.Replace(" ", "");
            if (expression.Count(c => c == '(') != expression.Count(c => c == ')'))
            {
                throw new FormatException("thiếu dấu đóng ngoặc đơn");
            }
            while (expression.Contains("("))
            {
                int openingBracketIndex = expression.LastIndexOf('(');
                int closingBracketIndex = expression.IndexOf(')', openingBracketIndex);

                string subExpression = expression.Substring(openingBracketIndex + 1, closingBracketIndex - openingBracketIndex - 1);
                double subResult = EvaluateSimpleExpression(subExpression);

                expression = expression.Remove(openingBracketIndex, closingBracketIndex - openingBracketIndex + 1).Insert(openingBracketIndex, subResult.ToString());
            }
            return EvaluateSimpleExpression(expression);
        }

        private double EvaluateSimpleExpression(string expression)
        {
            DataTable dt = new DataTable();
            if (expression.Contains("-"))
            {
                expression = expression.Replace("-", " - ");
            }

            if (expression.Contains("."))
            {
                double result = Convert.ToDouble(dt.Compute(expression, ""));
                return result;
            }
            else
            {
                double result = Convert.ToDouble(dt.Compute(expression, ""));
                return result;
            }
        }
    }
}