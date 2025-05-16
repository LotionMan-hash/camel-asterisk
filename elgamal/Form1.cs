using System.Collections;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Windows.Forms;


namespace elgamal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
            lblStatus.Text = "Processing";
            Keygen();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //for funsies
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();
            if (!String.IsNullOrEmpty(txtPlain.Text) && !String.IsNullOrEmpty(txtX.Text) &&
                !String.IsNullOrEmpty(txtP.Text) && !String.IsNullOrEmpty(txtA.Text))
            {
                lblStatus.Text = "Processing";
                if (!BigInteger.TryParse(txtP.Text, out BigInteger p))
                {
                    Console.WriteLine("Encrypting failed - Invalid p.\n");
                    lblStatus.Text = "Encrypting failed - Invalid p";
                    return;
                }
                if (!BigInteger.TryParse(txtA.Text, out BigInteger a))
                {
                    Console.WriteLine("Encrypting failed - Invalid a.\n");
                    lblStatus.Text = "Encrypting failed - Invalid a";
                    return;
                }
                if (!BigInteger.TryParse(txtK.Text, out BigInteger k) && cbK.Checked)
                {
                    Console.WriteLine("Encrypting failed - Invalid k.\n");
                    lblStatus.Text = "Encrypting failed - Invalid k";
                    return;
                }
                if (Utils.IsPrimeNumber(p))
                {
                    if (!BigInteger.TryParse(txtX.Text, out BigInteger x)) { x = Utils.StringToNumber(txtX.Text); }
                    BigInteger plain = 0;
                    if (cbType.SelectedIndex == 0) { plain = Utils.StringToNumber(txtPlain.Text); }
                    else
                    {
                        if (!BigInteger.TryParse(txtPlain.Text, out plain))
                        {
                            Console.WriteLine("Encrypting failed - Invalid plaintext.\n");
                            lblStatus.Text = "Encrypting failed - Invalid plaintext";
                            return;
                        }
                    }
                    Key key = new(p, a, x, 0);
                    if (key.X > key.P) { Console.WriteLine($"P({key.P}) must larger than X({key.X}).\n"); lblStatus.Text = "Encrypting failed - P must larger than X."; }
                    else if (key.A > key.P) { Console.WriteLine($"P({key.P}) must larger than A({key.A}).\n"); lblStatus.Text = "Encrypting failed - P must larger than A."; }
                    else if (k > key.P) { Console.WriteLine($"P({key.P}) must larger than K({k}).\n"); lblStatus.Text = "Encrypting failed - P must larger than K."; }
                    else if (plain > key.P) { Console.WriteLine("Plaintext is too long.\n"); lblStatus.Text = "Encrypting failed - Plaintext is too long."; }
                    else
                    {
                        key.Y = BigInteger.ModPow(key.A, key.X, key.P);
                        txtY.Text = key.Y.ToString();
                        var enc = ElGamal.Encrypt(plain, key, k);
                        txtCypher1.Text = enc.c1.ToString();
                        txtCypher2.Text = enc.c2.ToString();
                        Console.WriteLine("Encryption time: {0:D}ms\n", timer.ElapsedMilliseconds);
                        lblStatus.Text = $"Encrypting completed ({timer.ElapsedMilliseconds}ms)";
                    }
                }
                else { Console.WriteLine("P must be a prime number.\n"); lblStatus.Text = "Encrypting failed - P must be a prime number."; }
                timer.Stop();
            }
            else { Console.WriteLine("Not enough data.\n"); lblStatus.Text = "Encrypting failed - Not enough data."; }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();
            if (!String.IsNullOrEmpty(txtCypher1.Text) && !String.IsNullOrEmpty(txtCypher2.Text)
                && !String.IsNullOrEmpty(txtX.Text))
            {
                lblStatus.Text = "Processing";
                if (!BigInteger.TryParse(txtP.Text, out BigInteger p))
                {
                    Console.WriteLine("Encrypting failed - Invalid p.\n");
                    lblStatus.Text = "Encrypting failed - Invalid p";
                    return;
                }
                if (!BigInteger.TryParse(txtCypher1.Text, out BigInteger c1))
                {
                    Console.WriteLine("Encrypting failed - Invalid c1.\n");
                    lblStatus.Text = "Encrypting failed - Invalid c1";
                    return;
                }
                if (!BigInteger.TryParse(txtCypher2.Text, out BigInteger c2))
                {
                    Console.WriteLine("Encrypting failed - Invalid c2.\n");
                    lblStatus.Text = "Encrypting failed - Invalid c2";
                    return;
                }
                if (!BigInteger.TryParse(txtX.Text, out BigInteger x)) { x = Utils.StringToNumber(txtX.Text); }
                bool isString = true;
                if (cbType.SelectedIndex == 1) { isString = false; }
                txtPlain.Text = ElGamal.Decrypt(c1, c2, x, p, isString);
                Console.WriteLine($"Decryption time: {timer.ElapsedMilliseconds}ms\n");
                lblStatus.Text = $"Decrypting completed ({timer.ElapsedMilliseconds}ms)";                
            }
            else { Console.WriteLine("Decrypting failed - Not enough data.\n"); lblStatus.Text = "Decrypting failed - Not enough data."; }
            timer.Stop();
        }

        private void btnKeygen_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Generating new key(s)...");
            lblStatus.Text = "Processing";
            Keygen();
        }
        void Keygen()
        {
            int key_size = Convert.ToInt32(nudKeySize.Value);
            if (key_size == 0) { Console.WriteLine("Generating key(s) failed - Key size must be larger than 0\n"); lblStatus.Text = "Generating key(s) failed - Key size must be larger than 0"; }
            else
            {
                var timer = Stopwatch.StartNew();
                bool doX = chkX.Checked;
                Key key = ElGamal.GenerateKey(key_size, doX);
                txtP.Text = key.P.ToString();
                txtA.Text = key.A.ToString();
                if (doX)
                {
                    txtX.Text = key.X.ToString();
                    txtY.Text = key.Y.ToString();
                }
                else
                {
                    txtY.Text = string.Empty;
                }
                key.Free();
                Console.WriteLine($"Time: {timer.ElapsedMilliseconds}ms\n");
                lblStatus.Text = $"Key generated ({timer.ElapsedMilliseconds}ms)";
                timer.Stop();
            }
        }

        private void txtP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtY_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPlain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbType.SelectedIndex == 1) { e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); }
        }

        private void cbType_SelectedValueChanged(object sender, EventArgs e)
        {
            txtPlain.Text = string.Empty;
        }

        private void txtCypher1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCypher2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtK_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbK.Checked) { txtK.Enabled = true; }
            else { txtK.Enabled = false; }
            txtK.Text = string.Empty;
        }
    }
}
